using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootboardTriggerController : MonoBehaviour
{
	public GameObject platform1;
	public GameObject platform2;
	public GameObject door;

	void Update()
	{
		if (platform1 != null && platform2 != null && door != null)
		{
			if (platform1.GetComponent<FootboardController>().Triggered &&
				platform2.GetComponent<FootboardController>().Triggered)
			{
				door.GetComponent<DoorController>().Open();
			}
		}
	}
}
