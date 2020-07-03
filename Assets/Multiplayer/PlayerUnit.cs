//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;

////A PlayerUnit is a unit controlled by a player

//public class PlayerUnit : NetworkBehaviour {

//    private Rigidbody rb;

//    private Vector3 camMovement;

//    private Vector3 playerForce;

//    private float forwardForce = 10f;

//    private float sidewayForce = 10f;

//    private Camera player_Cam;

//	// Use this for initialization
//	void Start () {

//        rb = GetComponent<Rigidbody>();

//        player_Cam = Camera.main;
//        Debug.Log(player_Cam);
//	}
	
//	// Update is called once per frame
//	void FixedUpdate () {


//        if (hasAuthority == false)
//        {
//            return;
//        }

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            this.transform.Translate(0, 1, 0);
//        }

//        camMovement.x = Input.GetAxis("Horizontal");
//        camMovement.z = Input.GetAxis("Vertical");

//        camMovement = player_Cam.transform.TransformDirection(camMovement.x, 0, camMovement.z);

//        playerForce = camMovement.normalized * forwardForce;

//        //Debug.Log(playerForce);

//        rb.AddForce(playerForce);
//        CmdUpdateVelocity(playerForce);       
        
//	}

//    [Command]
//    void CmdUpdateVelocity(Vector3 vel)
//    {
//        rb.AddForce(vel);
//        RpcUpdateVelocity(vel);
//    }

//    [ClientRpc]
//    void RpcUpdateVelocity(Vector3 vel)
//    {
//        if (hasAuthority)
//        {
//            return;
//        }

//        rb.AddForce(vel);

//    }
//}
