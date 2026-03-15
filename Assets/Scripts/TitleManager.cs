using UnityEngine;
using UnityEngine.SceneManagement;
/*
Title Manager:
This script controls the title screen menu. It lets the player start the game.
*/
public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Project 1");
    }

 
}
