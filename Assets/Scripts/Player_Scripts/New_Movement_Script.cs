using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Movement_Script : MonoBehaviour
{
    public CharacterController playerController;

    public float playerSpeed = 6;

    // Update is called once per frame
    void Update()
    {

        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        Vector3 playerMovement = new Vector3(horizontalAxis, 0f, verticalAxis).normalized;

        //if(playerMovement.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(playerMovement.x, playerMovement.z) * Mathf.Rad2Deg;

        //    transform.rotation = Quaternion.Euler(0, targetAngle, 0);

        //    playerController.Move(playerMovement * playerSpeed * Time.deltaTime);
        //}

    }
}
