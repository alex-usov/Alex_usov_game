using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    //[SerializeField] GameObject lvlPrefab;
    [SerializeField] List<GameObject> levelPrefab = new List<GameObject>();
    [SerializeField] List<GameObject> Walls = new List<GameObject>();
    //private Wall wall;
    [SerializeField] Transform player;
    private float spawnPos = 0;
    private float levelLength = 12;
    private int startLevels = 6;
    int x;

    void Start()
    {
        for (var i = 0; i <= startLevels; i++)
        {
            SpawnLevel(Random.Range(0, levelPrefab.Count));
        }        
    }
    void Update()
    {
        if (player.position.z > spawnPos - levelLength * startLevels)
        {
            SpawnLevel(Random.Range(0, levelPrefab.Count));
        }
    }
    private void SpawnLevel(int tileIndex)
    {
        Instantiate(levelPrefab[tileIndex], transform.forward * spawnPos, transform.rotation);
        spawnPos += levelLength;
    }
}
