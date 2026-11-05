
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class InventoryData
{
    public List<string> itens = new List<string>();
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<string> itensDesbloqueados = new List<string>();

    private string chaveSave = "InventarioDRIPLAB";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CarregarInventario();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdicionarItem(string id)
    {
        if (!itensDesbloqueados.Contains(id))
        {
            itensDesbloqueados.Add(id);

            SalvarInventario();

            Debug.Log("Item desbloqueado: " + id);
        }
        else
        {
            Debug.Log("Você já possui este item!");
        }
    }

    public bool PossuiItem(string id)
    {
        return itensDesbloqueados.Contains(id);
    }

    void SalvarInventario()
    {
        InventoryData dados = new InventoryData();
        dados.itens = itensDesbloqueados;

        string json = JsonUtility.ToJson(dados);

        PlayerPrefs.SetString(chaveSave, json);
        PlayerPrefs.Save();
    }

    void CarregarInventario()
    {
        if (PlayerPrefs.HasKey(chaveSave))
        {
            string json = PlayerPrefs.GetString(chaveSave);

            InventoryData dados =
                JsonUtility.FromJson<InventoryData>(json);

            if (dados != null && dados.itens != null)
            {
                itensDesbloqueados = dados.itens;
            }
        }
    }
}
