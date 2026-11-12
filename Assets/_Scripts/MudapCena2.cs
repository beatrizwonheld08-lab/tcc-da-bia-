using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudapCena2 : MonoBehaviour
{
    public void TrocarTela(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
}
