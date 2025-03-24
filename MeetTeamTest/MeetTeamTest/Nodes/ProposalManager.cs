namespace MeetTeamTest.Nodes
{
    // Clase encargada de manejar propuestas de estado entre nodos
    public class GestorDePropuestas
    {
        private readonly Nodo _nodoActual;
        private readonly Dictionary<int, int> _propuestasRecibidas = new();

        public GestorDePropuestas(Nodo nodo) {
            _nodoActual = nodo;
        }

        // Inicia una nueva ronda de propuesta de estado
        public void IniciarPropuesta(int estado) {
            _propuestasRecibidas.Clear();
            _propuestasRecibidas[_nodoActual.Id] = estado;
        }

        // Almacena la propuesta recibida desde otro nodo
        public void RecibirPropuesta(int estado, int idRemitente) {
            _propuestasRecibidas[idRemitente] = estado;
        }

        // Verifica si se alcanzó un consenso (mayoría) y aplica el estado con mayor valor
        public void EvaluarConsenso() {
            // Se necesita mayoría (mitad + 1)
            int quorum = (_nodoActual.Vecinos.Count + 1) / 2 + 1;
            if (_propuestasRecibidas.Count < quorum) return;

            int estadoConsensuado = _propuestasRecibidas.Values.Max();
            _nodoActual.EstablecerEstadoConsensuado(estadoConsensuado);
        }
    }
}
