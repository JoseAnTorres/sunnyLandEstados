using UnityEngine;

public class Corriendo : EnSuelo
{
    public Corriendo(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {
    }

    public override void Entrar()
    {
        base.Entrar();
        jugador.SetParametroLogico("estaCorriendo", true);
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
            maquinaEstados.CambiarEstado(jugador.parado);
        }
    }

    public override void Salir()
    {
        base.Salir();
        jugador.SetParametroLogico("estaCorriendo", false);
    }
}
