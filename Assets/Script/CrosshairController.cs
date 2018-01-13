using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [HideInInspector] public static Color currentColor;
    [HideInInspector] public static Dictionary<Color, GameObject> portals = new Dictionary<Color, GameObject>();
    [HideInInspector] public static Color PortalRed = new Color(0.96862745098039215686274509803922f, 0.02352941176470588235294117647059f, 0.0039215686274509803921568627451f);
    [HideInInspector] public static Color PortalGreen = new Color(0.0078431372549019607843137254902f, 0.98039215686274509803921568627451f, 0.03921568627450980392156862745098f);

    private Image image;    // Displayed image
    private Sprite other;   // Alternative sprite
    
    void Start()
    {
        currentColor = PortalGreen;
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
            currentColor = currentColor == PortalGreen ? PortalRed : PortalGreen;
        }
    }
}
