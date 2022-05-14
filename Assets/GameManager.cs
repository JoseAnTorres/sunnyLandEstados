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
    public bool GameOver { get; private set; }
    private void Start()
    {
        Datos.Instancia.OnTiempoRestanteActualizado += ActualizarTiempoRestante;
        Datos.Instancia.OnVidasActualizado += ActualizarVidas;
        Datos.Instancia.OnGemasActualizado += ActualizarGemas;
    }

    public void MostrarMenu()
    {
        SceneManager.LoadScene("Menu");
        Audio.Instancia.PlayIntroduccion();
    }

    public void ActualizarTiempoRestante(int tiempoRestante)
    {
        if (tiempoRestante <= 0)
        {
            MostrarResultados(true);
        }
    }

    public void ActualizarVidas(int vidas, bool decrementadas)
    {
        if(vidas <= 0)
        {
            Audio.Instancia.PlayMuerte();
            MostrarResultados(true);
        }
        else if (decrementadas)
        {
            Audio.Instancia.PlayMuerte();
            ReiniciarNivel();
        }
    }

    public void ActualizarGemas(int gemas)
    {
        if (gemas <= 0)
        {
            MostrarResultados(false);
        }
    }

    public void Jugar()
    {
        NivelActual = 1;
        SceneManager.LoadScene(1);
        Datos.Instancia.ReiniciarValores();
        Audio.Instancia.PlayNivel();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(NivelActual);
        Datos.Instancia.EstablecerValores();
        Audio.Instancia.PlayNivel();
    }

    public void MostrarSiguienteNivel()
    {
        SceneManager.LoadScene(++NivelActual);
        Datos.Instancia.EstablecerValores();
        Audio.Instancia.PlayNivel();
    }

    public void Salir() {
        Application.Quit();
    }

    private void MostrarResultados(bool gameOver)
    {
        GameOver = gameOver;
        SceneManager.LoadScene("Resultados");
        Audio.Instancia.PlayIntroduccion();
    }

}
