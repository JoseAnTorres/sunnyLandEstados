using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float efecto;
    private Camera camara;
    private Vector3 ultimaPosicionCamara;
    private void Start()
    {
        camara = Camera.main;
        ultimaPosicionCamara = camara.transform.position;
    }

    private void Update()
    {
        var movimiento = camara.transform.position - ultimaPosicionCamara;
        transform.position += new Vector3(movimiento.x * efecto, movimiento.y, 0);
        ultimaPosicionCamara = camara.transform.position;
    }
}
