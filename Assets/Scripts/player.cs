using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;

    private float movementX; // left/right arrow or A/D
    private float movementZ; // up/down arrow or W/S
    private float rotationX; // mouse X movement (left or right)
    private float rotationY; // mouse Y movement (front or back)


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // hide cursor when playing the game
    }

    // On<Action> functions are defined in the InputActions Asset

    private void OnMove(InputValue movementValue)
    {
        Debug.Log(movementValue.Get<Vector2>());
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    private void OnLook(InputValue lookValue)
    {
        //Debug.Log(lookValue.Get<Vector2>());
        Vector2 lookVector = lookValue.Get<Vector2>();
        rotationX = lookVector.x;
        rotationY = lookVector.y;
    }


    private void OnFire(InputValue fireValue)
    {
        // Debug.Log(fireValue.Get<float>());
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0, movementZ);
        Debug.Log(movement);
        rb.AddRelativeForce(movement * speed); //Local space
                                               //rb.AddForce(movement * speed); //World space
                                               // transform.Translate(new Vector3(-movementY, 0.0f, movementX) * speed * Time.fixedDeltaTime);

        Vector3 rotation = new Vector3(0, rotationX, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotation * 10.0f * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

    }
}
