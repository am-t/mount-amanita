using UnityEngine;
using UnityEngine.EventSystems;


public interface ICustomMessageTarget : IEventSystemHandler
{
    // functions that can be called via the messaging system
    void message(string id, string m, object val); 
}

public class MessageManager : MonoBehaviour, ICustomMessageTarget
{
    public void message(string id, string m, object val)
    {
        switch(m){
        	case "concentration":
        		Debug.Log (id + " " + m + " " + val);
        	break;
        	case "blink":
        		Debug.Log (id + " " + m + " " + val);
        	break;
        	case "touching":
        		Debug.Log (id + " " + m + " " + val);
        	break;
        	default:
        		Debug.Log (id + " " + m + " " + val);
        	break;
        }
    }
}