using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDisposerController : MonoBehaviour
{
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
