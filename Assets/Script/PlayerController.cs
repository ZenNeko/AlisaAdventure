using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 100f;
    private new Rigidbody2D rigidbody2D;
    private Vector2 inputVector;
    
    // mouse pos
    private Vector2 mousePos;
    public Camera cam;

    void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + inputVector * MovementSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rigidbody2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody2D.rotation = angle;
    }
}
