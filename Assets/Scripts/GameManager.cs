using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static int difficulty = 0;

    public void Easy()
    {
        difficulty = 1;
        Debug.Log(difficulty);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Medium()
    {
        difficulty = 2;
        Debug.Log(difficulty);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Hard()
    {
        difficulty = 3;
        Debug.Log(difficulty);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
