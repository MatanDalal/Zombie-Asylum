using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity = 0.1f;

    private float verticalRotation = 0f;
    private bool canLook = false;

    private void Update()
    {
        if (!canLook || Mouse.current == null)
        {
            return;
        }

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(
            verticalRotation,
            -90f,
            90f
        );

        transform.localRotation =
            Quaternion.Euler(verticalRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void SetLookEnabled(bool enabled)
    {
        canLook = enabled;

        if (enabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}