using UnityEngine;

public abstract class Estado
{
    protected Jugador jugador;
    protected MaquinaEstados maquinaEstados;
    protected Vector2 movimiento;
    protected bool salto;

    protected Estado(Jugador jugador, MaquinaEstados maquinaEstados)
    {
        this.jugador = jugador;
        this.maquinaEstados = maquinaEstados;
    }

    public virtual void Entrar()
    {
        Debug.Log($"Entro en estado: {this}");
    }

    public virtual void GestionarEntrada(Vector2 movimiento, bool salto)
    {
        this.movimiento = movimiento;
        this.salto = salto;
    }

    public virtual void ActualizarLogica()
    {

    }

    public virtual void ActualizarFisica()
    {

    }

    public virtual void Salir()
    {

    }
}