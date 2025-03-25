using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 10f;
    public float turnSpeed = 10f;

    public Transform moveTarget;
    private float horizontalMovement;
    private Vector2 mouseMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    float turnX, turnY;

    // Update is called once per frame
    void Update()
    {
        
        rb.AddForce(transform.forward * horizontalMovement * moveSpeed);

        turnX = Mathf.Min(1.0f, mouseMovement.x);
        turnY = Mathf.Min(1.0f, mouseMovement.y);
        transform.Rotate(new Vector3(turnX * turnSpeed * Time.deltaTime, turnY * turnSpeed * Time.deltaTime, 0));
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 movement = ctx.ReadValue<Vector2>();

        horizontalMovement = movement.y;
    }

    public void Look(InputAction.CallbackContext ctx)
    {
        Vector2 movement = ctx.ReadValue<Vector2>();

        mouseMovement = movement;
        Debug.Log(movement);
    }
}
