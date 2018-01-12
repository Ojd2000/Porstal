﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool isOpen = false;
    
    void Start()
    {
    }
    
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cube"))
            other.GetComponent<CubeController>().Respawn();
    }

    void OnTriggerExit(Collider other)  // Does not work
    {
        if (other.CompareTag("Player"))
            Close();
    }

    public void Open()
    {
        if (!isOpen)
        {
            transform.position += Vector3.forward * -11;
            isOpen = true; 
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            transform.position -= Vector3.forward * -11;
            isOpen = false; 
        }
    }

    public bool IsOpen { get { return isOpen; } }
}
