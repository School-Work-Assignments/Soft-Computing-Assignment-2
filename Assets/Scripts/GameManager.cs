using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int speed = 3;
    public static int lives = 3;
    public static bool isBuffed = false;
    public static string playerName;

    public void Easy()
    {
        speed = 3;
        GetName();

        if (playerName != null)
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Medium()
    {
        speed = 5;
        GetName();

        if (playerName != null)
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Hard()
    {
        speed = 7;
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
