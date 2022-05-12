using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator jugar;
    [SerializeField] private Animator creditos;
    [SerializeField] private Animator creditosfull;
    [SerializeField] private Animator salir;
    //[SerializeField] private Animator prueba2;
    private void Start()
    {
        MostrarBotones();
    }

    public void MostrarBotones()
    {
        jugar.SetBool("estaOculto", false);
        creditos.SetBool("estaOculto", false);
        salir.SetBool("estaOculto", false);
    }

    public void PruebaPulsado()
    {
        jugar.SetBool("estaOculto", true);
        creditos.SetBool("estaOculto", true);
        salir.SetBool("estaOculto", true);
        //prueba2.SetBool("estaOculto", true);
    }
    private void OcultarBotones()
    {
        jugar.SetBool("estaOculto", true);
        creditos.SetBool("estaOculto", true);
        salir.SetBool("estaOculto", true);
    }

    public void PruebaCreditos()
    {
        jugar.SetBool("estaOculto", true);
        creditos.SetBool("estaOculto", true);
        salir.SetBool("estaOculto", true);

        creditosfull.enabled = !creditosfull.enabled;
        creditosfull.SetBool("estaOculto", false);
    }

    public void Jugar()
    {
        StartCoroutine(OcultarBotonesYJugar());
    }

    public void Salir()
    {
        StartCoroutine(OcultarBotonesYSalir());
    }

    private IEnumerator OcultarBotonesYJugar()
    {
        OcultarBotones();
        yield return new WaitForSeconds(1.0f);
        GameManager.Instancia.Jugar();
    }
    private IEnumerator OcultarBotonesYSalir()
    {
        OcultarBotones();
        yield return new WaitForSeconds(1.0f);
        GameManager.Instancia.Salir();
    }

    public void Cerrar()
    {
        jugar.SetBool("estaOculto", false);
        creditos.SetBool("estaOculto", false);
        salir.SetBool("estaOculto", false);
        creditosfull.SetBool("estaOculto", true);
    }
}
