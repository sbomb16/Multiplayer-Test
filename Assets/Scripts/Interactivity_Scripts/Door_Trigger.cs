using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger : MonoBehaviour
{
    private GameObject doorObject;

    public bool doorCanOpen;
    public bool isKeyDoor;

    // Start is called before the first frame update
    void Start()
    {
        if (isKeyDoor)
        {
            doorObject = transform.Find("Key_Door_Mesh").gameObject;
        }
        else
        {
            doorObject = transform.Find("Door_Mesh").gameObject;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && doorCanOpen == true)
        {
            Debug.Log("Attempting to open");
            StartCoroutine(MoveDoorUp());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && doorCanOpen == true)
        {
            Debug.Log("Attempting to close");
            StartCoroutine(MoveDoorDown());
        }
    }

    IEnumerator MoveDoorUp()
    {
        float raised = .1f;
        for (float i = 0; i < 1f; i += 0.05f)
        {

            doorObject.transform.position = new Vector3(doorObject.transform.position.x, doorObject.transform.position.y + raised, doorObject.transform.position.z);
            yield return new WaitForSeconds(.005f);

        }
    }

    IEnumerator MoveDoorDown()
    {
        float dropped = .1f;
        for (float i = 0; i < 1f; i += 0.05f)
        {

            doorObject.transform.position = new Vector3(doorObject.transform.position.x, doorObject.transform.position.y - dropped, doorObject.transform.position.z);
            yield return new WaitForSeconds(.005f);

        }
    }
}
