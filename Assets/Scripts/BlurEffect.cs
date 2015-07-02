using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class BlurEffect : MonoBehaviour
{

    public BlurOptimized blurOptimized;
    private float blurSizeVal;

    private GameController gc;
    public int museNumber;

	// Use this for initialization
	void Start ()
	{
	    gc = gameObject.GetComponent<GameController>();
	    blurOptimized = GetComponent<BlurOptimized>();

        blurOptimized.blurSize = Random.Range(1.5f, 6.5f);
	    blurSizeVal = blurOptimized.blurSize;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    /*if (true && gc.museStatus[museNumber] == 1)
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

	public void applyConcentration (float con){
        float result = Mathf.Lerp(0f,1.5f,1-con);
        blurSizeVal = Mathf.Clamp(result, 0f, 10f);
        blurOptimized.blurSize = blurSizeVal;
    }
}
