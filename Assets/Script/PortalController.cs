using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [HideInInspector] public static Dictionary<Color, GameObject> portals = new Dictionary<Color, GameObject>();

    public static float timeSpan = 1.5f;    // Time span between teleports
    
    static float time = -1.5f;     // Last at-frame-beginning time
    
    void OnTriggerStay(Collider collision)
    {
        if (portals.Count == 2 && collision.tag.Equals("Player") && Time.time - time > timeSpan)
        {
            time = Time.time;
            collision.transform.position = portals[
                GetComponent<Renderer>().material.color == CrosshairController.Green ? CrosshairController.Red : CrosshairController.Green
                ].transform.position;
        }
    }
}
