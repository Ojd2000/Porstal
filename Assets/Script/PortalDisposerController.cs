using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDisposerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var v in PortalController.portals)
                Destroy(v.Value);

            PortalController.portals.Clear();
        }
    }
}
