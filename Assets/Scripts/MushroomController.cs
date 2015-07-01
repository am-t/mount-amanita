using UnityEngine;
using System.Collections;

public class MushroomController : MonoBehaviour {

	public GameController gc;
	public int lvl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lvl > 1 && lvl < 5){
			//check if a mushroom was picked up
			//depending on level
			switch(lvl){
				case 2:
					if(gc.mushroomState[0] == 1){
						
					}
				break;
				case 3:
				break;
				case 4:
				break;
			}
		}else if(lvl == 5){

		}
	}
}
