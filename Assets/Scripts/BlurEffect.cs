using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class BlurEffect : MonoBehaviour
{

    public BlurOptimized blurOptimized;
    private float blurSizeVal;

	// Use this for initialization
	void Start ()
	{
	    blurOptimized = GetComponent<BlurOptimized>();

        blurOptimized.blurSize = Random.Range(1.5f, 6.5f);
	    blurSizeVal = blurOptimized.blurSize;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        blurSizeVal--;
	        blurSizeVal = Mathf.Clamp(blurSizeVal, 0f, 7f);
	        blurOptimized.blurSize = blurSizeVal;
            Debug.Log("Blur Size is " + blurOptimized.blurSize);
	    }
	}
}
