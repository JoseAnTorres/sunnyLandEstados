using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Aguila : MonoBehaviour
{
    [SerializeField] private List<Vector2> camino;
    [SerializeField] private float maximaVelocidad = 5.0f;
    [SerializeField] private float maximaTiempoDescanso = 2.0f;
    private SpriteRenderer figura;
    private void Start()
    {
        transform.position = camino[0];
        figura = GetComponent<SpriteRenderer>();
        StartCoroutine(Mover());
    }

    private IEnumerator Mover()
    {
        while (true)
        {
            foreach (var punto in camino)
            {
                MoverADestino(punto);
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
        var velocidad = Random.Range(1f, maximaVelocidad);
        while((Vector2)transform.position != destino)
        {
            yield return null;
            transform.position = Vector2.MoveTowards(transform.position, destino, maximaVelocidad * Time.deltaTime);
        }
    }

    private IEnumerator Descansar()
    {
        yield return new WaitForSeconds(Random.Range(0f, maximaTiempoDescanso));
    }
}
