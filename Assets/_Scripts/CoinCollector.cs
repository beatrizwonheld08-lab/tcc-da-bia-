
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AdicionarMoeda();

                Debug.Log("Moeda coletada!");
            }
            else
            {
                Debug.LogWarning(
                    "CoinCollector: GameManager não encontrado!"
                );

                return;
            }

            Destroy(other.gameObject);
        }
    }
}
