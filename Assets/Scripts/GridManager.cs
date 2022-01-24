using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class GridManager : MonoBehaviour
{
    public Dictionary<Vector2Int, GameObject> obstacles = new Dictionary<Vector2Int, GameObject>();
    public static List<Vector2Int> availableTiles = new List<Vector2Int>();

    private GameObject obstaclePrefab;
    private GameObject playerPrefab;
    private GameObject enemyPrefab;
    private static GameObject foodPrefab;

    private Vector2Int playerSpawnPos;

    private int enemyCount = 2;
    private int enemySpeed;

    private static int foodCount;
    private static bool initialFoodSpawned;

    private int width = 30;
    private int height = 30;
    private static int offset;

    private void Start()
    {
        obstaclePrefab = Resources.Load("Prefabs/Obstacle") as GameObject;
        playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
        enemyPrefab = Resources.Load("Prefabs/Enemy") as GameObject;
        foodPrefab = Resources.Load("Prefabs/Food") as GameObject;

        availableTiles.Clear();
        initialFoodSpawned = false;
        foodCount = 5;

        offset = (width / 2) - 1;
        enemySpeed = GameManager.speed;

        GenerateObstacles();
        SpawnPlayer();
        SpawnFood();

        for (int i = 0; i < enemyCount; i++)
            SpawnEnemy();
    }

    private void GenerateObstacles()
    {
        int obstaclesToSpawn = 150;

        //Getting all available tiles in grid
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                availableTiles.Add(new Vector2Int(i, j));
            }
        }

        //Instantiating obstacle at a random available tile
        for (int k = 0; k < obstaclesToSpawn; k++)
        {
            Vector2Int randomTile = availableTiles[Random.Range(0, availableTiles.Count)];

            GameObject tile = Instantiate(obstaclePrefab, new Vector3(randomTile.x - offset, randomTile.y - offset), Quaternion.identity);
            tile.transform.parent = transform;

            obstacles.Add(new Vector2Int(randomTile.x - offset, randomTile.y - offset), tile);
            availableTiles.Remove(randomTile);
        }

        AstarPath.active.Scan();
    }

    private void SpawnPlayer()
    {
        playerSpawnPos = availableTiles[Random.Range(0, availableTiles.Count)];
        Instantiate(playerPrefab, new Vector3(playerSpawnPos.x - offset, playerSpawnPos.y - offset), Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        GameObject enemy;

        Vector2Int randomSpawnPos = availableTiles[Random.Range(0, availableTiles.Count)];

        if (Vector2Int.Distance(playerSpawnPos, randomSpawnPos) > 10)
        {
            enemy = Instantiate(enemyPrefab, new Vector3(randomSpawnPos.x - offset, randomSpawnPos.y - offset), Quaternion.identity);
            enemy.gameObject.GetComponent<AILerp>().speed = enemySpeed;
        }
        else
            SpawnEnemy();
    }

    public static void SpawnFood()
    {
        if (initialFoodSpawned)
            foodCount = 1;
        else
        {
            foodCount = 5;
            initialFoodSpawned = true;
        }

        for (int i = 0; i < foodCount; i++)
        {
            Vector2Int randomTile = availableTiles[Random.Range(0, availableTiles.Count)];
            Instantiate(foodPrefab, new Vector3(randomTile.x - offset, randomTile.y - offset), Quaternion.identity);
        }
    }
}
