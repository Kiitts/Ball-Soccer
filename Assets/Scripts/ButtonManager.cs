using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelSelector, mainMenu;
    // reset the scene
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChooseLevel()
    {
        mainMenu.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void ChooseLevelBackToMainMenu()
    {
        levelSelector.SetActive(false);
        mainMenu.SetActive(true);
    }

    // load the selected name of scene
    public void LevelLoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LevelLoadScene(int element)
    {
        SceneManager.LoadScene(element);
    }

    // quit the game
    public void QuitGame()
    {
        # if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
