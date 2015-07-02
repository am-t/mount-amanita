using UnityEngine;
using System.Collections;

public class EffectInitialize : MonoBehaviour
{

    public GameController gc;
    public GameObject[] effectArray = new GameObject[4];
    private int currentIndex = 0;

	// Use this for initialization
	void Start ()
	{
	    gc = gameObject.GetComponent<GameController>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startEffects(float difficulty)
    {
        /*int newIndex = Random.Range(0, effectArray.Length);
        
        //Get currently active muses
        //Make an array of effects
        for (int i = 0; i < effectArray.Length; i++) {
            if (gc.museStatus[i] == 1) { 
                effectArray[currentIndex].SetActive(false);
                currentIndex = newIndex;
                effectArray[currentIndex].SetActive(true);
            }
        }*/


    }
}
