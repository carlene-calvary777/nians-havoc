using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireballPrefab;  // Assign the Fireball prefab in the Inspector
    public Transform fireballContainer; // Assign the FireballContainer (Panel)
    public List<string> hanziCharacters; // List of characters to display
    public int numberOfFireballs = 3;  // Number of fireballs per spawn

    void Start()
    {
        SpawnFireballs();
    }

    public void SpawnFireballs()
    {
        for (int i = 0; i < numberOfFireballs; i++)
        {
            // Instantiate fireball inside the container
            GameObject fireball = Instantiate(fireballPrefab, fireballContainer);

            // Set random position inside the UI panel
            RectTransform rt = fireball.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(Random.Range(-300, 300), Random.Range(-200, 200));

            // Set random Hanzi character
            TextMeshProUGUI textComponent = fireball.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null && hanziCharacters.Count > 0)
            {
                textComponent.text = hanziCharacters[Random.Range(0, hanziCharacters.Count)];
            }

            // Add click functionality
            fireball.GetComponent<Button>().onClick.AddListener(() => OnFireballClicked(fireball));
        }
    }

    void OnFireballClicked(GameObject fireball)
    {
        Debug.Log("Fireball Clicked: " + fireball.GetComponentInChildren<TextMeshProUGUI>().text);
        Destroy(fireball); // Destroy when clicked
    }
}
