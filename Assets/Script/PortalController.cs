using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public static float timeSpan = 1.5f;    // Time span between teleports
    

    static float time = -1.5f;     // Last at-frame-beginning time

    void Start()
    {
    }
    
    void Update()
    {
    }

    void OnTriggerStay(Collider collision)
    {
        if (CrosshairController.portals.Count == 2 && collision.gameObject.tag.Equals("Player") && Time.time - time > timeSpan)
        {
            time = Time.time;
            collision.gameObject.transform.position = CrosshairController.portals[
                GetComponent<Renderer>().material.color == CrosshairController.PortalGreen ? CrosshairController.PortalRed : CrosshairController.PortalGreen
                ].transform.position;
            
        }
    }
}
