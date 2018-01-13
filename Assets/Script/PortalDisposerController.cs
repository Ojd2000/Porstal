using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDisposerController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var v in CrosshairController.portals)
                Destroy(v.Value);
            CrosshairController.portals.Clear();
        }
    }
}
