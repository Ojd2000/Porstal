using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject portal;   // Portal prefab

    Color bulletColor;

    void Start()
    {
        bulletColor = GetComponent<Renderer>().material.color = CrosshairController.currentColor;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PortalWall"))
        {
            if (PortalController.portals.ContainsKey(bulletColor))
                Destroy(PortalController.portals[bulletColor]);

            if (OtherPortalArea())
                Destroy(PortalController.portals[bulletColor == CrosshairController.Red ? CrosshairController.Green : CrosshairController.Red]);

            var p = Instantiate(portal, new Vector3(transform.position.x, transform.position.y, collision.transform.position.z - portal.transform.localScale.z), collision.gameObject.transform.rotation);
            p.GetComponent<Renderer>().material.color = bulletColor;
            p.transform.parent = collision.transform;
            PortalController.portals[bulletColor] = p;
        }

        Destroy(gameObject);
    }

    bool OtherPortalArea()
    {
        //if (PortalController.portals.ContainsKey(bulletColor == CrosshairController.Red ? CrosshairController.Green : CrosshairController.Red))
        //{

        //}

        return false;
    }
}
