using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;

    public float startTime = 20;
    private int score = 0;
    private float timeLeft;
    private bool gameOver = false;


void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        timeLeft = startTime;
        score = 0;

        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        UpdateScoreUI();
        UpdateTimerUI();

    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            UpdateTimerUI();
            GameOver();
            return;
        }
        UpdateTimerUI();
    }

    public void AddScore(int amount)
    {
        if (gameOver) return;
        score += amount;
        UpdateScoreUI();
    }
    public bool IsGameOver()
    {
        return gameOver;
    }
    private void UpdateScoreUI()
    {
    
            if (scoreText != null)
                scoreText.text = $"Score: {score}";
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = $"Time: {timeLeft:0.0}";
    }

    public void GameOver()
    {
        gameOver = true;
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);
    }
}