using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    //Script to reset the scene
    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Script to go to the main menu
    public void exitLevel()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    //Script to go to the game
    public void enterLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
}
