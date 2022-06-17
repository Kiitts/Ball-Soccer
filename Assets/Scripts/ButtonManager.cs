using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelSelector, mainMenu;
    [SerializeField]
    private GameObject[] _levelButtons;

    private void Start() 
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            CheckButtonLevel();
        }
    }
    
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

    public void NextLevel()
    {
        LevelLoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CheckButtonLevel()
    {
        ResetButton();
        MainManager.instance.LoadLevel();
        int levels = MainManager.instance.levelAcquired;
        for(int i = 0;  i < levels; i++)
        {
            _levelButtons[i].GetComponent<Button>().interactable = true;
        }
    }

    public void ResetProgress()
    {
        MainManager.instance.SaveLevel(1, true);
        CheckButtonLevel();
    }

    void ResetButton()
    {
        foreach (var item in _levelButtons)
        {
            item.GetComponent<Button>().interactable = false;
        }
    }
}
