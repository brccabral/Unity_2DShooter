using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player mainPlayer;

    [SerializeField] private List<Enemy> allSpawnedEnemies;
    [SerializeField] private Enemy[] possibleEnemyPrefabs;
    [SerializeField] private Transform[] possibleSpawnPoints;
    [SerializeField] private Transform enemyHolder;
    public Transform projectileHolder;
    [SerializeField] private int currentScore;
    
    [SerializeField] private Pickup[] possiblePickupsPrefabs;
    [SerializeField] private float chanceSpawnPickup;

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
            var enemy = Instantiate(possibleEnemyPrefabs[randomIndex], enemyHolder);
            allSpawnedEnemies.Add(enemy);

            var amountOfSpawnPoints = possibleSpawnPoints.Length;
            var randomSpawnPointIndex = Random.Range(0, amountOfSpawnPoints);
            var spawnPoint = possibleSpawnPoints[randomSpawnPointIndex];

            enemy.transform.position = spawnPoint.position;

            yield return new WaitForSeconds(3f);
        }

        yield return new WaitForSeconds(0f);
    }

    public void EnemyKilled(Enemy enemy)
    {
        allSpawnedEnemies.Remove(enemy);

        currentScore += enemy.score;

        // spawn "pick up"
        if(Random.Range(0, 100) < chanceSpawnPickup)
        {
            SpawnRandomPickup(enemy.transform.position);
        }

        // TODO
        // increase score
        // play sound
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void RegisterHighScore()
    {
        if (currentScore > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", currentScore);
        }
    }

    private void SpawnRandomPickup(Vector2 position)
    {
        var randomIndex = Random.Range(0, possiblePickupsPrefabs.Length);
        var pickup = Instantiate(possiblePickupsPrefabs[randomIndex], position, Quaternion.identity);
    }
}
