using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public Camera cam;
    public LayerMask ground;            // Ground identifier
    public int jumpFrames = 20;         // Duration of a jump in frames
    public float jumpSpeed = 9.8f;      // Speed of the jump (Y movement)
    public float moveSpeed = 50;        // Speed of X and Z movements
    public float gravity = 9.8f;        // Gravity
    public float sensitivityX = 1f;     // Sensitivity of mouse horizontal movement effect
    public float sensitivityY = 1f;     // Sensitivity of mouse vertical movement effect

    // Get game settings reference
    private BasicSettings settings;// = GameObject.Find("Settings").GetComponent<BasicSettings>();

    // Keywords for key-pressed input
    private string getX;
    private string getY;
    private string getZ;

    // Movement controllers and modifiers
    private CharacterController controller;
    private Vector3 move = Vector3.zero;
    private Vector3 rotate = Vector3.zero;
    private int cont = 0;

    /// <summary>
    /// Checks wheter the player object is on the ground.
    /// </summary>
    /// <returns>True only if under the player object there is a ground-layered object, false otherwise.</returns>
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.GetChild(0).position, transform.lossyScale.y + 0.2f, ground, QueryTriggerInteraction.Ignore);
    }

    private void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<BasicSettings>(); ;

        controller = GetComponent<CharacterController>();

        getX = "Horizontal-" + name;
        getY = "Jump-" + name;
        getZ = "Vertical-" + name;
    }

    private void FixedUpdate()
    {
        if (settings.Focused)
        {
            controller.Move(move * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, rotate.y, 0);
        }
    }

    private void Update()
    {
        if (settings.Focused)
        {
            //Keyboard input
            move.x = Input.GetAxis(getX) * moveSpeed;
            move.z = Input.GetAxis(getZ) * moveSpeed;

            if (cont != 0)
                cont--;

            else if (IsGrounded())
            {
                if (Input.GetButton(getY))
                {
                    cont = jumpFrames;
                    move.y = jumpSpeed;
                }

                else
                    move.y = 0;
            }

            else
                move.y = -gravity;

            //Mouse input
            rotate.y = Input.GetAxis("Mouse X") * sensitivityY;
            rotate.x = -Input.GetAxis("Mouse Y") * sensitivityX;
        }
    }
}