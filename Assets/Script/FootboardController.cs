using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootboardController : MonoBehaviour
{
    public GameObject door;             // Door to open
    public GameObject otherFootboard;   // The other footboard

    bool triggered = false;

    void Start()
    {
    }
    
    void Update()
    {
        if (triggered && otherFootboard.GetComponent<FootboardController>().Triggered)
            door.GetComponent<DoorController>().Open();
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
