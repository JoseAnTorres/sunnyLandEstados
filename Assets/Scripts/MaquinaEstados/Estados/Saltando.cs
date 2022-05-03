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
        if (movimiento.x < 0)
        {
            jugador.VoltearFiguraX(true);
        }
        if (movimiento.x > 0)
        {
            jugador.VoltearFiguraX(false);
        }
        if (jugador.EstaEnSuelo)
        {
            maquinaEstados.CambiarEstado(jugador.parado);
        }
    }

    public override void ActualizarFisica()
    {
        base.ActualizarFisica();
        jugador.Mover(new Vector2(movimiento.x * jugador.Velocidad, jugador.VelocidadActual.y));
    }

    public override void Salir()
    {
        base.Salir();
        jugador.SetParametroLogico("estaSaltando", false);
    }
}
