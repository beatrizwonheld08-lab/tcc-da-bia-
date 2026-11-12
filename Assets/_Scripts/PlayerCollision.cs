using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public bool gameOver = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            Time.timeScale = 0f;
            Morrer();
            Debug.Log("GAME OVER!");
        }
    }
    void Morrer()
    {
        SceneManager.LoadScene("MenuMorte");
    }
}