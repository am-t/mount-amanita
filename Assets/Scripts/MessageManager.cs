using UnityEngine;
using UnityEngine.EventSystems;
using System;

public interface ICustomMessageTarget : IEventSystemHandler
{
    // functions that can be called via the messaging system
    void message(string id, string m, object val); 
}

public class MessageManager : MonoBehaviour, ICustomMessageTarget
{
	public GameController gc;
	public ArduinoSerialInterface arduino;

    public void message(string id, string m = null, object val = null)
    {
        string sm = id + " " + m + " " + val;
        sm.Trim();
		gc.ParseMessage(sm);
    }

    public void Lights (int idx, int state){
    	arduino.SendState(idx,state);
    }
}