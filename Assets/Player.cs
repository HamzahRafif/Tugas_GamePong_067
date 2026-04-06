using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float movementInput;
    [SerializeField] float speed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput = Input.GetAxisRaw("Vertical"); // GetAxisRaw bikin kontrol lebih responsif
    }

    void FixedUpdate()
    {
        // Pakai velocity biar Collider tembok bekerja sempurna
        rb.linearVelocity = new Vector2(0, movementInput * speed);
    }
}