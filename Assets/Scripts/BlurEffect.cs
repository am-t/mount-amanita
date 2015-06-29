using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class BlurEffect : MonoBehaviour
{
	public OSCConnectionExample osc;

    public BlurOptimized blurOptimized;
    private float blurSizeVal;

	// Use this for initialization
	void Start ()
	{
		osc = GetComponent<OSCConnectionExample>();
	    blurOptimized = GetComponent<BlurOptimized>();

        blurOptimized.blurSize = Random.Range(1.5f, 6.5f);
	    blurSizeVal = blurOptimized.blurSize;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (osc.acc.x > 0.5f)
	    {
	        blurSizeVal -= 0.05f;
	        blurSizeVal = Mathf.Clamp(blurSizeVal, 0f, 10f);
	        blurOptimized.blurSize = blurSizeVal;
            //Debug.Log("Blur Size is " + blurOptimized.blurSize);
	    }else{
	    	blurSizeVal += 0.05f;
	    	blurSizeVal = Mathf.Clamp(blurSizeVal, 0f, 10f);
	        blurOptimized.blurSize = blurSizeVal;
            //Debug.Log("Blur Size is " + blurOptimized.blurSize);

	    }


		/*blurSizeVal-= osc.acc.x;
		blurSizeVal = Mathf.Clamp(blurSizeVal, 0f, 7f);
		blurOptimized.blurSize = blurSizeVal;*/
	}
}
