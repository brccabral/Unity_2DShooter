using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player mainPlayer;

    [SerializeField] private List<Enemy> allSpawnedEnemies;
    [SerializeField] private Enemy[] possibleEnemyPrefabs;

    public void Start()
    {
        if (mainPlayer.GetComponent<IDash>() != null)
        {
            Debug.Log("Player has Dash");
        }

        InvokeRepeating(nameof(SpawnRandomEnemy), 2f, 3f);
    }

    private void SpawnRandomEnemy()
    {
        if (allSpawnedEnemies.Count > 9)
        {
            return;
        }

        var amountOfIndexes = possibleEnemyPrefabs.Length;
        var randomIndex = Random.Range(0, amountOfIndexes);
        var enemy = Instantiate(possibleEnemyPrefabs[randomIndex]);
        allSpawnedEnemies.Add(enemy);
    }
}
