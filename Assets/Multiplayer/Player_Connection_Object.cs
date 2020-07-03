//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;

//public class Player_Connection_Object : NetworkBehaviour {

//	// Use this for initialization
//	void Start () {

//        if(isLocalPlayer == false)
//        {
//            return;
//        }

//        Debug.Log("PlayerObject::Start -- Spawning my own personal unit.");

//        //Instantiate() only creates an object on the LOCAL COMPUTER.
//        //Even if it has a NetworkIdentity it still will not exist on 
//        //the network(and therefore not on any other client) UNLESS
//        //NetworkServer.Spawn() is called on this object.

//        //Instantiate(PlayerUnitPrefab);

//        //Command the server to SPAWN our playerunit

//        CmdSpawnMyUnit();

//	}

//    public GameObject PlayerUnitPrefab;

//    [SyncVar(hook="OnPlayerNameChanged")]
//    public string PlayerName = "Anonymous";
	
//	// Update is called once per frame
//	void Update () {
//        //Remember: Update runs on EVERYONE's computer, regardless if
//        //it's their character or not
//        if (isLocalPlayer == false)
//        {
//            return;
//        }

//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            CmdSpawnMyUnit();
//        }

//        if (Input.GetKeyDown(KeyCode.Return))
//        {
//            string n = "Cool Man" + Random.Range(1, 100);

//            CmdChangePlayerName(n);
//        }

//    }

//    void OnPlayerNameChanged(string newName)
//    {
//        Debug.Log("OnPlayerNameChanged: OldName: " + PlayerName + " NewName: " + newName);

//        PlayerName = newName;

//        gameObject.name = "PlayerConnectionObject [" + newName + "]";
//    }
//    //COMMANDS
//    //Commands are apecial functions that ONLY get executed by the server

//    [Command]
//    void CmdSpawnMyUnit()
//    {
//        //We are guaranteed to be on the server right now
//        GameObject go = Instantiate(PlayerUnitPrefab);

//        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
//        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
//        //Now that the object exists on the server, propagate it to all the clients and also wire up the network identity
//        //NetworkServer.Spawn(go);
//    }

//    [Command]
//    void CmdChangePlayerName(string n)
//    {
//        Debug.Log("CmdChangePlayerName: " + n);

//        PlayerName = n;

//        //RpcChangePlayerName(PlayerName);
//    }

//    //RCS
//    //RPCs are special functions that ONLY getexecuted on the clients

//    //[ClientRpc]
//    //void RpcChangePlayerName(string n)
//    //{
//    //    Debug.Log("RpcChangePlayerName: We were asked to change the player name or a particular PlayerConnectionObject: " + n);
//    //    PlayerName = n;
//    //}
//}

