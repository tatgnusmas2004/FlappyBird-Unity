using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    private int score = 0;
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    private void Start()
    {
        Time.timeScale = 0f;
        score = 0;
        gameOver = false;
        UpdateScoreUI();
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        gameOver = false;
        score = 0;
        UpdateScoreUI();
        startPanel.SetActive(false);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic();
        }
        Time.timeScale = 1f;
    }

    public void AddScore()
    {
        if (gameOver) return;
        score++;
        UpdateScoreUI();
        Debug.Log("Score: " + score);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        if (gameOver) return;
        gameOver = true;
        finalScoreText.text = "Score: " + score;
        gameOverPanel.SetActive(true);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayGameOver();
        }
        Debug.Log("GAME OVER!");
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
