
using UnityEngine;

public class ItemRaroColetavel : MonoBehaviour
{
    public string idItem;

    public void Configurar(string novoId)
    {
        idItem = novoId;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (InventoryManager.Instance == null)
        {
            Debug.LogWarning(
                "InventoryManager não encontrado!"
            );
            return;
        }

        if (string.IsNullOrEmpty(idItem))
        {
            Debug.LogWarning(
                "Item raro sem ID configurado!"
            );
            return;
        }

        InventoryManager.Instance.AdicionarItem(idItem);

        Debug.Log("Item raro coletado: " + idItem);

        Destroy(gameObject);
    }
}
