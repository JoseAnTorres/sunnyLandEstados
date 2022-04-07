using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : MonoBehaviour
{
    [SerializeField] private float maximoFuerzaImpulso = 5.0f;
    [SerializeField] private float maximoTiempoDescanso = 2.0f;
    private Animator animador;
    private SpriteRenderer figura;
    private Rigidbody2D cuerpo;
    private Vector2 destino;
    private readonly Vector2 saltoIzquierda = new(-0.5f, 5f);
    private readonly Vector2 saltoDerecha = new(0.5f, 5f);
    private void Start()
    {
        figura = GetComponent<SpriteRenderer>();
        cuerpo = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        destino = saltoIzquierda;
        StartCoroutine(Mover());
    }
    private IEnumerator Saltar(Vector2 direccion)
    {
        animador.SetBool("estaSaltando", true);
        Vector2 impulso = new(direccion.x * Random.Range(1f, maximoFuerzaImpulso), direccion.y);
        cuerpo.AddForce(impulso, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        animador.SetBool("estaSaltando", false);
    }
    private IEnumerator Mover()
    {
        while (true)
        {
            yield return StartCoroutine(Saltar(destino));
            yield return StartCoroutine(Descansar());
            CalcularNuevoDestino();
        }
    }
    private void CalcularNuevoDestino()
    {
        destino = destino == saltoIzquierda ? saltoDerecha : saltoIzquierda;
        figura.flipX = destino.x > 0;
    }
    private IEnumerator Descansar()
    {
        yield return new WaitForSeconds(Random.Range(0f, maximoTiempoDescanso));
    }
}
