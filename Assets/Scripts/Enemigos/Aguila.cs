using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Aguila : Enemigo
{
    [SerializeField] private List<Vector2> camino;
    [SerializeField] private float maximaVelocidad = 5.0f;

    protected override void Start()
    {
        transform.position = camino[0];
        base.Start();
    }

    protected override IEnumerator Mover()
    {
        while (true)
        {
            foreach (var punto in camino)
            {
                if ((Vector2)transform.position != punto)
                {
                    ComprobarVoltear(punto);
                    yield return StartCoroutine(MoverADestino(punto));
                    yield return StartCoroutine(Descansar());
                }
            }
        }
    }

    private void ComprobarVoltear(Vector2 punto)
    {
        figura.flipX = transform.position.x < punto.x || transform.position.x == punto.x;
    }

    private IEnumerator MoverADestino(Vector2 destino)
    {
        while ((Vector2)transform.position != destino)
        {
            yield return null;
            transform.position = Vector2.MoveTowards(transform.position, destino, maximaVelocidad * Time.deltaTime);
        }
    }

}
