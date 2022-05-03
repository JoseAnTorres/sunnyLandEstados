using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rana : Enemigo
{
    [SerializeField] private float maximoFuerzaImpulso = 5.0f;
    private Rigidbody2D cuerpo;
    private Vector2 destino;
    private readonly Vector2 saltoIzquierda = new(-0.5f, 5f);
    private readonly Vector2 saltoDerecha = new(0.5f, 5f);

    protected override void Start() {
        cuerpo = GetComponent<Rigidbody2D>();
        destino = saltoIzquierda;
        base.Start();
    }

    private IEnumerator Saltar(Vector2 direccion)
    {
        animador.SetBool("estaSaltando", true);
        Vector2 impulso = new(direccion.x * Random.Range(1f, maximoFuerzaImpulso), direccion.y);
        cuerpo.AddForce(impulso, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        animador.SetBool("estaSaltando", false);
    }
    protected override IEnumerator Mover()
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

}
