using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PauseManager : MonoBehaviour
{
    // public GameObject pauseMenuPrefab;
    // private GameObject pauseMenuInstance;

    // private bool isPaused = false;

    public GameObject pausePanel;
    public void OpenPausePanel()
    {
        Debug.Log("Pause button clicked");
        pausePanel.SetActive(true);
    }

    public void closePausePanel()
    {
        Debug.Log("Pause button clicked");
        pausePanel.SetActive(false);
    }

    // void Start()
    // {
    //     // Instantiate the PauseMenu UI at runtime
    //     if (pauseMenuPrefab != null)
    //     {
    //         pauseMenuInstance = Instantiate(pauseMenuPrefab);
    //         pauseMenuInstance.SetActive(false); // Hide by default
    //     }
    // }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape)) // Press Esc to toggle pause
    //     {
    //         TogglePause();
    //     }
    // }

    // public void TogglePause()
    // {
    //     isPaused = !isPaused;

    //     if (pauseMenuInstance != null)
    //     {
    //         pauseMenuInstance.SetActive(isPaused);
    //     }

    //     Time.timeScale = isPaused ? 0 : 1; // Pause/unpause the game
    // }

    // public void ResumeGame()
    // {
    //     isPaused = false;
    //     pauseMenuInstance.SetActive(false);
    //     Time.timeScale = 1;
    // }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; // Reset time before switching scenes
        SceneManager.LoadScene("MainMenu");
    }
}
