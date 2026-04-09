using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player mainPlayer;

    [SerializeField] private List<Enemy> allSpawnedEnemies;
    [SerializeField] private Enemy[] possibleEnemyPrefabs;
    [SerializeField] private Transform[] possibleSpawnPoints;

    public void Start()
    {
        if (mainPlayer.GetComponent<IDash>() != null)
        {
            Debug.Log("Player has Dash");
        }

        StartCoroutine(SpawnRandomEnemy());
    }

    private IEnumerator SpawnRandomEnemy()
    {
        while (!mainPlayer.isDead)
        {
            if (allSpawnedEnemies.Count >= 11)
            {
                yield return new WaitForSeconds(3f);

                continue;
            }

            var amountOfIndexes = possibleEnemyPrefabs.Length;
            var randomIndex = Random.Range(0, amountOfIndexes);
            var enemy = Instantiate(possibleEnemyPrefabs[randomIndex]);
            allSpawnedEnemies.Add(enemy);

            var amountOfSpawnPoints = possibleSpawnPoints.Length;
            var randomSpawnPointIndex = Random.Range(0, amountOfSpawnPoints);
            var spawnPoint = possibleSpawnPoints[randomSpawnPointIndex];

            enemy.transform.position = spawnPoint.position;

            yield return new WaitForSeconds(3f);
        }

        yield return new WaitForSeconds(0f);
    }
}
