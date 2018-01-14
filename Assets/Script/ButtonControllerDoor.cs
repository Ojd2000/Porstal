using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerDoor : MonoBehaviour
{
    public GameObject door;     // Door to move
    
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player"))
            door.GetComponent<DoorController>().Open();
    }
}
