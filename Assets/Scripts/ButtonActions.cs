using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ButtonActions: MonoBehaviour
{
    private bool isWorkingHost;
    private NetworkManager _networkManager;


    void Start()
    {
        _networkManager = GetComponentInParent<NetworkManager>();
    }

    public void StartHost()
    {
        _networkManager.StartHost();
    }

    public void StartClient()
    {
        _networkManager.StartClient();

    }
    
}
