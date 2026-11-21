
using UnityEngine;
using TMPro;

[System.Serializable]
public class CartaColecao
{
    public string idItem;

    public GameObject bloqueado;
    public GameObject desbloqueado;

    public string codigoPromocional;
    public TMP_Text textoCodigo;
}

public class ArmarioUI : MonoBehaviour
{
    public CartaColecao[] cartas = new CartaColecao[7];

    void OnEnable()
    {
        AtualizarColecao();
    }

    public void AtualizarColecao()
    {
        if (InventoryManager.Instance == null)
        {
            Debug.LogWarning(
                "InventoryManager não encontrado no Armário!"
            );
            return;
        }

        foreach (CartaColecao carta in cartas)
        {
            bool possui =
                InventoryManager.Instance.PossuiItem(
                    carta.idItem
                );

            if (carta.bloqueado != null)
            {
                carta.bloqueado.SetActive(!possui);
            }

            if (carta.desbloqueado != null)
            {
                carta.desbloqueado.SetActive(possui);
            }

            if (carta.textoCodigo != null)
            {
                carta.textoCodigo.text = possui
                    ? carta.codigoPromocional
                    : "???";
            }
        }
    }
}
