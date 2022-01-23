using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

[RequireComponent(typeof(AIDestinationSetter))]

public class Enemy : MonoBehaviour
{
    private GridManager gridManager;
    private AIDestinationSetter enemyDest;
    private GameObject player;

    private GameObject buffedTarget;
    private bool buffedDestSet = false;

    private void Start()
    {
        gridManager = GameObject.Find("Grid").GetComponent<GridManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyDest = GetComponent<AIDestinationSetter>();

        buffedTarget = new GameObject();
    }

    private void Update()
    {
        //FOOD FUNCTIONALITY NEEDS TO BE FIXED

        if (GameManager.isBuffed)
        {
            if (!buffedDestSet)
            {
                BuffedMovement();
                buffedDestSet = true;
            }
        }
        else
        {

            if (buffedDestSet)
            {
                buffedDestSet = false;
            }

            enemyDest.target = player.transform;
        }
    }

    private void BuffedMovement()
    {
        Vector2Int randomTile = gridManager.availableTiles[Random.Range(0, gridManager.availableTiles.Count)];
        Vector3 randomTileV3 = new Vector3(randomTile.x, randomTile.y);

        if (Vector3.Distance(randomTileV3, player.transform.position) > 15)
        {
            Debug.Log(buffedTarget);
            buffedTarget.transform.position = randomTileV3;
            enemyDest.target = buffedTarget.transform;
        }
    }
}
