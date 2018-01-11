using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    // Make public these two??
    private Image image;    // Displayed image
    private Sprite other;   // Alternative sprite

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("crosshair-green");
        other = Resources.Load<Sprite>("crosshair-red");
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // Swap sprites
            Sprite tmp = image.sprite;
            image.sprite = other;
            other = tmp;
        }
    }
}
