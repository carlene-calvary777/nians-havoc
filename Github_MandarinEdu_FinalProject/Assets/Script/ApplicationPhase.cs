using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ApplicationPhase : MonoBehaviour
{
    public GameObject fireballSpawner; // Assign in Inspector

    void Start()
    {
        Debug.Log("Application Phase started!");

        if (fireballSpawner != null)
        {
            fireballSpawner.SetActive(true); // Enable spawner
            Debug.Log("FireballSpawner enabled!");
        }
        else
        {
            Debug.LogError("FireballSpawner is not assigned in ApplicationPhase!");
        }
    }


}
