using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    public bool showCursor = false;

    void Update()
    {
        if (showCursor)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
