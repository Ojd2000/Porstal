using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerCube : MonoBehaviour
{
    public GameObject Plane;    // Plane field with cube above
    public GameObject Cube;     // Cube to move
    public GameObject Player;   // Player who presses the button

    private float time = -.5f;  // Position-update delay

    private void Start()
    {
    }

    private void Update()
    {
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && time <= Time.time - 0.5 && other.gameObject == Player)
        {
            time = Time.time;

            for(int i = 0; i < Plane.transform.localScale.x; i++)   // consider man-hole instead
                Plane.transform.position += Plane.transform.right;

            Cube.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
