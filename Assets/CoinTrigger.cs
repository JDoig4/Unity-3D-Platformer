using UnityEngine;
using UnityEngine.Events;

public class CoinTrigger : MonoBehaviour
{
    public UnityEvent OnCoinCollected = new UnityEvent();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin triggered!"); // Test if this appears
            OnCoinCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}