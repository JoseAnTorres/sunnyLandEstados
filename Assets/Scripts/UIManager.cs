using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instancia { get; private set; }
    [SerializeField] private TextMeshProUGUI puntos;
    [SerializeField] private TextMeshProUGUI tiempo;
    [SerializeField] private float retardoPuntos = 0.3f;
    private void Awake()
    {
        if(Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }

    public void ActualizarPuntos(int puntos)
    {
        var puntosActuales = int.Parse(this.puntos.text);
        StartCoroutine(AnimarPuntos(puntosActuales, puntos));
    }
    public void ActualizarTiempo(int tiempo)
    {
        this.tiempo.SetText($"{tiempo / 60:00}:{tiempo % 60:00}");
    }
    private IEnumerator AnimarPuntos(int anteriores, int actuales)
    {
        var incremento = (anteriores < actuales) ? 1 : -1;
        while(anteriores != actuales)
        {
            anteriores += incremento;
            puntos.SetText($"{anteriores:D5}");
            yield return new WaitForSeconds(retardoPuntos);
        }
    }
}