using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int lives = 3;
    private float respawnTime = 3.0f;
    private float invulTime = 3.0f;

    [SerializeField] private Canvas startScreen;
    [SerializeField] private Canvas gameOverScreen;
    [SerializeField] private Canvas UIScreen;
    public TextMeshProUGUI scoreText;
    private int score;
    public bool gameOver;
    public bool isGameActive;
    public bool playerDead;

    public void StartGame()
    {
        startScreen.gameObject.SetActive(false);
        UIScreen.gameObject.SetActive(true);
        UpdateScore(0);
        isGameActive = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.gameObject.SetActive(false);
        UIScreen.gameObject.SetActive(true);
        isGameActive = true;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void PlayerDied()
    {
        lives--;
        playerDead = true;
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
            Invoke("Respawn", respawnTime);
        }
    }

    private void Respawn()
    {
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 10;
        player.transform.position = Vector2.zero;
        Invoke("TurnOnCollisions", invulTime);
        playerDead = false;
    }

    private void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void GameOver()
    {
        gameOver = true;
        isGameActive = false;
        UIScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
    }
}
