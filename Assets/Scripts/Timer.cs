using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Transform timerBar;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    private float timeLeft;

    private void Start()
    {
        timeLeft = duration;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);

            return;
        }

        var scale = timerBar.localScale;
        scale.x = timeLeft / duration;
        timerBar.localScale = scale;

        transform.position = playerTransform.position + offset;
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void SetPlayerTransform(Transform newTransform)
    {
        playerTransform = newTransform;
    }
}
