using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject Player;   // Player who is parent of the cube --- consider make more generic

    private float time = -3f;
    private Vector3 fullSize = Vector3.zero;

    private void Start()
    {
        fullSize = transform.localScale;
    }

    private void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && time < Time.time - 1 && other.gameObject == Player)
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
                transform.parent = Player.transform;
                transform.GetComponent<Rigidbody>().isKinematic = true;
                transform.rotation = Player.transform.rotation;
                transform.position = Player.transform.position + transform.up + transform.forward * 2;

                transform.localScale = new Vector3(.25f, .25f, .25f);   // consider using proprortions
            }
        }
    }
}
