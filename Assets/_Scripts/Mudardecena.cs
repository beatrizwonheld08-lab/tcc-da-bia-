using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mudardecena : MonoBehaviour
{
    [SerializeField] private string nameSceneGamer;
    [SerializeField] private string nameSceneCabinet;
    public void TrocarTela(string nomeCena)
    {
        if (nomeCena != null)
            SceneManager.LoadScene(nomeCena);

    }

    public void OpenCabinet() 
    {
        SceneManager.LoadScene(nameSceneCabinet);
    }


    public void OpenPlay()
    {
        SceneManager.LoadScene(nameSceneGamer);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}