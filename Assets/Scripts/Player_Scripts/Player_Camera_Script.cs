using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Script : MonoBehaviour
{

    private GameObject playerObject, camTarget;    

    private float mouseX, mouseY;

    public float rotationSpeed = 2;

    // Use this for initialization
    void Start () {
        
        playerObject = GameObject.Find("Player");

        camTarget = GameObject.Find("Player_Camera_Target");

	}
    
	// Update is called once per frame
	void LateUpdate () {

        CamControl();

    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.LookAt(camTarget.transform);

        playerObject.transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
