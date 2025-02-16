// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class GameManager : MonoBehaviour
// {
//     public ApplicationData applicationData;
//     public TextMeshProUGUI pinyinText;
//     public Button[] hanziButtons; // Three buttons for Hanzi options

//     private int currentIndex = 0;
//     private ApplicationData currentQuestion;

//     void Start()
//     {
//         LoadQuestion();
//     }

//     public void LoadQuestion()
//     {
//         currentQuestion = applicationData.GetQuestion(currentIndex);

//         // Set Pinyin Text
//         pinyinText.text = currentQuestion.pinyin;

//         // Assign Hanzi to buttons
//         for (int i = 0; i < hanziButtons.Length; i++)
//         {
//             hanziButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.hanziOptions[i];
//             hanziButtons[i].gameObject.SetActive(true); // Reset visibility
//             int index = i; // Store index for click event
//             hanziButtons[i].onClick.RemoveAllListeners();
//             hanziButtons[i].onClick.AddListener(() => OnHanziClick(index));
//         }
//     }

//     public void OnHanziClick(int index)
//     {
//         hanziButtons[index].gameObject.SetActive(false); // Hide clicked button

//         // Check if all buttons are clicked
//         bool allHidden = true;
//         foreach (Button button in hanziButtons)
//         {
//             if (button.gameObject.activeSelf) 
//             {
//                 allHidden = false;
//                 break;
//             }
//         }

//         // Load next question when all options are clicked
//         if (allHidden)
//         {
//             NextQuestion();
//         }
//     }

//     public void NextQuestion()
//     {
//         currentIndex = (currentIndex + 1) % applicationData.applicationQuestions.Count;
//         LoadQuestion();
//     }

//     public void PreviousQuestion()
//     {
//         currentIndex = (currentIndex - 1 + applicationData.applicationQuestions.Count) % applicationData.applicationQuestions.Count;
//         LoadQuestion();
//     }
// }
