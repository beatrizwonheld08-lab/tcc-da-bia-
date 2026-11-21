
using UnityEngine;

public class ItemCollectible : MonoBehaviour
{
    public string itemID;
    public string nomeItem;

    public void Configurar(string id, Sprite imagem)
    {
        itemID = id;

        GetComponent<SpriteRenderer>().sprite = imagem;
    }
}
