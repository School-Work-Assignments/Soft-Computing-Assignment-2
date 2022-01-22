using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static Dictionary<Vector2Int, GameObject> obstacles = new Dictionary<Vector2Int, GameObject>();
    public static List<Vector2Int> availableTiles = new List<Vector2Int>();

    private GameObject tilePrefab;
    private GameObject playerPrefab;

    private int width = 30;
    private int height = 30;
    private int offset;

    private void Start()
    {
        tilePrefab = Resources.Load("Prefabs/Obstacle") as GameObject;
        playerPrefab = Resources.Load("Prefabs/Player") as GameObject;

        offset = (width / 2) - 1;
        GenerateObstacles();
        SpawnPlayer();
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

            GameObject tile = Instantiate(tilePrefab, new Vector3(randomTile.x - offset, randomTile.y - offset), Quaternion.identity);
            tile.transform.parent = transform;

            obstacles.Add(new Vector2Int(randomTile.x - offset, randomTile.y - offset), tile);
            availableTiles.Remove(randomTile);
        }

        AstarPath.active.Scan();
    }

    private void SpawnPlayer()
    {
        Vector2Int spawnPos = availableTiles[Random.Range(0, availableTiles.Count)];
        Instantiate(playerPrefab, new Vector3(spawnPos.x - offset, spawnPos.y - offset), Quaternion.identity);
    }
}
