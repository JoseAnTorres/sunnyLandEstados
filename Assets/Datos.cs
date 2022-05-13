using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datos : MonoBehaviour
{
    [SerializeField] private int tiempoNivel = 300;
    [SerializeField] private int vidasIniciales = 3;
    [SerializeField] private int gemasIniciales = 9;

    private float tiempoInicio;
    private int tiempoRestantes;
    private int puntos;
    private int vidas;
    private int gemas;

    #region Delegados y Eventos
    public delegate void ManejadorTiempoRestanteActualizado(int tiempo);
    public event ManejadorTiempoRestanteActualizado OnTiempoRestanteActualizado;
    public delegate void ManejadorPuntosActualizado(int puntos);
    public event ManejadorPuntosActualizado OnPuntosActualizado;
    public delegate void ManejadorVidasActualizado(int vidas, bool decrementas = false);
    public event ManejadorVidasActualizado OnVidasActualizado;
    public delegate void ManejadorGemasActualizado(int gemas);
    public event ManejadorGemasActualizado OnGemasActualizado;
    #endregion

    #region Singleton
    public static Datos Instancia { get; private set; }

    private void Awake()
    {
        if(Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    #endregion
    
    private void Start()
    {
        ReiniciarValores();
    }
    private void Update()
    {
        ActualizarTiempoRestante();
    }

    private void ActualizarTiempoRestante()
    {
        var tiempoTranscurrido = Time.time - tiempoInicio;
        tiempoRestantes = tiempoNivel - (int)tiempoTranscurrido;
        OnTiempoRestanteActualizado?.Invoke(tiempoRestantes);
    }

    public void ReiniciarValores()
    {
        EstablecerTiempoInicio();
        vidas = vidasIniciales;
        OnVidasActualizado?.Invoke(vidas);
        puntos = 0;
        OnPuntosActualizado?.Invoke(puntos);
        EstablecerGemasIniciales();
    }

    public void EstablecerValores()
    {
        EstablecerTiempoInicio();
        OnVidasActualizado?.Invoke(vidas);
        OnPuntosActualizado?.Invoke(puntos);
        EstablecerGemasIniciales();
    }

    public void EstablecerTiempoInicio()
    {
        this.tiempoInicio = Time.time;
        ActualizarTiempoRestante();
    }

    public void EstablecerGemasIniciales()
    {
        gemas = gemasIniciales;
        OnGemasActualizado?.Invoke(gemas);
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log($"Puntos: {puntos}");
        //UIManager.Instancia.ActualizarPuntos(puntos);
        OnPuntosActualizado?.Invoke(puntos);
    }
    public void DecrementarVida()
    {
        vidas--;
        OnVidasActualizado?.Invoke(vidas, true);
    }
    public void RecogerGema()
    {
        gemas--;
        OnGemasActualizado?.Invoke(gemas);
    }
    public void RecogerVida()
    {
        vidas++;
        OnVidasActualizado?.Invoke(vidas);
    }
    private void ComprobarTiempo()
    {
        var tiempo = Time.time - tiempoInicio;
        var tiempoRestante = tiempoNivel - (int)tiempo;
        //UIManager.Instancia.ActualizarTiempo(tiempoRestante);
        OnTiempoRestanteActualizado?.Invoke(tiempoRestante);
        if (tiempo >= tiempoNivel)
        {
            Debug.Log("Has perdido, se ha acabado el tiempo!!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
