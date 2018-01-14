using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerCube : MonoBehaviour
{
    public GameObject plane;    // Plane field with cube above
    public GameObject cube;     // Cube to move
    
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player"))
        {
            for(int i = 0; i < plane.transform.localScale.x; i++)   // consider man-hole instead
                plane.transform.position += plane.transform.right;

            cube.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
