using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public LevelData levelData;
    public int currentLevel = 1;

    private LearningPhase learningPhase;
    public GameObject applicationPhasePrefab;
    void Start()
    {
        if (levelData == null || levelData.levels.Count == 0)
        {
            Debug.LogError("LevelData is missing or empty!");
            return;
        }

        Level selectedLevel = levelData.levels.Find(l => l.levelNumber == currentLevel);
        if (selectedLevel == null)
        {
            Debug.LogError($"Level {currentLevel} is missing or has no questions!");
            return;
        }

        learningPhase = FindObjectOfType<LearningPhase>();
        if (learningPhase == null)
        {
            Debug.LogError("LearningPhase component is missing in the scene!");
            return;
        }

        learningPhase.Initialize(selectedLevel);
        learningPhase.OnLearningPhaseComplete += ProceedToApplicationPhase;
    }

   public void ProceedToApplicationPhase()
{
    if (applicationPhasePrefab != null)
    {
        GameObject newPhase = Instantiate(applicationPhasePrefab);
        newPhase.transform.position = Vector3.zero;  // Adjust position if needed
        Debug.Log("Application Phase instantiated!");
    }
    else
    {
        Debug.LogError("ApplicationPhase prefab is not assigned!");
    }
}


    // public void ProceedToApplicationPhase()
    // {
    //     SceneManager.LoadScene("ApplicationPhase");
    // }

    // public void ProceedToApplicationPhase()
    // {
    //     // if (GameManager.Instance == null)
    //     // {
    //     //     Debug.LogError("GameManager Instance is NULL!");
    //     //     return;
    //     // }

    //     if (levelData == null)
    //     {
    //         Debug.LogError("LevelData is NULL!");
    //         return;
    //     }

    //     LevelManager.Instance.SetCurrentLevelData(levelData);
    //     SceneManager.LoadScene("ApplicationPhase");
    // }
}