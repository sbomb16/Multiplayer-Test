using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public GameObject player;

    private Rigidbody playerRigidbody;

    private Camera playerCam;

    private float horizontalAxis;
    private float verticalAxis;

    private Vector3 camForward;
    private Vector3 camSideways;
    private Vector3 playerFront;
    private Vector3 jumpForce;

    private float playerMaxSpeed = 7.5f;

    public bool isJumping = false;
    public bool canDBJump = false;
    
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");

        playerRigidbody = player.GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        jumpForce = new Vector3(0, 5, 0);
	}    

    // Update is called once per frame
    void FixedUpdate () {

        PlayerOneMovement();

    }    

    private void PlayerOneMovement()
    {

        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(horizontalAxis, 0f, verticalAxis) * playerMaxSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            StartCoroutine(Jump());

            Debug.Log(isJumping);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping && canDBJump)
        {
            playerRigidbody.AddForce(jumpForce, ForceMode.Impulse);

            canDBJump = false;
        }
    }

    IEnumerator Jump()
    {
        playerRigidbody.AddForce(jumpForce, ForceMode.Impulse);

        isJumping = true;

        yield return new WaitForSeconds(.25f);

        canDBJump = true;
    }
}
