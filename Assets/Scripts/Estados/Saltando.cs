using UnityEngine;

public class Saltando : Estado
{
    public Saltando(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {
    }

    public override void Entrar()
    {
        base.Entrar();
        jugador.Saltar();
        jugador.SetParametroLogico("estaSaltando", true);
    }

    public override void ActualizarLogica()
    {
        base.ActualizarLogica();
        if (jugador.EstaEnSuelo)
        {
            maquinaEstados.CambiarEstado(jugador.parado);
        }
    }

    public override void ActualizarFisica()
    {
        base.ActualizarFisica();
        jugador.Mover(jugador.VelocidadActual);
    }

    public override void Salir()
    {
        base.Salir();
        jugador.SetParametroLogico("estaSaltando", false);
    }
}
