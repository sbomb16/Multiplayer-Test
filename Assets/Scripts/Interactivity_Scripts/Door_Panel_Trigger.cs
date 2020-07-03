using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Panel_Trigger : MonoBehaviour {

    private Door_Trigger doorTrigger;

    private GameObject doorTriggerObject;
    private GameObject doorPanelObject;

    public float keysRequired;

	// Use this for initialization
	void Start () {

        doorTriggerObject = GameObject.Find("Key_Door_Trigger");
        doorPanelObject = GameObject.Find("Key_Door_Panel");

        doorTrigger = doorTriggerObject.GetComponent<Door_Trigger>();        

        doorPanelObject.GetComponent<Renderer>().material.color = Color.red;

    }

    //private float doorMover = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key")
        {
            GameObject tempKey = other.gameObject.transform.parent.gameObject;
            Destroy(tempKey);

            keysRequired--;

            if(keysRequired == 0)
            {
                doorTrigger.doorCanOpen = true;

                doorPanelObject.GetComponent<Renderer>().material.color = Color.green;

            }
        }
    }
}
