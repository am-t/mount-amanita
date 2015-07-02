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
    public int lvl;
    private BlurEffect be;
    private CameraShake cs;
    private FadeEffect fe ;
    private TwirlEffect te;
    private GameTimer gt;

	// Use this for initialization
	void Start ()
	{
	    gc = gameObject.GetComponent<GameController>();
        be = gameObject.GetComponent<BlurEffect>();
        cs = gameObject.GetComponent<CameraShake>();
        fe = gameObject.GetComponent<FadeEffect>();
        te = gameObject.GetComponent<TwirlEffect>();
        gt = gameObject.GetComponent<GameTimer>();

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
            float elapsed = gt.stop();
            gc.levelTime[lvl-1] = elapsed;
            gc.startLevel(nextlvl);
            
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
        gt.start();
        }
    }

