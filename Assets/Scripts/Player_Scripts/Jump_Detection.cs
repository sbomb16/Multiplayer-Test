using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Detection : MonoBehaviour
{

    private Player_Movement playerMovement;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        playerMovement = Player.GetComponent<Player_Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {

            playerMovement.isJumping = false;
            playerMovement.canDBJump = false;

        }
    }
}
