using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Character randomCharacter;
    [SerializeField] private Player mainPlayer;
    [SerializeField] private Enemy randomEnemy;

    public void Start()
    {
        if (mainPlayer.GetComponent<IDash>() != null)
        {
            Debug.Log("Player has Dash");
        }
    }
}
