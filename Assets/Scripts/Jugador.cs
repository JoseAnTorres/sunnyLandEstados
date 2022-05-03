using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Jugador : MonoBehaviour
{
    [SerializeField] private float velocidad = 5.0f;
    public float Velocidad => velocidad;
    [SerializeField] private float fuerzaSalto = 5.0f;
    private Rigidbody2D cuerpo;
    private SpriteRenderer figura;
    private Animator animador;
    private Vector2 movimiento;
    private bool salto;
    private bool estaEnSuelo;
    public bool EstaEnSuelo => estaEnSuelo;
    private LayerMask capaSuelo;
    private bool estaEnEscalera;
    public bool EstaEnEscalera => estaEnEscalera;
    private Collider2D escaleraActual;
    private LayerMask capaEscalera;
    private Collider2D sueloActual;
    public Vector2 VelocidadActual => cuerpo.velocity;

    private int puntos;
    [SerializeField] private int vidas = 3;
    [SerializeField] private int tiempoNivel;
    [SerializeField] private int gemas = 9;
    private float tiempoInicio;

    private MaquinaEstados maquinaEstados;
    public Estado parado;
    public Estado coriendo;
    public Estado saltando;
    public Estado paradoEnEscalera;
    public Estado moviendoEnEscalera;
    private void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        figura = GetComponent<SpriteRenderer>();
        animador = GetComponent<Animator>();
        capaSuelo = LayerMask.NameToLayer("Suelo");
        capaEscalera = LayerMask.NameToLayer("Escalera");

        maquinaEstados = new MaquinaEstados();
        parado = new Parado(this, maquinaEstados);
        coriendo = new Corriendo(this, maquinaEstados);
        saltando = new Saltando(this, maquinaEstados);
        paradoEnEscalera = new ParadoEnEscalera(this, maquinaEstados);
        moviendoEnEscalera = new MoviendoEnEscalera(this, maquinaEstados);
        maquinaEstados.Inicializar(parado);

        tiempoInicio = Time.time;
    }

    private void Update()
    {
        maquinaEstados.EstadoActual.GestionarEntrada(movimiento, salto);
        maquinaEstados.EstadoActual.ActualizarLogica();

        ComprobarTiempo();
    }
    private void FixedUpdate()
    {
        maquinaEstados.EstadoActual.ActualizarFisica();
    }

    private void OnMover(InputValue entrada)
    {
        movimiento = new Vector2(entrada.Get<Vector2>().x, entrada.Get<Vector2>().y);
    }

    private void OnSaltar()
    {
        salto = true;
    }

    public void SetParametroLogico(string parametro, bool valor)
    {
        animador.SetBool(parametro, valor);
    }

    public void VoltearFiguraX(bool valor)
    {
        figura.flipX = valor;
    }

    public void Saltar()
    {
        cuerpo.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        estaEnSuelo = false;
        salto = false;
    }

    public void ActivarGravedad(bool gravedad)
    {
        cuerpo.gravityScale = gravedad ? 1 : 0;
        if (!gravedad)
        {
            CentrarEnEscalera();
        }
        cuerpo.velocity = Vector2.zero;
    }

    private void CentrarEnEscalera()
    {
        if (escaleraActual)
        {
            cuerpo.transform.position = new Vector2(escaleraActual.bounds.center.x, cuerpo.transform.position.y);
        }
    }

    public void Mover(Vector2 movimiento)
    {
        cuerpo.velocity = movimiento;
    }

    public void IntentarAtravesarPlataforma()
    {
        if (sueloActual)
        {
            PlataformaAtravesable plataformaAtravesable = sueloActual.GetComponent<PlataformaAtravesable>();
            if (plataformaAtravesable)
            {
                plataformaAtravesable.HacerAtravesable();
                ResetearSuelo();
            }
        }
    }

    private void ResetearSuelo()
    {
        estaEnSuelo = false;
        sueloActual = null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == capaSuelo)
        {
            estaEnSuelo = true;
            sueloActual = other.collider;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == capaSuelo)
        {
            ResetearSuelo();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == capaEscalera)
        {
            estaEnEscalera = true;
            escaleraActual = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == capaEscalera)
        {
            estaEnEscalera = false;
            escaleraActual = null;
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log($"Puntos: {puntos}");
        UIManager.Instancia.ActualizarPuntos(puntos);
    }

    public void QuitarVida()
    {
        vidas--;
        Debug.Log($"Vidas: {vidas}");
        UIManager.Instancia.ActualizarVidas(vidas);
        if (vidas <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RecogerGema()
    {
        gemas--;
        Debug.Log($"Gemas: {gemas}");
        UIManager.Instancia.ActualizarGemas(gemas);
        if (gemas <= 0)
        {
            Debug.Log("Recogidas todas las gemas -> Pasas de nivel.");
        }
    }

    private void ComprobarTiempo()
    {
        var tiempo = Time.time - tiempoInicio;
        var tiempoRestante = tiempoNivel - (int)tiempo;
        UIManager.Instancia.ActualizarTiempo(tiempoRestante);
        if (tiempo >= tiempoNivel)
        {
            Debug.Log("Has perdido, se ha acabado el tiempo!!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}