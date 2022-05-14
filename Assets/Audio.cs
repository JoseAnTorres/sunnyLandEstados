using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource musica;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip introduccion;
    [SerializeField] private AudioClip nivel;
    [SerializeField] private AudioClip salto;
    [SerializeField] private AudioClip muerte;
    [SerializeField] private AudioClip enemigo;
    [SerializeField] private AudioClip cereza;
    [SerializeField] private AudioClip gema;

    #region Singleton
    public static Audio Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    #endregion

    public void PlayIntroduccion()
    {
        musica.clip = introduccion;
        musica.Play();
    }

    public void PlayNivel()
    {
        musica.clip = nivel;
        musica.Play();
    }
    public void PlaySalto()
    {
        sfx.clip = salto;
        sfx.Play();
    }
    public void PlayMuerte()
    {
        sfx.clip = muerte;
        sfx.Play();
    }
    public void PlayEnemigo()
    {
        sfx.clip = enemigo;
        sfx.Play();
    }
    public void PlayCereza()
    {
        sfx.clip = cereza;
        sfx.Play();
    }
    public void PlayGema()
    {
        sfx.clip = gema;
        sfx.Play();
    }
}
