using MeetTeamTest.Nodes;

public class Nodo
{
    public int Id { get; }
    public int? EstadoActual { get; private set; }
    public bool EstaActivo { get; private set; } = true;

    public RegistroDeNodo Registro { get; }
    public GestorDeNodosVecinos Vecinos { get; }
    public GestorDeParticiones Particiones { get; }

    private readonly GestorDePropuestas _gestor;

    public Nodo(int id) {
        Id = id;
        Registro = new RegistroDeNodo(id);
        Vecinos = new GestorDeNodosVecinos();
        Particiones = new GestorDeParticiones(id, Registro);
        _gestor = new GestorDePropuestas(this);
    }

    /// <summary>
    /// Envia la sugerencia o la propuesta a los otros nodos en nuestro sistema para que la acepten
    /// </summary>
    /// <param name="estado"></param>
    public void ProponerEstado(int estado) {
        if (!EstaActivo) return;

        Registro.Agregar($"Estado actual: {estado}.");
        _gestor.IniciarPropuesta(estado);

        foreach (var vecino in Vecinos.ObtenerVecinosActivos(Particiones))
            vecino.RecibirPropuesta(estado, Id);

        _gestor.EvaluarConsenso();
    }

    /// <summary>
    /// Recibe la propuesta de otro nodo para que su estado cambie
    /// </summary>
    /// <param name="estado"></param>
    /// <param name="idRemitente"></param>
    public void RecibirPropuesta(int estado, int idRemitente) {
        if (!EstaActivo || Particiones.EstaParticionado(idRemitente))
            return;

        Registro.Agregar($"recibió propuesta {estado} del Nodo {idRemitente}.");
        _gestor.RecibirPropuesta(estado, idRemitente);
        _gestor.EvaluarConsenso();
    }

    public void SimularFalla() {
        EstaActivo = false;
        Registro.Agregar("ha fallado. Por favor revisar.");
    }

    public void RecuperarDeFalla() {
        EstaActivo = true;
        Registro.Agregar("se ha restablecido su funcionamiento.!!!");
    }

    public void EstablecerEstadoConsensuado(int estado) {
        if (EstadoActual == estado) return;

        EstadoActual = estado;
        Registro.Agregar($"alcanzó el consenso establecido con el estado: {estado}.");
    }

    public string ObtenerRegistro() => Registro.Obtener();
}
