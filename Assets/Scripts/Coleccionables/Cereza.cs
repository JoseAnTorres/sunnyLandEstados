using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cereza : Coleccionable
{
    [SerializeField] private int puntos = 2;
    protected override void Recoger(Jugador jugador)
    {
        jugador.SumarPuntos(puntos);
    }
}
