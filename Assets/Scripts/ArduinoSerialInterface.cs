using UnityEngine;
using System.Collections;
using System.Threading;

using System.IO.Ports;

public class ArduinoSerialInterface : MonoBehaviour {
    
    private SerialPort mySerialPort;
    public MessageManager manager; 

	Thread myThread;
	// Use this for initialization
	void Start () {
		Debug.Log(SerialPort.GetPortNames().ToString());
        mySerialPort = new SerialPort("\\\\.\\COM18");
        mySerialPort.BaudRate = 9600;
        //mySerialPort.Parity = Parity.None;
        //mySerialPort.StopBits = StopBits.One;
        //mySerialPort.DataBits = 8;
        //mySerialPort.Handshake = Handshake.None;
        //mySerialPort.RtsEnable = true;

        mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        if ( mySerialPort != null )
        {
            if ( mySerialPort.IsOpen ) // close if already open
            {
                mySerialPort.Close();
                Debug.Log ("Closed stream");
            }
            mySerialPort.Open();
            Debug.Log ("Opened stream");
        }
        else
        {
            Debug.Log ("ERROR: Uninitialized stream");
        } 
	  myThread = new Thread(new ThreadStart(GetArduino));
  	  myThread.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy (){
        mySerialPort.Close();
        Debug.Log ("Closed stream");
        myThread.Interrupt();
        myThread.Join(0);
    }

	private void GetArduino(){
	  while(myThread.IsAlive)
	  {
	      string value = mySerialPort.ReadLine();
	      sendEvent(value);	      
	  }
	 }

	private void sendEvent(string message){
		Debug.Log(message);
	}
	private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        Debug.Log("DataReceivedHandler:"+indata);
    }
    
}


 
