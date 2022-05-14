using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : Coleccionable
{
    protected override void Recoger()
    {
        Datos.Instancia.RecogerVida();
        Audio.Instancia.PlayGema();
    }
}
