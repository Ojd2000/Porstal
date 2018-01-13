using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerController>().checkpoint = transform;
        if (other.CompareTag("Cube"))
            other.GetComponent<CubeController>().Respawn();
    }
}
