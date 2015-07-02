using UnityEngine;
using System.Collections;

public class EffectInitialize : MonoBehaviour
{

    public GameController gc;
    public GameObject[] effectArray = new GameObject[4];
    private int currentIndex = 0;
    private bool effectReady = false;
    private float dif = 0.0f;
    public int nextlvl;

	// Use this for initialization
	void Start ()
	{
	    gc = gameObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	   if(effectReady){
         //Apply concentration levels to effect
         bool allGood = true;
         for(int i = 0; i < 4; i++){
            if(effectArray[i].activeSelf){
                effectArray[i].applyConcentration(gc.playerConcentration[i]);
                if(gc.playerConcentration[i] != 1.0f){
                    allGood = false;
                }
            }
         }
         if(allGood){
            gc.startLevel(nextlvl);
            //TODO: Stop Timer
         }

       }
	}

    public void startEffects(float difficulty)
    {
        int newIndex = Random.Range(0, effectArray.Length);
        
        //Get currently active muses
        //Make an array of effects
        for (int i = 0; i < effectArray.Length; i++) {
            if (gc.museStatus[i] == 1) { 
                effectArray[currentIndex].SetActive(false);
                currentIndex = newIndex;
                effectArray[currentIndex].SetActive(true);
            }
        }
        dif = difficulty;
        effectReady = true;
        //TODO: Start Timer
    }
}
