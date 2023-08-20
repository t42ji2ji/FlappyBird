using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    MyInputAction myInputAction;
    public Rigidbody2D rb;
    public float jumpForce = 15;
    public bool dead = false;

    public float rotationSpeed = 2f; // Adjust for faster/slower rotation

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        float rotation = Mathf.Lerp(0, -90, -rb.velocity.y / 10f); // The value 10f is an arbitrary divisor, adjust as needed
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        // Rotate upward based on current rotation
        float currentZRotation = transform.eulerAngles.z;
        transform.eulerAngles = new Vector3(0, 0, currentZRotation + 3); // Adds
    }

    public void Die()
    {
        dead = true;
    }

    private void Awake()
    {
        myInputAction = new MyInputAction();
    }

    private void OnEnable()
    {
        myInputAction.Enable();

        myInputAction.GamePlay.Jump.performed += JumpPerformed;
    }

    void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!dead)
        {
            Jump();
        }
    }

    private void OnDestroy()
    {
        myInputAction.Dispose();
    }
}
