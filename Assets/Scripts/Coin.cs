using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int valor = 100;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SumarPuntos(valor);
            Destroy(gameObject);
        }
    }
}