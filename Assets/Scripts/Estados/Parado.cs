using UnityEngine;

public class Parado : EnSuelo
{
    public Parado(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {
    }

    public override void Entrar()
    {
        base.Entrar();
        jugador.SetParametroLogico("estaParado", true);
    }

    public override void ActualizarLogica()
    {
        base.ActualizarLogica();
        if (movimiento.x != 0)
        {
            maquinaEstados.CambiarEstado(jugador.coriendo);
        }
    }

    public override void ActualizarFisica()
    {
        base.ActualizarFisica();
        jugador.Mover(new Vector2(0, jugador.VelocidadActual.y));
    }

    public override void Salir()
    {
        base.Salir();
        jugador.SetParametroLogico("estaParado", false);
    }
}
