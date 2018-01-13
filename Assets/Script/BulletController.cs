using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject portal;   // Portal prefab

    private Color bulletColor;
    
    void Start()
    {
        bulletColor = GetComponent<Renderer>().material.color = CrosshairController.currentColor;
        Debug.Log(bulletColor);
    }
    
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PortalWall"))
        {
            if (CrosshairController.portals.ContainsKey(bulletColor))
                Destroy(CrosshairController.portals[bulletColor]);

            var p = Instantiate(portal, new Vector3(transform.position.x, transform.position.y, collision.transform.position.z - .5f), collision.gameObject.transform.rotation);
            p.GetComponent<Renderer>().material.color = bulletColor;
            p.transform.parent = collision.transform;
            CrosshairController.portals[bulletColor] = p;
        }

        Destroy(gameObject);
    }
}
