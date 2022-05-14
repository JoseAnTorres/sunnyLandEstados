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
        Audio.Instancia.PlaySalto();
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
        if (movimiento.x != 0)
        {
            jugador.Mover(new Vector2(movimiento.x * jugador.Velocidad, jugador.VelocidadActual.y));
        }
        else
        {
            jugador.Mover(jugador.VelocidadActual);
        }
    }

    public override void Salir()
    {
        base.Salir();
        jugador.SetParametroLogico("estaSaltando", false);
    }
}
