public class MaquinaEstados
{
    public Estado EstadoActual { get; private set;}

    public void Inicializar(Estado estadoIncial)
    {
        EstadoActual = estadoIncial;
        EstadoActual.Entrar();
    }

    public void CambiarEstado(Estado nuevo)
    {
        EstadoActual.Salir();
        EstadoActual = nuevo;
        EstadoActual.Entrar();
    }
}
