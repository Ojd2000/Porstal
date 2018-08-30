using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootboardControllerPlatform : MonoBehaviour
{
    public GameObject platform;             // Door to open
    public GameObject otherFootboard;   // The other footboard

	bool moving = false;
    bool triggered = false;
    
    void Update()
    {
		if (triggered && !moving && otherFootboard.GetComponent<FootboardControllerPlatform>().Triggered)
		{
			platform.GetComponent<PlatformController>().speed = 0.2f;
			platform.GetComponent<PlatformController>().Start();

			moving = true;
		}
    }

    void OnTriggerStay(Collider other)
    {
        triggered = other.CompareTag("Cube") || other.CompareTag("Player");
    }

    void OnTriggerExit(Collider other)
    {
        triggered = false;
    }

    public bool Triggered { get { return triggered; } }
}
