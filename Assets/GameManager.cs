using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton & DDOL
    public static GameManager Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    public int NivelActual { get; private set; }
    private void Start()
    {
        Datos.Instancia.OnTiempoRestanteActualizado += ActualizarTiempoRestante;
        Datos.Instancia.OnVidasActualizado += ActualizarVidas;
        //Datos.Instancia.OnPuntosActualizado += Actua;
        Datos.Instancia.OnGemasActualizado += ActualizarGemas;
    }

    private void Update()
    {
        
    }

    public void MostrarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ActualizarTiempoRestante(int tiempoRestante)
    {
        if (tiempoRestante <= 0)
        {
            MostrarMenu();
        }
    }

    public void ActualizarVidas(int vidas, bool decrementadas)
    {
        if(vidas <= 0)
        {
            MostrarMenu();
        }else if (decrementadas)
        {
            ReiniciarNivel();
        }
    }

    public void ActualizarGemas(int gemas)
    {
        if (gemas <= 0)
        {
            MostrarSiguienteNivel();
        }
    }

    public void Jugar()
    {
        NivelActual = 1;
        SceneManager.LoadScene(1);
        Datos.Instancia.ReiniciarValores();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(NivelActual);
        Datos.Instancia.EstablecerValores();
    }

    public void MostrarSiguienteNivel()
    {
        SceneManager.LoadScene(++NivelActual);
        Datos.Instancia.EstablecerValores();
    }

    public void Salir() {
        Application.Quit();
    }

}
