using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float initialSpeed = 6f;
    [SerializeField] float speedIncrease = 0.5f; // Bola makin ngebut tiap dipukul
    float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        ThrowBall();
    }

    private Vector2 GenerateRandomDirection()
    {
        // TARGET 1: Fix Steepness
        // Memaksa bola selalu mengarah ke serong kiri/kanan, mencegah lurus ke atas/bawah
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.8f, 0.8f);
        return new Vector2(x, y).normalized;
    }

    public void ThrowBall()
    {
        currentSpeed = initialSpeed;
        transform.position = Vector3.zero;

        // Pakai velocity langsung, bukan AddForce, biar kecepatan lebih stabil
        rb.linearVelocity = GenerateRandomDirection() * currentSpeed;
    }

    // TARGET 2: Bikin game lebih dinamis
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Opponent")
        {
            currentSpeed += speedIncrease; // Makin lama main, makin cepet bolanya

            // Kalkulasi titik pantul biar realistis
            float y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
            float x = collision.gameObject.name == "Player" ? 1f : -1f;

            Vector2 dir = new Vector2(x, y).normalized;
            rb.linearVelocity = dir * currentSpeed;
        }
    }
}