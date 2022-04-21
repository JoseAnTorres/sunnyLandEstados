using UnityEngine;

public class MoviendoEnEscalera : EnEscalera
{
    public MoviendoEnEscalera(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {
    }

    public override void Entrar()
    {
        base.Entrar();
        jugador.SetParametroLogico("estaMoviendoEnEscalera", true);
    }

    public override void ActualizarLogica()
    {
        base.ActualizarLogica();
        if (movimiento.y == 0)
        {
            maquinaEstados.CambiarEstado(jugador.paradoEnEscalera);
        }
    }

    public override void ActualizarFisica()
    {
        base.ActualizarFisica();
        jugador.Mover(new Vector2(0, movimiento.y * jugador.Velocidad));
    }

    public override void Salir()
    {
        base.Salir();
        jugador.SetParametroLogico("estaMoviendoEnEscalera", false);
    }
}
