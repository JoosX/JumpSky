using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int puntuacion = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SumarPuntos(int puntos)
    {
        puntuacion += puntos;
        UIManager.Instance.ActualizarPuntos(puntuacion);
    }
}