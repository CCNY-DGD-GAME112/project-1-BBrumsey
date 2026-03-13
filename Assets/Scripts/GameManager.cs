using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private float timeLeft;
    private bool gameOver = false;


    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver = false;
        timeLeft = 0;
        score = 0;

     

        UpdateScoreUI();
        UpdateTimerUI();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;

        timeLeft += Time.deltaTime;
        
        UpdateTimerUI();
    }

    public void AddScore(int amount)
    {
        
        score += amount;
        UpdateScoreUI();
    }

    public int GetScore() {
        return score; 
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

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if (highScoreText != null)
            highScoreText.text = $"High Score: {highScore}";

        if (MusicManager.Instance != null)
            MusicManager.Instance.StopMusic();
    } 

    public void PlayAgain()
    {
        Time.timeScale = 1;

        if(MusicManager.Instance != null)
            MusicManager.Instance.PlayMusic();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}