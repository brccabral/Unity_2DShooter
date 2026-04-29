using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player mainPlayer;

    [SerializeField] [Space(10)] private int currentScore;

    [SerializeField] [Space(10)] private Transform enemyHolder;
    public Transform projectileHolder;

    [SerializeField] [Header("Enemies")] private List<Enemy> allSpawnedEnemies;
    [SerializeField] private Enemy[] possibleEnemyPrefabs;
    [SerializeField] private Transform[] possibleSpawnPoints;

    [SerializeField] [Header("Pickups")] private Pickup[] possiblePickupsPrefabs;
    [SerializeField] private float chanceSpawnPickup;
    private int highestScore;
    private AudioManager audioManager;

    public void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        highestScore = PlayerPrefs.GetInt("HighestScore");
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
        if (Random.Range(0, 100) < chanceSpawnPickup)
        {
            SpawnRandomPickup(enemy.transform.position);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void RegisterHighScore()
    {
        if (currentScore > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", currentScore);
            highestScore = currentScore;
        }
    }

    private void SpawnRandomPickup(Vector2 position)
    {
        var randomIndex = Random.Range(0, possiblePickupsPrefabs.Length);
        var pickup = Instantiate(possiblePickupsPrefabs[randomIndex], position, Quaternion.identity);
        pickup.SetAudioManager(audioManager);
    }
}
