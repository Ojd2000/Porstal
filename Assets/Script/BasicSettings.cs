using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSettings : MonoBehaviour
{
    public bool Focused
    {
        get { return Cursor.lockState == CursorLockMode.Locked; }
        set { Cursor.lockState = Focused ? CursorLockMode.Locked : CursorLockMode.None; }
    }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
            Cursor.visible = true;

        else if (Cursor.lockState == CursorLockMode.None && Input.GetKeyDown(KeyCode.Return))
            Cursor.visible = false;
    }
}
