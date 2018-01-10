using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public LayerMask ground;
    public int jumpTime;
    public float jumpSpeed;
    public float moveSpeed;
    public float gravity;
    public float sensitivityX;
    public float sensitivityY;

    string getX;
    string getY;
    string getZ;
    CharacterController controller;

    Vector3 move = Vector3.zero;
    Vector3 rotate = Vector3.zero;
    int cont = 0;

    bool isGrounded()
    {
        return Physics.CheckSphere(transform.GetChild(0).position, 4.2f, ground, QueryTriggerInteraction.Ignore);
    }

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

        getX = "Horizontal-" + name;
        getY = "Jump-" + name;
        getZ = "Vertical-" + name;

    }

    private void FixedUpdate()
    {
        controller.Move(move * Time.deltaTime);

        //cam.transform.localEulerAngles.y += rotate.y;
    }

    // Update is called once per frame
    void Update()
    {

        //Keyboard input
        move.x = Input.GetAxis(getX) * moveSpeed;
        move.z = Input.GetAxis(getZ) * moveSpeed;

        if (cont != 0)
        {
            move.y = jumpSpeed;
            cont--;
        }

        else if (isGrounded())
        {
            if (Input.GetButton(getY))
                cont = jumpTime;

            else
                move.y = 0;
        }
        else
        {
            move.y = -gravity;
        }

        //Mouse input
        rotate.y = Input.GetAxis("Mouse X")*sensitivityY;
        rotate.x = -Input.GetAxis("Mouse Y")*sensitivityX;
    }
}