using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOpponent : MonoBehaviour
{
    PongBall ball;
    Rigidbody2D rb;

    [SerializeField] float speed = 6.5f; // Kecepatan AI dibatasi biar ada celah buat menang

    void Start()
    {
        ball = FindFirstObjectByType<PongBall>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ball == null)
        {
            ball = FindFirstObjectByType<PongBall>();
        }
    }

    void FixedUpdate()
    {
        if (ball != null && ball.gameObject.activeInHierarchy)
        {
            float targetY;

            // AI Cerdas: Cek apakah bola lari ke arah musuh (kecepatan X positif)
            if (ball.GetComponent<Rigidbody2D>().linearVelocity.x > 0)
            {
                targetY = ball.transform.position.y;
            }
            else
            {
                targetY = 0f; // Kembali ke tengah kalau bola menjauh
            }

            // MoveTowards memastikan AI bergerak mulus, dan rb.MovePosition mencegah AI nembus dinding
            Vector2 targetPos = new Vector2(transform.position.x, targetY);
            Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
    }
}