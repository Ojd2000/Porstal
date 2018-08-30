using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootboardController : MonoBehaviour
{
    bool triggered = false;
    
    void OnTriggerEnter(Collider other)
    {
        triggered = other.CompareTag("Cube") || other.CompareTag("Player");
    }

    void OnTriggerExit(Collider other)
    {
        triggered = false;
	}

    public bool Triggered { get { return triggered; } }
}
