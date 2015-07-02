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
    private BlurEffect be;
    private CameraShake cs;
    private FadeEffect fe ;
    private TwirlEffect te;

	// Use this for initialization
	void Start ()
	{
	    gc = gameObject.GetComponent<GameController>();
        be = gameObject.GetComponent<BlurEffect>();
        cs = gameObject.GetComponent<CameraShake>();
        fe = gameObject.GetComponent<FadeEffect>();
        te = gameObject.GetComponent<TwirlEffect>();

	}
	
	// Update is called once per frame
	void Update () {
	   if(effectReady){
         //Apply concentration levels to effect
         bool allGood = true;
         for(int i = 0; i < 4; i++){
            if(effectArray[i].activeSelf){
                switch(effectArray[i].GetType().ToString()){
                    case "BlurEffect":
                        
                         be.applyConcentration(gc.playerConcentration[i]);
                    break;
                    case "CameraShake":
                         
                         cs.applyConcentration(gc.playerConcentration[i]);
                    break;
                    case "FadeEffect":
                         fe.applyConcentration(gc.playerConcentration[i]);
                    break;
                    case "TwirlEffect":                         
                         te.applyConcentration(gc.playerConcentration[i]);
                    break;

                };
               
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

