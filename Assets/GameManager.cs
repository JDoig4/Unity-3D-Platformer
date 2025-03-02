using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private CoinTrigger[] coins;

    void Start()
    {
        coins = FindObjectsByType<CoinTrigger>(
            FindObjectsInactive.Exclude,
            FindObjectsSortMode.None
        );

        foreach (CoinTrigger coin in coins)
        {
            coin.OnCoinCollected.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        Debug.Log($"Score Updated: {score}");
        scoreText.text = $"Score: {score}";
    }
}