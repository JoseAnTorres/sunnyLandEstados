using UnityEngine;

public class EnEscalera : Estado
{
    public EnEscalera(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {
    }

    public override void Entrar()
    {
        base.Entrar();
        jugador.ActivarGravedad(false);
    }

    public override void ActualizarLogica()
    {
        base.ActualizarLogica();
        if (!jugador.EstaEnEscalera)
        {
            maquinaEstados.CambiarEstado(jugador.parado);
        }
        if (jugador.EstaEnSuelo && jugador.VelocidadActual.y == 0)
        {
            maquinaEstados.CambiarEstado(jugador.parado);
        }
    }

    public override void Salir()
    {
        base.Salir();
        jugador.ActivarGravedad(true);
    }
}