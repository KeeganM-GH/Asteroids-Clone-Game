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
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
        Invoke("Respawn", respawnTime);
        }
    }

    private void Respawn()
    {
        player.transform.position = Vector2.zero;
        player.SetActive(true);
        player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        Invoke("TurnOnCollisions", invulTime);
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
