using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	ISSUES

	If a cube falls out of the game field, its movements must be reset to respawn it in spawn position (*)
	 
	 */

public class CubeController : MonoBehaviour
{
	public float timeSpan = .05f;    // Time span between E keys detection

	Vector3 fullSize;           // Cube initial size
	Vector3 spawn;              // Cube spawn position
	float time = -.5f;          // Last at-frame-beginning time
	bool fallen = false;		// If fallen from spawn	-- temporary (*)

	void Start()
	{
		fullSize = transform.localScale;
		spawn = transform.position;
		time = -timeSpan;
	}

	void Update()
	{
		if (transform.position.y < -37)
			Respawn();
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
				transform.parent = other.transform;
				transform.position = other.transform.position + transform.up + transform.forward * 2;
				transform.rotation = other.transform.rotation;
				transform.GetComponent<Rigidbody>().isKinematic = true;
				transform.localScale = new Vector3(fullSize.x / other.transform.localScale.x, fullSize.y / other.transform.localScale.y, fullSize.z / other.transform.localScale.z) / 3;    // scale size (fullsize : localScale : x = 3 : 4 : 0.25)
				transform.position = other.transform.position + transform.up + transform.forward * 2;
				transform.rotation = other.transform.rotation;
			}
		}
		else if (!fallen && other.gameObject.layer == LayerMask.NameToLayer("Ground"))	// temporary (*)
		{
			fallen = true;
			spawn = transform.position;
		}
	}

	public void Respawn()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		
		transform.position = spawn;
		transform.parent = null;
		transform.localScale = fullSize;
		rb.isKinematic = false;
		rb.velocity = new Vector3(0, rb.velocity.y, 0);
	}
}
