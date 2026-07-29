using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        bool isLeftPressed = Keyboard.current.leftArrowKey.isPressed;
        bool isRightPressed = Keyboard.current.rightArrowKey.isPressed;

        float inputX = 0f;

        if (isLeftPressed)
            inputX = -1f;
        if (isRightPressed)
            inputX = 1f;

        _moveInput = new Vector2(inputX, 0);
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_moveInput.x * _speed, _rigidbody.linearVelocity.y);
        _rigidbody.linearVelocity = movement;
    }
}