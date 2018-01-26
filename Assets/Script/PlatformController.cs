using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = .5f;

    short direction = 1;
    float mostLeft = 2.98f;
    float mostRight = 38.68f;
    
    void FixedUpdate()
    {
		if (transform.position.z <= mostLeft || transform.position.z >= mostRight)
			direction *= -1;

		transform.position += Vector3.forward * speed * direction;
    }
	
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = transform;
	}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}
