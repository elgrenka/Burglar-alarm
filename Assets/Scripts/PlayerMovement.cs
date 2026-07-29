using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rigidbody;
    private Vector2 moveInput;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        bool leftPressed = Keyboard.current.leftArrowKey.isPressed;
        bool rightPressed = Keyboard.current.rightArrowKey.isPressed;

        float inputX = 0f;

        if (leftPressed)
            inputX = -1f;
        if (rightPressed)
            inputX = 1f;

        moveInput = new Vector2(inputX, 0);
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveInput.x * speed, rigidbody.linearVelocity.y);
        rigidbody.linearVelocity = movement;
    }
}