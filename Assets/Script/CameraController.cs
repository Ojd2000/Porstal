using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minY = -60f;           // Lower Y position for the camera to look (degrees)
    public float maxY = 60f;            // Higher Y position for the camera to look (degrees)
    public float sensitivityX = 1f;     // Sensitivity of mouse horizontal movement effect
    public float sensitivityY = 1f;     // Sensitivity of mouse vertical movement effect

    // Get game settings reference
    private BasicSettings settings;

    private float rotationX = 0f;       // rotation along Y axis
    private float rotationY = 0f;       // rotation along X axis

    private void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<BasicSettings>();
    }

    private void Update()
    {
        if (settings.Focused)
        {
            rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY = Mathf.Clamp(rotationY + Input.GetAxis("Mouse Y") * sensitivityY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0); 
        }
    }
}
