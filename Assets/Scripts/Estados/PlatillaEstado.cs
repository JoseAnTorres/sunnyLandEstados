using UnityEngine;

public class PlantillaEstado : Estado
{
    public PlantillaEstado(Jugador jugador, MaquinaEstados maquinaEstados) : base(jugador, maquinaEstados)
    {

    }

    public override void Entrar()
    {
        base.Entrar();
    }

    public override void GestionarEntrada(Vector2 movimiento, bool salto)
    {
        base.GestionarEntrada(movimiento, salto);
    }

    public override void ActualizarLogica()
    {
        base.ActualizarLogica();
    }

    public override void ActualizarFisica()
    {
        base.ActualizarFisica();
    }

    public override void Salir()
    {
        base.Salir();
    }
}