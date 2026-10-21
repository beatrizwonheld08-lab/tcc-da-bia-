using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadePista = 10f;
    public float distanciaEntrePistas = 2f;

    private int pistaAtual = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoverEsquerda();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoverDireita();
        }
    }

    void MoverEsquerda()
    {
        if (pistaAtual > -1)
        {
            pistaAtual--;
            pistaAtual = Mathf.Clamp(pistaAtual, -1, 1);
        }
    }

    void MoverDireita()
    {
        if (pistaAtual < 1)
        {
            pistaAtual++;
            pistaAtual = Mathf.Clamp(pistaAtual, -1, 1);
        }
    }

    void FixedUpdate()
    {
        Vector2 novaPosicao = new Vector2(
            pistaAtual * distanciaEntrePistas,
            transform.position.y
        );

        transform.position = Vector2.Lerp(
            transform.position,
            novaPosicao,
            velocidadePista * Time.fixedDeltaTime
        );
    }
}