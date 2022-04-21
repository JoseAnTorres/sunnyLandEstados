using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public abstract class Enemigo : MonoBehaviour
{
    protected SpriteRenderer figura;
    protected Animator animador;
    [SerializeField] private float maximaTiempoDescanso = 2.0f;
    [SerializeField] private int puntos = 10;
    private bool destruyendo;
    protected virtual void Start()
    {
        figura = GetComponent<SpriteRenderer>();
        animador = GetComponent<Animator>();
        StartCoroutine(Mover());
    }
    protected abstract IEnumerator Mover();

    protected IEnumerator Descansar()
    {
        yield return new WaitForSeconds(Random.Range(0f, maximaTiempoDescanso));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !destruyendo)
        {
            var centro = transform.position;
            var extents = figura.bounds.extents;
            var izquierdaArriba = Physics2D.Raycast(new Vector2(centro.x - extents.x, centro.y + extents.y), Vector2.up, 0.2f);
            var centroArriba = Physics2D.Raycast(new Vector2(centro.x, centro.y + extents.y), Vector2.up, 0.2f);
            var derechaArriba = Physics2D.Raycast(new Vector2(centro.x + extents.x, centro.y + extents.y), Vector2.up, 0.2f);
            var jugador = other.gameObject.GetComponent<Jugador>();
            if(derechaArriba && derechaArriba.collider.gameObject.CompareTag("Player") 
                || izquierdaArriba && izquierdaArriba.collider.gameObject.CompareTag("Player") 
                || centroArriba && centroArriba.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("SALTO");
                jugador.SumarPuntos(puntos);
                destruyendo = true;
                animador.SetTrigger("estaMuriendo");
                Destroy(gameObject, 0.25f);
            }
            else
            {
                Debug.Log("COLISION");
                jugador.QuitarVida();
            }
        }
    }
}
