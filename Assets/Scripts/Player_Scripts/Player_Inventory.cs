using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour {

    public GameObject itemHeld;
    private GameObject playerObject;
    private GameObject inventoryLocation;
    private GameObject inventoryDropoff;

    private List<GameObject> inventory;

    private Player_Pickup pickUpObjects;

    private bool hasItem = false;
    private bool canDropItem = false;

    public int inventoryMode = 0;

    public float previousItemValue;
    public float nextItemValue;

    // Use this for initialization
    void Start () {

        //Find the Player, their inventory, as well as the dropoff point
        playerObject = GameObject.Find("Player");
        inventoryLocation = GameObject.Find("Player_Inventory");
        inventoryDropoff = GameObject.Find("Player_Inventory_Dropoff");

        //Gets the instance of the Player_Pickup script on the Player object
        pickUpObjects = playerObject.GetComponent<Player_Pickup>();        

        //Creates a new List of GameObjects
        inventory = new List<GameObject>();

	}

    private Vector3 itemHeldLocation = new Vector3(0, 0.75f, 0);
    // Update is called once per frame
    void Update () {

        //inventoryLocation.transform.position = playerObject.transform.position + itemHeldLocation;

        //Pick up object
        if (Input.GetKey(KeyCode.E))
        {
            //Only if I am ABLE to pick things up
            if(pickUpObjects.canPickUp == true && inventorySize != 2)
            {
                StartCoroutine(PickUpObject());               
            }
        }

        //Drops the most recent object picked up
        if (Input.GetKey(KeyCode.Q))
        {
            //Only if I HAVE at least one item in hand
            if(hasItem == true && canDropItem == true)
            {
                DropObjectHeld();
            }
        }

        //Switches between hroizontal and vertical mode
        if (Input.GetKey(KeyCode.F))
        {
            InventoryModes();
        }
	}

    public int inventorySize = -1;
    public float inventoryHeight = 1.30f;
    //This function allows the player to pick up an object.
    IEnumerator PickUpObject()
    {
        //Finds the object you're wanting to pick up.
        itemHeld = GameObject.Find(pickUpObjects.itemName);
        
        //Sets the height for the next item to be when it's picked up.
        nextItemValue = pickUpObjects.itemNextSizeValue;
        
        //If the inventory is initially empty, increase its height.
        if (inventorySize == -1)
        {
            inventoryHeight += 0.5f;
        }
        //If the inventory already has an object, increase the height
        //using the previous and next item values.
        else
        {
            inventoryHeight += 0.5f + previousItemValue + nextItemValue;
        }

        //Sets the previous item value.
        previousItemValue = pickUpObjects.itemPreviousSizeValue;

        //Instantiates the item being picked up into the inventory and
        //places it into its space in the inventory.
        itemHeld = Instantiate(itemHeld, inventoryLocation.transform);
        itemHeld.transform.position = new Vector3(itemHeld.transform.position.x, inventoryHeight, itemHeld.transform.position.z);
        
        //Adds the newly picked up item into the inventory List, then
        //destroys the current instance of the item being picked up from
        //the world space.
        inventory.Add(itemHeld);
        Destroy(pickUpObjects.itemClosestTo);

        //Increases the inventory's size value.
        inventorySize++;

        //Sets the hasItem and canDropItem values to true, and sets the 
        //canPickUp boolean from the Player_Pickup script instance to
        //false.
        hasItem = true;
        pickUpObjects.canPickUp = false;
        canDropItem = true;

        //Waits for a quarter of a second to pick up a new item(needs tinkering with).
        yield return new WaitForSeconds(.25f);
    }

    //This function allows the player to drop an object.
    void DropObjectHeld()
    {
        //Sets canDropItem to false so the player doesn't drop all their items at once.
        canDropItem = false;

        //Sets the last picked up item to a temproary GameObject droppedItem, then removes
        //the "_Mesh(Clone)" portion of its name and saves that to a temp string for later.
        GameObject droppedItem = inventory[inventorySize];
        string originalItemName = droppedItem.name.Replace("_Mesh(Clone)", "");        

        //Removes the item to be dropped from the inventory GameObject List.
        inventory.Remove(droppedItem);

        //Instantiates the item to be dropped by finding it in the Prefabs folder using
        //the originalItemName set up earlier.
        droppedItem = Instantiate(Resources.Load<GameObject>("Prefabs/" + originalItemName));        
        inventoryHeight -= 0.5f - (previousItemValue - nextItemValue);
        
        //Sets the newly instantiated item's location to the Player's inventory dropoff point.
        droppedItem.transform.position = new Vector3(inventoryDropoff.transform.position.x, inventoryDropoff.transform.position.y, inventoryDropoff.transform.position.z);

        //If the inventory still has items in it, destroy the item that's being dropped from 
        //the player's inventory, then set the next item in the player's inventory to the
        //itemHeld GameObject. 
        if (inventorySize > 0)
        {
            Destroy(itemHeld);
            itemHeld = inventory[inventorySize - 1];
        }
        //If the inventory has no items left after dropping the item, just destroy its
        //inventory instance.
        else
        {
            Destroy(itemHeld);
        }        

        //Removes the "(Clone) portion of the dropped item's name, then reduce the
        //inventorySize value.
        droppedItem.name = droppedItem.name.Replace("(Clone)", "");
        inventorySize--;        

        //If the inventory has no more items in it, set the hasItem boolean to false,
        //the nextItemValue and previousItemValues to 0, and the inventoryHeight to 1.3.
        if(inventorySize == -1)
        {
            hasItem = false;
            nextItemValue = 0;
            previousItemValue = 0;
            inventoryHeight = 1.3f;
        }

        //Starts the CanDrop coroutine.
        StartCoroutine(CanDrop());
    }

    //This IEnumerator simply makes the player wait a quarter of a second to drop
    //another item.
    IEnumerator CanDrop()
    {
        //Waits a quarter of a second.
        yield return new WaitForSeconds(.25f);

        //Sets the canDropItem boolean to true.
        canDropItem = true;
    }

    void InventoryModes()
    {
        if(inventoryMode == 0)
        {
            InventoryHorizontalMode();
        }
        else if(inventoryMode == 1)
        {
            InventoryVerticalMode();
        }
    }

    void InventoryHorizontalMode()
    {

    }

    void InventoryVerticalMode()
    {

    }
}
