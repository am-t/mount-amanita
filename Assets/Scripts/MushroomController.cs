using UnityEngine;
using System.Collections;

public class MushroomController : MonoBehaviour {

	public GameController gc;
    public EffectInitialize ei;
	public int lvl;
	private bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(lvl > 1 && lvl < 5 && !triggered){
			//check if a mushroom was picked up
			//depending on level
			switch(lvl){
				case 2:
					if(gc.mushroomState[0] == 1){
                        ei.startEffects(gc.mushroomDifficulty[0]);
						triggered = true;
					}
				break;
				case 3:
					if(gc.mushroomState[1] == 1){
                        ei.startEffects(gc.mushroomDifficulty[1]);
						triggered = true;

					}else if(gc.mushroomState[2] == 1){
                        ei.startEffects(gc.mushroomDifficulty[2]);
						triggered = true;
					}
				break;
				case 4:
					if(gc.mushroomState[3] == 1){
                        ei.startEffects(gc.mushroomDifficulty[3]);
						triggered = true;
					}else if(gc.mushroomState[4] == 1){
                        ei.startEffects(gc.mushroomDifficulty[4]);
						triggered = true;
					}else if(gc.mushroomState[5] == 1){
                        ei.startEffects(gc.mushroomDifficulty[5]);
						triggered = true;
					}
				break;
			}
		}else if(lvl == 5){
			int mushCount = 0;
			for(int i = 0; i < 6; i++){
				if(gc.mushroomState[i] == 1){
					mushCount++;
				}
			}
			if(mushCount == 6){
				gc.startLevel(0);
			}
		}
	}
}
