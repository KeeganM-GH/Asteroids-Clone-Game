using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //ded
            spriteRenderer.sortingOrder = -1;
            gameManager.PlayerDied();
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //also ded
            spriteRenderer.sortingOrder = -1;
            gameManager.PlayerDied();
        }
    }
}
