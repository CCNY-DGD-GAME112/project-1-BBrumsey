using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    // Score will go up if player grabs coin
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        scoreText.text = "Score: " + score;
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
