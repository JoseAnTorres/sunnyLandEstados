using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instancia { get; private set; }
    [SerializeField] private TMP_Text puntos;
    private void Awake()
    {
        if(Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }

    public void ActualizarPuntos(int puntos)
    {
        this.puntos.SetText($"{puntos:D5}");
    }
}
