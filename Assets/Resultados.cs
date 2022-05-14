using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resultados : MonoBehaviour
{
    private readonly int estaOculto = Animator.StringToHash("estaOculto");
    [SerializeField] private Animator enhorabuena;
    [SerializeField] private Animator gameOver;
    [SerializeField] private TextMeshProUGUI superadoNivel;
    [SerializeField] private TextMeshProUGUI puntosActuales;
    [SerializeField] private TextMeshProUGUI noSuperadoNivel;
    [SerializeField] private TextMeshProUGUI puntosConseguidos;
    [SerializeField] private TextMeshProUGUI infoRecord;

    private void Start()
    {
        if (GameManager.Instancia.GameOver)
        {
            MostrarGameOver();
        }
        else
        {
            MostrarEnhorabuena();
        }
    }

    private void MostrarEnhorabuena()
    {
        superadoNivel.SetText($"Has superado el nivel {GameManager.Instancia.NivelActual}");
        puntosActuales.SetText($"Puntos actuales: {Datos.Instancia.GetPuntos():00000}");
        enhorabuena.SetBool(estaOculto, false);
    }

    public void ContinuarSiguienteNivel()
    {
        GameManager.Instancia.MostrarSiguienteNivel();
    }

    private void MostrarGameOver()
    {
        var record = Datos.Instancia.GetRecord();
        var puntos = Datos.Instancia.GetPuntos();
        noSuperadoNivel.SetText($"No has superado el nivel {GameManager.Instancia.NivelActual}");
        puntosConseguidos.SetText($"Puntos conseguidos: {puntos:00000}");
        if (puntos > record)
        {
            infoRecord.SetText("Has establecido el record!!!!");
        }
        else if (puntos == record)
        {
            infoRecord.SetText("Has igualado el record!!!");
        }
        else
        {
            infoRecord.SetText($"Record actual: {record:00000}");
        }
        gameOver.SetBool(estaOculto, false);
    }

    public void VolverMenu()
    {
        GameManager.Instancia.MostrarMenu();
    }
}
