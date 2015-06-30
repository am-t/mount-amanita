using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

	public string[] museServer;
	public int[] museStatus;
	public MessageManager mm;

    private int i;

	// Use this for initialization
	void Start ()
	{
	    i = 0;
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.A))
	    {
	        i++;
	        i = i%2;
	        LEDLights(0, i);
	    }

	    if (Input.GetKeyDown(KeyCode.S))
	    {
            i++;
            i = i % 2;
            LEDLights(0, i);
	    }

	    if (Input.GetKeyDown(KeyCode.D))
	    {
            i++;
            i = i % 2;
            LEDLights(0, i);
	    }
	
	}

	public void ParseMessage(string m){
		char[] delimiterChars = { ' ' };
		string[] command = m.Split(delimiterChars);
		
		if (command[0] == "arduino") {
			int srv = int.Parse(command[1]);
			int stat = int.Parse(command[2]);
			ArduinoSensor(srv,stat);
		}else{
			switch(command[1]){
				case "concentration":
					float val = float.Parse(command[2]);
					MuseConcentration(command[0],val);
				break;
				case "touching":
					int status = int.Parse(command[2]);
					int idx = Array.IndexOf(museServer,command[0]);
					if(museStatus[idx] != status){
						museStatus[idx] = status;
						MuseTouching(command[0],status);
					}
				break;
				case "blink":
					/*int stat = int.Parse(command[2]);
					MuseConnection(command[0],stat);*/
				break;
				default:
				break;
			}
		}

	}

	private void MuseBlink(string srv, int status){
		//-----
	}

	private void MuseConcentration(string srv, float value){
		//Do Stuff with Concentration values
		Debug.Log("Concentration: " + srv + " " + value);
	}

	private void MuseTouching(string srv, int status){
		//1-0
		Debug.Log("Muse Status Changed:"  + srv + " " + status);
	}

	private void ArduinoSensor(int sensorIndex, int status){
		// sensorIndex[0-5] / status: 1-0
		Debug.Log("Arduino: " + sensorIndex + " " + status);
	}

	public void LEDLights(int idx, int state){
		//Call arduino to light or turn off an LED Send LED index and State idx[0-2] state: 1 on - 0 off
		mm.Lights(idx,state);
	}

}