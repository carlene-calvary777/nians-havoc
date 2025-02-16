using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


 public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } // Add Singleton Instance

    private LevelData currentLevelData; // Ensure this is properly assigned

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentLevelData(LevelData data)
    {
        currentLevelData = data;
    }

    public LevelData GetCurrentLevelData()
    {
        if (currentLevelData == null)
        {
            Debug.LogError("Level data is not set!");
        }
        return currentLevelData;
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    
    public void LoadLevelByName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);  // MainMenu is usually index 0
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();  // Only works in a built application
    }

    

}
