using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Datos.Instancia.OnTiempoActualizado += ProbarTiempo;
        Datos.Instancia.OnVidasActualizado += ProbarVidas;
        Datos.Instancia.OnPuntosActualizado += ProbarPuntos;
        Datos.Instancia.OnGemasActualizado += ProbarGemas;
    }

    private void Update()
    {
        
    }

    public void ProbarTiempo(int tiempo)
    {
        Debug.Log($"Tiempo desde el GameManager: {tiempo}");
    }
    public void ProbarVidas(int vidas)
    {
        Debug.Log($"Vidas desde el GameManager: {vidas}");
    }
    public void ProbarPuntos(int puntos)
    {
        Debug.Log($"Puntos desde el GameManager: {puntos}");
    }
    public void ProbarGemas(int gemas)
    {
        Debug.Log($"Gemas desde el GameManager: {gemas}");
    }
}
