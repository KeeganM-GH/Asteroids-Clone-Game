using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooters : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private GameManager gameManager;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce;
    private float RangeX = 20f;
    private float RangeY = 8f;
    public float distanceRange;
    private Vector2 waypoint;
    [SerializeField] private int scoreValue = 75;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        if (gameManager.isGameActive)
        {
            InvokeRepeating("Shooting", 2f, 3f);
        }
    }

    void FixedUpdate()
    {
        if (!gameManager.gameOver && gameManager.isGameActive)
        {
            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            //enemyRb.AddForce(lookDirection * speed);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
            enemyRb.rotation = angle;

        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, waypoint) < distanceRange)
            {
                SetNewDestination();
            }
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

    void Shooting()
    {
        GameObject enemyBullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D bulletRb = enemyBullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void SetNewDestination()
    {
        waypoint = new Vector2(Random.Range(-RangeX, RangeX), Random.Range(-RangeY, RangeY));
    }

    /*private Vector2 NewDestination()
    {
        float PosX = Random.Range(-RangeX, RangeX);
        float PosY = Random.Range(-RangeY, RangeY);

        Vector2 randomPos = new Vector2(PosX, PosY);

        return randomPos;
    }*/
}
