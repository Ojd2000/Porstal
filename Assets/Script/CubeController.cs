using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float timeSpan = .5f;    // Time span between E keys detection

    Vector3 fullSize;       // Cube initial size
    Vector3 spawn;          // Cube spawn position
    float time = -.5f;      // Last at-frame-beginning time

    void Start()
    {
        fullSize = transform.localScale;
        spawn = transform.position;
        time = -timeSpan;
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player") && Time.time - time > timeSpan)
        {
            time = Time.time;
            if (transform.parent)
            {
                transform.parent = null;
                transform.GetComponent<Rigidbody>().isKinematic = false;
                transform.GetComponent<Rigidbody>().useGravity = true;
                transform.localScale = fullSize;
            }

            else
            {
                transform.parent = other.gameObject.transform;
                transform.position = other.gameObject.transform.position + transform.up + transform.forward * 2;
                transform.rotation = other.gameObject.transform.rotation;
                transform.GetComponent<Rigidbody>().isKinematic = true;
                transform.localScale = new Vector3(fullSize.x / other.transform.localScale.x, fullSize.y / other.transform.localScale.y, fullSize.z / other.transform.localScale.z) / 3;    // scale size (fullsize : localScale : x = 3 : 4 : 0.25)
            }
        }
    }

    public void Respawn()
    {
        transform.position = spawn;
        transform.parent = null;
        transform.localScale = fullSize;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
