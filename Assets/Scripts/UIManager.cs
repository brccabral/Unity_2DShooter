using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    private Player localPlayer;
    private GameManager localGameManager;

    private void Start()
    {
        localPlayer = FindAnyObjectByType<Player>();
        localGameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        scoreText.text = localGameManager.GetCurrentScore().ToString();
        healthText.text = $"HEALTH: {localPlayer.health.GetHealthPoints():F1} %";
        healthText.color = Color.Lerp(Color.red, Color.green,
            Math.Clamp(localPlayer.health.GetHealthPoints(), 0, 100) / 100f);
    }
}
