using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

using UnityOSC;

public class MuseInterface : MonoBehaviour
{
    public string ServerName = "PD-in";
    public int serverIP = 5000;
    public MessageManager manager;

    private OSCServer server;


    private void Awake()
    {
        OSCHandler.Instance.CreateServer(ServerName, serverIP);

        var pd = OSCHandler.Instance.Servers[ServerName];
        server = pd.server;
        Debug.Log("OSC: "+server);
               
    }

    private void OnEnable()
    {
        server.PacketReceivedEvent += OnPacketReceivedEvent;
    }

    private void OnDisable()
    {
        server.PacketReceivedEvent -= OnPacketReceivedEvent;

    }

    private void Update()
    {
        //sphere.localPosition = (acc + offset) * multiplier;
        //sphere.localScale = new Vector3((acc.x * multiplier)+1, (acc.y * multiplier)+1, (acc.z * multiplier)+1);
        
    }

    private void OnPacketReceivedEvent(OSCServer sender, OSCPacket packet)
    {
        // Send something from PureData and it shows up in the Unity console
        if (packet.Address.StartsWith("/muse/elements/experimental/concentration"))
        {
        	manager.message(ServerName, "concentration",packet.Data[0]);
        }else if(packet.Address.StartsWith("/muse/elements/blink")){
            manager.message(ServerName, "blink", packet.Data[0]);
        }else if(packet.Address.StartsWith("/muse/elements/touching_forehead")){
            manager.message(ServerName, "touching", packet.Data[0]);
        }
        //Debug.Log(packet.Address + ": " + DataToString(packet.Data));

    }
    public static string DataToString(List<object> data)
	{
		var buffer = "";
		
		for (int i = 0; i < data.Count; i++)
		{
			buffer += data[i] + " ";
		}
		
		return buffer;
	}
}
