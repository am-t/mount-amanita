using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {

	public GameController gc;
	public int lvl;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 4; i++){
			if(lvl > 1 && i == (lvl-2)) {
				gc.LEDLights(i,1);
			}else{
				gc.LEDLights(i,0);
			}
		}
	}

}
