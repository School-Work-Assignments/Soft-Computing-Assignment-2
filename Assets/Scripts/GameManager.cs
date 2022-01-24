using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static TextMeshProUGUI scoreDifficulty;
    private static TextMeshProUGUI scoreName;
    private static TextMeshProUGUI scoreNum;

    private static string difficulty;
    public static int speed = 3;
    public static int lives = 3;
    public static int score = 0;
    public static bool isBuffed = false;
    public static string playerName;

    private void Start()
    {
        int tutorial_loaded = PlayerPrefs.GetInt("LoadData", 0);

        if (tutorial_loaded == 0)
        {
            Debug.Log("Loading Tutorial Scene");

            PlayerPrefs.SetInt("LoadData", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        }

        if (SceneManager.GetActiveScene().name == "Highscore")
        {
            scoreDifficulty = GameObject.FindGameObjectWithTag("ScoreDifficulty").GetComponent<TextMeshProUGUI>();
            scoreName = GameObject.FindGameObjectWithTag("ScoreName").GetComponent<TextMeshProUGUI>();
            scoreNum = GameObject.FindGameObjectWithTag("ScoreNum").GetComponent<TextMeshProUGUI>();

            scoreName.text = playerName;
            scoreNum.text = score.ToString();
            scoreDifficulty.text = difficulty;
        }
    }

    public static void SetScore(int newScore)
    {
        score += newScore;
    }

    public void Easy()
    {
        speed = 3;
        difficulty = "Easy";
        GetName();

        if (playerName != null)
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Medium()
    {
        speed = 5;
        difficulty = "Medium";
        GetName();

        if (playerName != null)
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Hard()
    {
        speed = 7;
        difficulty = "Hard";
        GetName();

        if (playerName != null)
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    private void GetName()
    {
        TextMeshProUGUI nameInput = GameObject.FindGameObjectWithTag("NameInput").GetComponent<TextMeshProUGUI>();
        playerName = nameInput.text;
    }
}
