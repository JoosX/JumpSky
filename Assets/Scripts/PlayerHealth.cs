using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int vidaMaxima = 100;
    [SerializeField] private float duracionFlash = 0.15f; // Cuánto dura el parpadeo en rojo
    
    private int vida;
    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            colorOriginal = spriteRenderer.color;
        }
    }

    void Start()
    {
        vida = vidaMaxima;
        UIManager.Instance.ActualizarVida(vida, vidaMaxima);
    }

    public void RecibirDanio(int cantidad)
    {
        vida = Mathf.Max(0, vida - cantidad);
        UIManager.Instance.ActualizarVida(vida, vidaMaxima);

        // Dispara el parpadeo en rojo si tiene SpriteRenderer
        if (spriteRenderer != null)
        {
            StartCoroutine(FlashDanio());
        }

        if (vida <= 0)
        {
            Morir();
        }
    }

    private IEnumerator FlashDanio()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(duracionFlash);
        spriteRenderer.color = colorOriginal;
    }

    void Morir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}