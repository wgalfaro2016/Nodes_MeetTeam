public class RegistroDeNodo
{
    private readonly List<string> _eventos = new();
    private readonly int _id;

    public RegistroDeNodo(int id) => _id = id;

    public void Agregar(string mensaje) {
        var entrada = $"Nodo {_id}: {mensaje}";
        _eventos.Add(entrada);
    }

    public string Obtener() {
        if (!_eventos.Any())
            return $"Nodo {_id} aún no tiene eventos registrados.";

        return $"Bitácora del Nodo {_id}:\n" +
               string.Join("\n", _eventos) +
               $"\nFin de la bitácora del Nodo {_id}.";
    }
}
