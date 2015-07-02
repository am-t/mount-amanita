using UnityEngine;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public SpriteRenderer sprite;
    [SerializeField] float alphaVal;
    [SerializeField]
    float timer = 5f;
    [SerializeField]
    float timeReset = 3f;
    private float randomAlphaChange;

    private GameController gc;
    public int museNumber;

    // Use this for initialization
    void Start()
    {
        gc = gameObject.GetComponent<GameController>();
        randomAlphaChange = Random.Range(0.05f, 0.25f);
    }


    private void Update()
    {
        /*timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.B) && gc.museStatus[museNumber] == 1)
        {
            //Debug.Log("Pressed b button");
            alphaVal -= randomAlphaChange;
        }
        else if (timer < 1f)
        {
         //   Debug.Log("Resetting alpha value");
            alphaVal += randomAlphaChange;
        }

        alphaVal = Mathf.Clamp(alphaVal, 0f, 1f);
        sprite.color = new Color(1f, 1f, 1f, alphaVal);
        timer = timeReset;*/
    }
    public void applyConcentration (float con){
        float result = Mathf.Lerp(0f,1f,1-con);
        alphaVal = Mathf.Clamp(result, 0f, 1f);
        sprite.color = new Color(1f, 1f, 1f, alphaVal);
    }

}
