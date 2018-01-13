using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGroundController : MonoBehaviour {

    public float speed = .5f;

    System.Int16 direction = 1;
    float mostLeft;
    float mostRight;
    bool playerOnTop = false;
	
    // Use this for initialization
	void Start () {
        mostLeft = 2.98f;
        mostRight = 38.68f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (transform.position.z <= mostLeft || transform.position.z >= mostRight)
            direction *= -1;
        transform.position += Vector3.forward * speed * direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;
            other.gameObject.GetComponent<PlayerController>().onMovingObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
            other.gameObject.GetComponent<PlayerController>().onMovingObject = false;
        }
    }
}
