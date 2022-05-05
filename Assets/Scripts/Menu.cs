using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator prueba;
    [SerializeField] private Animator prueba1;
    [SerializeField] private Animator prueba2;
    private void Start()
    {
        prueba.SetBool("estaOculto", false);
        prueba1.SetBool("estaOculto", false);
        prueba2.SetBool("estaOculto", false);
    }

    public void PruebaPulsado()
    {
        prueba.SetBool("estaOculto", true);
        prueba1.SetBool("estaOculto", true);
        prueba2.SetBool("estaOculto", true);
    }
}
