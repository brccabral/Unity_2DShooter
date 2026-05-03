using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private Player player;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject[] nukes;

    private void Start()
    {
        highScoreText.text = gameManager.GetHighestScore().ToString();
    }

    private void Update()
    {
        scoreText.text = gameManager.GetCurrentScore().ToString();
        highScoreText.text = gameManager.GetHighestScore().ToString();
        if (player.isActiveAndEnabled)
        {
            healthText.text = $"HEALTH: {player.health.GetHealthPoints():F1} %";
            healthText.color = Color.Lerp(Color.red, Color.green,
                Math.Clamp(player.health.GetHealthPoints(), 0, 100) / 100f);
        }

        var nukesCount = player.GetNukesCount();
        var n = 0;
        foreach (var nuke in nukes)
        {
            nuke.SetActive(n < nukesCount);
            n++;
        }
    }
}
