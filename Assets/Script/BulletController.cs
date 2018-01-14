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
            Color otherColor = bulletColor == CrosshairController.Red ? CrosshairController.Green : CrosshairController.Red;

            if (OtherPortalArea(otherColor))    // No overlapping portals
            {
                Destroy(PortalController.portals[otherColor]);
                PortalController.portals.Remove(otherColor);
            }

            if (PortalController.portals.ContainsKey(bulletColor))  // No copies of the same portal
                Destroy(PortalController.portals[bulletColor]);

            var p = Instantiate(portal, transform.position, collision.transform.rotation);
            p.GetComponent<Renderer>().material.color = bulletColor;
            p.transform.parent = collision.transform;
            PortalController.portals[bulletColor] = p;
        }

        Destroy(gameObject);
    }

    bool OtherPortalArea(Color otherColor)
    {
        var pc = PortalController.portals as Dictionary<Color, GameObject>;

        /*
         * Consider the space stretched in order to transform ellipsis to circles of ray = major axis.
         * Then, if the distance between the centers of the two circles is lower than or equal to the double ray, there is interception.
         * 
         * So:
         *  • check existance of an otherColor portal
         *  • get major axis
         *  • stretch of (major axis / minor axis) value
         *  • calculate distance between centers of the circles and check it
         */

        if (pc.ContainsKey(otherColor) &&
            (portal.transform.localScale.y >= portal.transform.localScale.x
                && Mathf.Pow(portal.transform.localScale.y / portal.transform.localScale.x, 2) * Mathf.Pow(pc[otherColor].transform.position.x - transform.position.x, 2) + Mathf.Pow(pc[otherColor].transform.position.y - transform.position.y, 2) <= Mathf.Pow(portal.transform.localScale.y, 2)
            || portal.transform.localScale.y < portal.transform.localScale.x
                && Mathf.Pow(pc[otherColor].transform.position.x - transform.position.x, 2) + Mathf.Pow(portal.transform.localScale.x / portal.transform.localScale.y, 2) * Mathf.Pow(pc[otherColor].transform.position.y - transform.position.y, 2) <= Mathf.Pow(portal.transform.localScale.x, 2)))

            return true;

        return false;
    }
}
