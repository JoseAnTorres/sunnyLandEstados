using UnityEngine;

public class EnSuelo : Estado
{
    public EnSuelo(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {
    }
    
    public override void ActualizarLogica()
    {
        base.ActualizarLogica();
        if (salto && jugador.EstaEnSuelo)
        {
            maquinaEstados.CambiarEstado(jugador.saltando);
        }
        if (movimiento.y < 0)
        {
            jugador.IntentarAtravesarPlataforma();
            if (jugador.EstaEnEscalera)
            {
                maquinaEstados.CambiarEstado(jugador.moviendoEnEscalera);
            }
        }
        if (jugador.EstaEnEscalera && movimiento.y > 0)
        {
            maquinaEstados.CambiarEstado(jugador.paradoEnEscalera);
        }
    }
}