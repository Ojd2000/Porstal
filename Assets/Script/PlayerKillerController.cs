using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillerController : MonoBehaviour
{
	public GameObject canvas;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerController>().CanMove = false;
			Destroy(canvas);
		}
	}
}
