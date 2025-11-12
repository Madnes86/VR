using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float elevationSpeed = 3f;
    
    private Vector2 rotation = Vector2.zero;
    private Vector2 moveInput;
    private bool rightMouseDown;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (rightMouseDown)
        {
            Vector2 lookInput = context.ReadValue<Vector2>();
            rotation.x += lookInput.x * mouseSensitivity;
            rotation.y += lookInput.y * mouseSensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);
            transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);
        }
    }

    public void OnRightMouse(InputAction.CallbackContext context)
    {
        rightMouseDown = context.ReadValueAsButton();
        Cursor.lockState = rightMouseDown ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void OnElevate(InputAction.CallbackContext context)
    {
        float elevateInput = context.ReadValue<float>();
        transform.position += Vector3.up * elevateInput * elevationSpeed * Time.deltaTime;
    }

    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            transform.position = new Vector3(0, 1, 0);
            rotation = Vector2.zero;
            transform.localEulerAngles = Vector3.zero;
        }
    }

    void Update()
    {
        // Движение WASD
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}