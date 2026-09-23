using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Image barraVida;
    [SerializeField] private TMP_Text textoPuntos;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ActualizarVida(int actual, int max)
    {
        barraVida.fillAmount = (float)actual / max;
    }

    public void ActualizarPuntos(int puntos)
    {
        textoPuntos.text = puntos.ToString("D4");
    }
}