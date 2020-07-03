using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pickup : MonoBehaviour {

    public Player_Movement playerMovement;

    public GameObject itemClosestTo;
    public GameObject Player;

    public bool canPickUp = false;

    public string itemName;

    public float itemPreviousSizeValue;
    public float itemNextSizeValue;

    // Use this for initialization
    void Start () {

        Player = GameObject.Find("Player");

        playerMovement = Player.GetComponent<Player_Movement>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            canPickUp = true;

            itemClosestTo = other.transform.parent.gameObject;

            itemName = itemClosestTo.gameObject.name + "_Mesh";

            itemPreviousSizeValue = itemClosestTo.GetComponent<Item_Size>().itemPreviousSize;

            itemNextSizeValue = itemClosestTo.GetComponent<Item_Size>().itemNextSize;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canPickUp = false;
    }
}
