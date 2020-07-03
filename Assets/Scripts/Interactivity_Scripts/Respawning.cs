using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{

    private GameObject playerRespawn;
    private GameObject itemRespawn;

    // Start is called before the first frame update
    void Start()
    {

        playerRespawn = GameObject.Find("Player_Respawn");
        itemRespawn = GameObject.Find("Item_Respawn");

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {                                   

            other.gameObject.transform.position = playerRespawn.transform.position;            

        }
        else if(other.tag == "Key" || other.tag == "Floor" || other.tag == "Item")
        {
            Debug.Log(other.gameObject);
            other.gameObject.transform.position = itemRespawn.transform.position;
        }
    }
}
