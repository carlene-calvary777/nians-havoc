using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    // PLay Button
    public void PlayGame()
    {
        Debug.Log("Play Game button clicked");
        SceneManager.LoadScene("LevelSelection"); 
    }

    // Quit button
    public void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit(); 
    }

    public GameObject settingsPanel;

    public void OpenSettings()
    {
        Debug.Log("Open Settings button clicked");
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public GameObject creditsPanel;

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
}