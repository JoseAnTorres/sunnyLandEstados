using UnityEngine;

public class ParadoEnEscalera : EnEscalera
{
    public ParadoEnEscalera(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {
    }

    public override void Entrar()
    {
        base.Entrar();
        jugador.SetParametroLogico("estaParadoEnEscalera", true);
    }

    public override void ActualizarLogica()
    {
        base.ActualizarLogica();
        if (movimiento.y != 0)
        {
            maquinaEstados.CambiarEstado(jugador.moviendoEnEscalera);
        }
    }

    public override void Salir()
    {
        base.Salir();
        jugador.SetParametroLogico("estaParadoEnEscalera", false);
    }
}