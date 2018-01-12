using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [HideInInspector] public static Color currentColor;
    [HideInInspector] public static Dictionary<Color, GameObject> portals = new Dictionary<Color, GameObject>();
    
    private Image image;    // Displayed image
    private Sprite other;   // Alternative sprite
    
    void Start()
    {
        currentColor = Color.green;
        image = GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("crosshair-green");
        other = Resources.Load<Sprite>("crosshair-red");
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // Swap sprites
            Sprite tmp = image.sprite;
            image.sprite = other;
            other = tmp;
            currentColor = currentColor == Color.green ? Color.red : Color.green;
        }
    }
}
