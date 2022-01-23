using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

[RequireComponent(typeof(AIDestinationSetter))]

public class Enemy : MonoBehaviour
{
    private AIDestinationSetter enemyDest;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyDest = GetComponent<AIDestinationSetter>();
    }

    private void Update()
    {
        if (GameManager.isBuffed)
        {
            Debug.Log("PLAYER BUFFED");
        }
        else
        {
            enemyDest.target = player.transform;
        }
    }
}
