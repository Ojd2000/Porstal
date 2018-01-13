using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerController>().checkpoint = transform;   // Save checkpoint for player respawn

        if (other.CompareTag("Cube"))
            other.GetComponent<CubeController>().Respawn();     // Cubes cannot pass through a door
    }
}
