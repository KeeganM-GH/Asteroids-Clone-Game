using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigShip : MonoBehaviour
{
    public float speed = 0.5f;
    [SerializeField] private int scoreValue = 100;

    private Rigidbody2D enemyRb;
    private GameObject player;
    private GameManager gameManager;
    private SpawnManager spawnManager;

    public float spawnInterval;
    private float nextSpawn;
    public int miniEnemySpawnCount;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnInterval;
            spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
        }
    }

    void FixedUpdate()
    {
        if (!gameManager.gameOver && gameManager.isGameActive)
        {
            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
            enemyRb.rotation = angle;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(scoreValue);
            collision.gameObject.SetActive(false);
        }
    }
}
