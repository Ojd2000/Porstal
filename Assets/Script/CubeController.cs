using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject player;       // Player who is parent of the cube --- consider make more generic
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

    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player") && Time.time - time > timeSpan)
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
                transform.parent = player.transform;
                transform.GetComponent<Rigidbody>().isKinematic = true;
                transform.rotation = player.transform.rotation;
                transform.position = player.transform.position + transform.up + transform.forward * 2;

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
