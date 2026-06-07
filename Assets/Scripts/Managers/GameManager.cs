using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] [Space(10)] private int currentScore;

    [SerializeField] [Space(10)] private Transform enemyHolder;
    public Transform projectileHolder;

    [SerializeField] [Header("Enemies")] private Enemy[] possibleEnemyPrefabs;
    [SerializeField] private Transform[] possibleSpawnPoints;

    [SerializeField] [Header("Pickups")] private Pickup[] possiblePickupsPrefabs;
    [SerializeField] private float chanceSpawnPickup;

    [SerializeField] private GameObject gamePlayUI;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private TextMeshProUGUI finalScoreText;
    private List<Enemy> allSpawnedEnemies;
    private List<Pickup> allSpawnedPickups;
    private int highestScore;
    private AudioManager audioManager;

    private float spawnRate = 3f;
    private int maxEnemies = 11;
    private float sceneTime;

    public void Start()
    {
        allSpawnedEnemies = new List<Enemy>();
        allSpawnedPickups = new List<Pickup>();

        audioManager = FindAnyObjectByType<AudioManager>();
        highestScore = PlayerPrefs.GetInt("HighestScore");
        RestartGame();
    }

    private void Update()
    {
        sceneTime += Time.deltaTime;
    }

    private IEnumerator SpawnRandomEnemy()
    {
        while (player.isActiveAndEnabled)
        {
            if (sceneTime > 60 * 2)
            {
                spawnRate = 1f;
                maxEnemies = 20;
            }
            else if (sceneTime > 60 * 1)
            {
                spawnRate = 2f;
                maxEnemies = 15;
            }

            if (allSpawnedEnemies.Count >= maxEnemies)
            {
                yield return new WaitForSeconds(spawnRate);

                continue;
            }

            var amountOfIndexes = possibleEnemyPrefabs.Length;
            var randomIndex = Random.Range(0, amountOfIndexes);
            var enemy = Instantiate(possibleEnemyPrefabs[randomIndex], enemyHolder);
            enemy.SetPlayer(player);
            allSpawnedEnemies.Add(enemy);

            var amountOfSpawnPoints = possibleSpawnPoints.Length;
            var randomSpawnPointIndex = Random.Range(0, amountOfSpawnPoints);
            var spawnPoint = possibleSpawnPoints[randomSpawnPointIndex];

            enemy.transform.position = spawnPoint.position;

            yield return new WaitForSeconds(spawnRate);
        }

        yield return new WaitForSeconds(0f);
    }

    public void EnemyKilled(Enemy enemy)
    {
        allSpawnedEnemies.Remove(enemy);
        Destroy(enemy.gameObject);

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

    public void GameOver()
    {
        RegisterHighScore();
        gamePlayUI.SetActive(false);

        finalScoreText.text = $"Your final score: {currentScore}";
        gameOverUI.SetActive(true);

        foreach (var enemy in allSpawnedEnemies)
        {
            Destroy(enemy.gameObject);
        }

        foreach (var pickup in allSpawnedPickups)
        {
            Destroy(pickup.gameObject);
        }

        allSpawnedEnemies.Clear();
        allSpawnedPickups.Clear();
    }

    public void RestartGame()
    {
        currentScore = 0;
        player.Reset();
        gamePlayUI.SetActive(true);
        gameOverUI.SetActive(false);
        spawnRate = 3f;
        maxEnemies = 11;
        sceneTime = 0;
        StartCoroutine(SpawnRandomEnemy());
    }

    private void RegisterHighScore()
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
        allSpawnedPickups.Add(pickup);
    }

    public void RemovePickup(Pickup pickup)
    {
        allSpawnedPickups.Remove(pickup);
        Destroy(pickup.gameObject);
    }

    public void Nuke()
    {
        for (var i = allSpawnedEnemies.Count - 1; i >= 0; i--)
        {
            allSpawnedEnemies[i].health.DecreaseHealth(allSpawnedEnemies[i].health.GetHealthPoints() + 1);
        }

        foreach (var pickup in allSpawnedPickups)
        {
            Destroy(pickup.gameObject);
        }

        allSpawnedPickups.Clear();
    }
}
