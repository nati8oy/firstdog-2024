using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerGenericAudio : MonoBehaviour
{
    [Header("Input Action")]
    public InputAction moveAction;

    [Header("Events")]
    public UnityEvent onMoveHold; // Event triggered when movement buttons are held

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput != Vector2.zero) // Movement input detected
        {
            onMoveHold?.Invoke();
        }
    }
}
