using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Project 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
