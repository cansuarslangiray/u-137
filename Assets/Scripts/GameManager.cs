using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count == 2)
        {
            players[0].GetComponent<PlayerMovement>().target = players[1];
            players[1].GetComponent<PlayerMovement>().target = players[0];
        }
        
    }
}
