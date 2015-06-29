using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

using UnityOSC;

public class OSCConnection : MonoBehaviour
{
    public string ServerName = "PD-in";
    public int serverIP = 5000;
    public Transform sphere;
    public Vector3 offset;
    public float multiplier = 10;

    private OSCServer server;
    private Vector3 acc;


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
        sphere.localScale = new Vector3((acc.x * multiplier)+1, (acc.y * multiplier)+1, (acc.z * multiplier)+1);
        
    }

    private void OnPacketReceivedEvent(OSCServer sender, OSCPacket packet)
    {
        // Send something from PureData and it shows up in the Unity console
        if (packet.Address.StartsWith("/muse/elements/experimental/concentration"))
        {
        	acc = new Vector3((float) packet.Data[0], (float) packet.Data[0], (float) packet.Data[0]);
            Debug.Log(acc);
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
