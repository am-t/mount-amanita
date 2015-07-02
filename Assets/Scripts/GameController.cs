using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

	public string[] museServer;
	public int[] museStatus;
	public MessageManager mm;

    private int i;
    private bool notDetected;
    private int playerCountdown;
    private bool onPlayerCountdown;

    public float[] mushroomDifficulty;
    public int[] mushroomState;

    private float waitForMuseTime;
    private float waitForCalibrationTime;

    public float[] playerConcentration;

	// Use this for initialization
	void Start ()
	{
	    i = 0;
	    notDetected = true;
	    waitForMuseTime = 30;
	    waitForCalibrationTime = 100;

	    museServer = new string[4];
	    museStatus = new int[4];
	    mushroomState = new int[] { 1, 1, 1, 1, 1, 1};
        mushroomDifficulty = new float[6];

        playerConcentration = new float[] {0f,0f,0f,0f};

        //scriptArray = new GameObject[4];
	    
	    for(int j = 0; j < 6; j++ ){
	    	if(j == 0){
	    		mushroomDifficulty[j] = UnityEngine.Random.Range(0f,0.25f);
	    	}else if(j == 1 || j == 2){
	    		mushroomDifficulty[j] = UnityEngine.Random.Range(0.25f,0.75f);
	    	}else if(j == 3 || j == 4 || j == 5){
	    		mushroomDifficulty[j] = UnityEngine.Random.Range(0.75f,1f);
	    	}
	    }

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
            LEDLights(1, i);
	    }

	    if (Input.GetKeyDown(KeyCode.D))
	    {
            i++;
            i = i % 2;
            LEDLights(2, i);
	    }
		
		checkMuse();
	    startTimer();
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
		switch(srv){
			case "Muse_1":
				playerConcentration[0] = value;
			break;
			case "Muse_2":
				playerConcentration[1] = value;
			break;
			case "Muse_3":
				playerConcentration[2] = value;
			break;
			case "Muse_4":
				playerConcentration[3] = value;
			break;
		}
		
	}

	private void MuseTouching(string srv, int status){
		//1-0
		Debug.Log("Muse Status Changed:"  + srv + " " + status);
	}

	private void ArduinoSensor(int sensorIndex, int status){
		// sensorIndex[0-5] / status: 1-0
		Debug.Log("Arduino: " + sensorIndex + " " + status);
		mushroomState[sensorIndex] = status;
	}

	public void LEDLights(int idx, int state){
		//Call arduino to light or turn off an LED Send LED index and State idx[0-2] state: 1 on - 0 off
		mm.Lights(idx,state);
	}

	private void checkMuse(){
		if(notDetected){
			for(int i = 0 ; i < 4 ; i++){
				if(museStatus[i] != 0) {
					notDetected = false;
					startTimer();
				};
			}
		}
	}

	private void startTimer()
	{
	    waitForMuseTime -= Time.deltaTime;
        Debug.Log("Wait time left for players to log on is: " + waitForMuseTime);
	    if (waitForMuseTime <= 0)
	    {
	        startTutorial();
	    }

	    for (int i = 0; i < 4; i++)
	    {
	        if (museStatus[i] == 1)
	        {
                Debug.Log("Muse " + i + "is online");
	            //means the muse at index i is on, and we need to pair it to an effect in the game
	        }
	    }
	}

	private void startTutorial() {

        //Graphical, add image -> GUI Canvas stuff
	    waitForCalibrationTime -= Time.deltaTime;
        Debug.Log("Wait time for the tutorial to end is: " + waitForCalibrationTime);
	    if (waitForCalibrationTime <= 0)
	    {
	        startLevel(1);
	    }

	}

	public void startLevel(int scene) {
		Application.LoadLevel(scene);
	}


}