using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{

    public void MyStartHost()
    {
        StartHost();
        Debug.Log(Time.timeSinceLevelLoad + "Starting host.");
    }

    public override void OnStartHost()
    {
        Debug.Log(Time.timeSinceLevelLoad + "Host started.");
    }

    public override void OnStartClient(NetworkClient client)
    {
        Debug.Log(Time.timeSinceLevelLoad + "Client started.");
        InvokeRepeating("PrintDot", 0f, 1f);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log(Time.timeSinceLevelLoad + "Client connected to " + conn.address);
        if (IsInvoking("PrintDot")) CancelInvoke("PrintDot");
    }

    void PrintDot()
    {
        Debug.Log(".");
    }

    
}
