using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

    //private const float Y_ANGLE_MIN = 17f;
    //private const float Y_ANGLE_MAX = 17f;

    //private const float X_ANGLE_MIN = -100f;
    //private const float X_ANGLE_MAX = 100f;

    private Transform lookAt;
    private Transform camTransform;

    private Camera cam;

    private float distance = 3;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    //private float sensitivityX = 4.0f;
    //private float sensitivityY = 1.0f;

    private Vector3 cam_Position;
    

    private void Start()
    {
        camTransform = transform;
        lookAt = gameObject.transform.GetChild(0);

        Debug.Log(lookAt);

        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        //currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        //currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        //Debug.Log(rotation);

        cam_Position = lookAt.position + rotation * dir;
        //Debug.Log(lookAt.position);
        camTransform.position = cam_Position;
        //Debug.Log(cam_Position);
        camTransform.LookAt(lookAt.position);
    }
}
