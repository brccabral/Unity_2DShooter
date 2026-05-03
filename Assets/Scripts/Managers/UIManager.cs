using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private Player localPlayer;
    [SerializeField] private GameManager localGameManager;

    private void Start()
    {
        highScoreText.text = localGameManager.GetHighestScore().ToString();
    }

    private void Update()
    {
        scoreText.text = localGameManager.GetCurrentScore().ToString();
        highScoreText.text = localGameManager.GetHighestScore().ToString();
        if (localPlayer.isActiveAndEnabled)
        {
            healthText.text = $"HEALTH: {localPlayer.health.GetHealthPoints():F1} %";
            healthText.color = Color.Lerp(Color.red, Color.green,
                Math.Clamp(localPlayer.health.GetHealthPoints(), 0, 100) / 100f);
        }
    }
}
