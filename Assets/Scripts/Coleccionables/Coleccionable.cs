using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Coleccionable : MonoBehaviour
{
    private Animator animador;
    private bool destruyendo = false;
    protected abstract void Recoger();
    private void Start() 
    {
        animador = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player") && !destruyendo)
        {
            destruyendo = true;
            Recoger();
            animador.SetTrigger("estaDestruyendo");
            Destroy(gameObject, 0.3f);
        }
    }
}
