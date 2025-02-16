using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    public TextMeshProUGUI hanziDisplay;
    public Button[] pinyinButtons;
    public TextMeshProUGUI rocketCounter;
    public GameObject congratulatoryScreen; // Assign in Inspector
    public Button continueButton; // Assign in Inspector

    private int rocketCount = 0;
    private int currentQuestionIndex = 0;
    private string correctPinyin;

    [System.Serializable]
    public class HanziQuestion
    {
        public string hanzi;
        public string correctPinyin;
        public string incorrectPinyin1;
        public string incorrectPinyin2;
        public string incorrectPinyin3;
    }

    private List<HanziQuestion> questions = new List<HanziQuestion>();

    void Start()
    {
        Debug.Log("Start() called - Level3 script is running");

        // Initialize Level 3 Questions
        questions.Add(new HanziQuestion { hanzi = "汉字", correctPinyin = "hànzì", incorrectPinyin1 = "huǒ", incorrectPinyin2 = "zì", incorrectPinyin3 = "shū" });
        questions.Add(new HanziQuestion { hanzi = "火", correctPinyin = "huǒ", incorrectPinyin1 = "hànzì", incorrectPinyin2 = "shān", incorrectPinyin3 = "tiān" });
        questions.Add(new HanziQuestion { hanzi = "字", correctPinyin = "zì", incorrectPinyin1 = "huǒ", incorrectPinyin2 = "rì", incorrectPinyin3 = "yún" });

        rocketCount = 0;
        rocketCounter.text = "x" + rocketCount;

        congratulatoryScreen.SetActive(false); // Hide congratulatory screen at start
        if (continueButton != null)
            continueButton.onClick.AddListener(ProceedToApplicationPhase);

        NextQuestion();
    }

    void NextQuestion()
    {
        Debug.Log("NextQuestion() called - Current index: " + currentQuestionIndex);

        if (currentQuestionIndex >= questions.Count)
        {
            Debug.Log("Level 3 Completed!");
            ShowCongratulatoryScreen();
            return;
        }

        HanziQuestion currentQuestion = questions[currentQuestionIndex];
        Debug.Log("Displaying Hanzi: " + currentQuestion.hanzi);
        hanziDisplay.text = currentQuestion.hanzi;
        correctPinyin = currentQuestion.correctPinyin;

        List<string> options = new List<string> { correctPinyin, 
        currentQuestion.incorrectPinyin1, 
        currentQuestion.incorrectPinyin2, 
        currentQuestion.incorrectPinyin3 };
        
        ShuffleList(options);

        for (int i = 0; i < pinyinButtons.Length; i++)
        {
            if (i < options.Count)
            {
                pinyinButtons[i].gameObject.SetActive(true);
                pinyinButtons[i].interactable = true; // Ensure the button is clickable
                pinyinButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i];

                pinyinButtons[i].onClick.RemoveAllListeners(); // Remove previous listeners

                if (options[i] == correctPinyin)
                    pinyinButtons[i].onClick.AddListener(CorrectAnswer);
                else
                    pinyinButtons[i].onClick.AddListener(WrongAnswer);
            }
            else
            {
                pinyinButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void CorrectAnswer()
    {
        Debug.Log("Correct!");
        rocketCount++;
        rocketCounter.text = "x" + rocketCount;

        currentQuestionIndex++;
        NextQuestion();
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong Answer!");
    }

    void ShowCongratulatoryScreen()
    {
        Time.timeScale = 0; // Pause the game
        congratulatoryScreen.SetActive(true);
    }

    void ProceedToApplicationPhase()
    {
        Time.timeScale = 1; // Resume game
        SceneManager.LoadScene("ApplicationPhaseScene"); // Change to the actual scene name
    }

    void ShuffleList(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
