using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator prueba;
    private void Start()
    {
        prueba.SetBool("estaOculto", false);
    }

    public void PruebaPulsado()
    {
        prueba.SetBool("estaOculto", true);
    }
}
