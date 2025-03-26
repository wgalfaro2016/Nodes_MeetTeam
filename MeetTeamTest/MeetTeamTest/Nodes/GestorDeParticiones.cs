public class GestorDeParticiones
{
    private readonly HashSet<int> _nodosParticionados = new();
    private readonly int _id;
    private readonly RegistroDeNodo _registro;

    public GestorDeParticiones(int id, RegistroDeNodo registro) {
        _id = id;
        _registro = registro;
    }

    public void Simular(List<Nodo> nodos) {
        foreach (var nodo in nodos)
            _nodosParticionados.Add(nodo.Id);

        _registro.Agregar($"ahora está particionado de: {string.Join(", ", nodos.Select(n => n.Id))}");
    }

    public bool EstaParticionado(int idNodo) => _nodosParticionados.Contains(idNodo);
}
