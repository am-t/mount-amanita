using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shake = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    private GameController gc;
    public int museNumber;

	// Use this for initialization
    private void Start()
    {
        gc = gameObject.GetComponent<GameController>();
    }

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        //If concentration level is high, then decrease shake
        //else shake

        //Currently shakes for 10 seconds, then stops
        /*if (true && gc.museStatus[museNumber] == 1)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0f;
            camTransform.localPosition = originalPos;
        }*/
    }
    public void applyConcentration (float con){
        float result = Mathf.Lerp(0f,1f,1-con);
        camTransform.localPosition = originalPos + Random.insideUnitSphere * result;
        //shake -= Time.deltaTime * decreaseFactor;
        if(result == 0f) {
            shake = 0f;
            camTransform.localPosition = originalPos;
        }else{
            shake = 0.1f;
        }

    }
}