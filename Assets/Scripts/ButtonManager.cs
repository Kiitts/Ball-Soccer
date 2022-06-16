using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // reset the scene
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // load the selected name of scene
    public void LevelLoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
