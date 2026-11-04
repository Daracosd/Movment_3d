using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Sensitivity Settings")]
    public float mouseSensitivity = 2f; // Lower default scale for GetAxisRaw
    public bool invertY = false;

    [Header("References")]
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // Force the mouse cursor to stay locked in the window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. Get raw, unfiltered mouse coordinates
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        // 2. Debug Check: If this prints 0,0 while moving the mouse, Unity isn't reading your hardware!
        if (mouseX != 0 || mouseY != 0)
        {
            Debug.Log($"Mouse moving: X={mouseX}, Y={mouseY}");
        }

        // 3. Process looking up and down
        if (invertY)
        {
            xRotation += mouseY;
        }
        else
        {
            xRotation -= mouseY;
        }

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 4. Execute rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
