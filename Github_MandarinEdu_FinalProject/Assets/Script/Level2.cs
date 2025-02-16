using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public LevelData levelData; // Assign this in Unity Inspector
    public int currentLevel = 2; // Change this dynamically for different levels

    public TextMeshProUGUI hanziDisplay;
    public Button[] pinyinButtons;
    public TextMeshProUGUI rocketCounter;
    public GameObject congratulatoryScreen;
    public Button continueButton;

    private int rocketCount = 0;
    private int currentQuestionIndex = 0;
    private string correctPinyin;
    private List<HanziQuestion> questions;

    void Start()
    {
        if (levelData == null || levelData.levels.Count == 0)
        {
            Debug.LogError("LevelData is missing or empty!");
            return;
        }

        // Get the correct level's data
        Level selectedLevel = levelData.levels.Find(l => l.levelNumber == currentLevel);
        if (selectedLevel == null || selectedLevel.questions.Count == 0)
        {
            Debug.LogError($"Level {currentLevel} is missing or has no questions!");
            return;
        }

        questions = selectedLevel.questions;

        rocketCount = 0;
        rocketCounter.text = "x" + rocketCount;

        congratulatoryScreen.SetActive(false);
        if (continueButton != null)
            continueButton.onClick.AddListener(ProceedToApplicationPhase);

        NextQuestion();
    }

    void NextQuestion()
    {
        if (currentQuestionIndex >= questions.Count)
        {
            ShowCongratulatoryScreen();
            return;
        }

        HanziQuestion currentQuestion = questions[currentQuestionIndex];

        hanziDisplay.text = currentQuestion.hanzi;
        correctPinyin = currentQuestion.correctPinyin;

        List<(string pinyin, string translation)> options = new List<(string, string)>
        {
            (currentQuestion.correctPinyin, currentQuestion.correctTranslation)
        };

        // Add a random incorrect answer
        HanziQuestion randomWrongAnswer = questions[Random.Range(0, questions.Count)];
        while (randomWrongAnswer.hanzi == currentQuestion.hanzi)
        {
            randomWrongAnswer = questions[Random.Range(0, questions.Count)];
        }
        options.Add((randomWrongAnswer.correctPinyin, randomWrongAnswer.correctTranslation));

        ShuffleList(options);

        for (int i = 0; i < pinyinButtons.Length; i++)
        {
            if (i < options.Count)
            {
                pinyinButtons[i].gameObject.SetActive(true);
                pinyinButtons[i].interactable = true;
                pinyinButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i].pinyin + "\n(" + options[i].translation + ")";

                pinyinButtons[i].onClick.RemoveAllListeners();
                if (options[i].pinyin == correctPinyin)
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
        Time.timeScale = 0;
        congratulatoryScreen.SetActive(true);
    }

    void ProceedToApplicationPhase()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ApplicationPhaseScene");
    }

    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
