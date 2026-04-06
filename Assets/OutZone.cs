using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZone : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PongBall")
        {
            if (gameObject.CompareTag("PlayerZone"))
            {
                gm.opponentWin.Invoke();
            }
            else if (gameObject.CompareTag("OpponentZone"))
            {
                gm.playerWin.Invoke();
            }
        }
    }
}