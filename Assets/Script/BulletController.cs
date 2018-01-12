using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject portal;   // Portal prefab
    
    void Start()
    {
        GetComponent<Renderer>().material.color = CrosshairController.currentColor;
    }
    
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PortalWall"))
        {
            if (CrosshairController.portals.ContainsKey(CrosshairController.currentColor))
                Destroy(CrosshairController.portals[CrosshairController.currentColor]);

            GameObject p = Instantiate(portal, new Vector3(transform.position.x, transform.position.y, collision.transform.position.z - .5f), collision.gameObject.transform.rotation);
            p.GetComponent<Renderer>().material.color = CrosshairController.currentColor;
            p.transform.parent = collision.transform;
            CrosshairController.portals[CrosshairController.currentColor] = p;
        }

        Destroy(gameObject);
    }
}
