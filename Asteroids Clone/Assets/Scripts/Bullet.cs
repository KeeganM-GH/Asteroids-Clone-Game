using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager gameManager;
    private Enemy enemy;
    private EnemyBigShip bigEnemy;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemy = FindObjectOfType<Enemy>();
        bigEnemy = FindObjectOfType<EnemyBigShip>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            gameObject.SetActive(false);
        }

    }
}
