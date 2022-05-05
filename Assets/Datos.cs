using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void ManejadorTiempoActualizado(int tiempo);
public delegate void ManejadorPuntosActualizado(int puntos);
public delegate void ManejadorVidasActualizado(int vidas);
public delegate void ManejadorGemasActualizado(int gemas);

public class Datos : MonoBehaviour
{
    private int puntos;
    [SerializeField] private int vidas = 3;
    [SerializeField] private int tiempoNivel;
    [SerializeField] private int gemas = 9;
    private float tiempoInicio;

    public event ManejadorTiempoActualizado OnTiempoActualizado;
    public event ManejadorPuntosActualizado OnPuntosActualizado;
    public event ManejadorVidasActualizado OnVidasActualizado;
    public event ManejadorGemasActualizado OnGemasActualizado;
    public static Datos Instancia { get; private set; }

    private void Awake()
    {
        if(Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    private void Start()
    {
        tiempoInicio = Time.time;
    }
    private void Update()
    {
        ComprobarTiempo();
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log($"Puntos: {puntos}");
        //UIManager.Instancia.ActualizarPuntos(puntos);
        OnPuntosActualizado?.Invoke(puntos);
    }
    public void QuitarVida()
    {
        vidas--;
        Debug.Log($"Vidas: {vidas}");
        //UIManager.Instancia.ActualizarVidas(vidas);
        OnVidasActualizado?.Invoke(vidas);
        if (vidas <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void RecogerGema()
    {
        gemas--;
        Debug.Log($"Gemas: {gemas}");
        //UIManager.Instancia.ActualizarGemas(gemas);
        OnGemasActualizado?.Invoke(gemas);
        if (gemas <= 0)
        {
            Debug.Log("Recogidas todas las gemas -> Pasas de nivel.");
        }
    }
    private void ComprobarTiempo()
    {
        var tiempo = Time.time - tiempoInicio;
        var tiempoRestante = tiempoNivel - (int)tiempo;
        //UIManager.Instancia.ActualizarTiempo(tiempoRestante);
        OnTiempoActualizado?.Invoke(tiempoRestante);
        if (tiempo >= tiempoNivel)
        {
            Debug.Log("Has perdido, se ha acabado el tiempo!!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
