using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public Camera cam;              // Player camera
    public LayerMask ground;        // Ground identifier
    public float gravity;           // Gravity value
    public int jumpFrames;          // Duration of a jump (frames)
    public float jumpSpeed;         // Speed of jump
    public float moveSpeed;         // Speed of normal movements
    public float sensitivityX = 2f; // Sensitivity of mouse horizontal movement effect
    public float sensitivytyY = 2f; // Sensitivity of mouse vertical movement effect

    // Keywords for key-pressed input
    string getX;
    string getY;
    string getZ;

    // Movement controllers and modifiers
    CharacterController controller;
    Vector3 move = Vector3.zero;
    Vector3 rotate = Vector3.zero;
    int cont = 0;

    [SerializeField] MouseLook mouseLook;   // Mouse controller -- combines movements of player and camera
    

    bool isGrounded()
    {
        return Physics.CheckSphere(transform.GetChild(0).position, transform.localScale.y + 0.2f, ground, QueryTriggerInteraction.Ignore);
    }
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mouseLook.Init(transform, cam.transform);
        mouseLook.MaximumX = 60;
        mouseLook.MinimumX = -60;

        getX = "Horizontal-" + name;
        getY = "Jump-" + name;
        getZ = "Vertical-" + name;
    }

    // Update position and rotation
    private void FixedUpdate()
    {
        controller.Move((transform.forward * move.z + transform.right * move.x + transform.up * move.y) * Time.deltaTime);
        controller.transform.Rotate(rotate * Time.deltaTime);
    }
    
    void Update()
    {
        //Keyboard input
        move.x = Input.GetAxis(getX) * moveSpeed;
        move.z = Input.GetAxis(getZ) * moveSpeed;

        if (cont != 0)
            cont--;

        else if (isGrounded())
        {
            // Check for jump input
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
        mouseLook.LookRotation(transform, cam.transform);
    }
}