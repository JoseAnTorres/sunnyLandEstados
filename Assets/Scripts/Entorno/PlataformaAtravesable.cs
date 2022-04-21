using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlataformaAtravesable : MonoBehaviour
{
    private GameObject jugador;
    private float baseJugador;
    private float mitadAlturaJugador;
    private BoxCollider2D plataforma;
    private Bounds limitesPlataforma;
    private float cimaPlataforma;
    private Color colorGizmos = Color.red;
    private bool haciendoAtravesable = false;
    private const float factorCorreccion = 0.1f;
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        mitadAlturaJugador = jugador.GetComponent<SpriteRenderer>().bounds.extents.y;
        plataforma = GetComponent<BoxCollider2D>();
        limitesPlataforma = plataforma.bounds;
        cimaPlataforma = limitesPlataforma.center.y + limitesPlataforma.extents.y;
    }
    private void Update() {
        baseJugador = jugador.transform.position.y - mitadAlturaJugador;
        if (!haciendoAtravesable && baseJugador >= cimaPlataforma - factorCorreccion)
        {
            plataforma.isTrigger = false;
            colorGizmos = Color.green;
        } 
        if (baseJugador < cimaPlataforma - factorCorreccion)
        {
            plataforma.isTrigger = true;
            colorGizmos = Color.red;
            haciendoAtravesable = false;
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = colorGizmos;
        Gizmos.DrawCube((Vector3)limitesPlataforma.center, limitesPlataforma.size);
    }
    public void HacerAtravesable()
    {
        haciendoAtravesable = true;
        plataforma.isTrigger = true;
        colorGizmos = Color.red;
    }
}
