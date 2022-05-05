using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gema : Coleccionable
{
    protected override void Recoger()
    {
        Datos.Instancia.RecogerGema();
    }
}
