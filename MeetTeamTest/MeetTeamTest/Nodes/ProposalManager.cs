namespace MeetTeamTest.Nodes
{
    public class GestorDePropuestas
    {
        private readonly Nodo _nodoActual;
        private readonly Dictionary<int, int> _propuestasRecibidas = new();

        public GestorDePropuestas(Nodo nodo) {
            _nodoActual = nodo;
        }

        public void IniciarPropuesta(int estado) {
            _propuestasRecibidas.Clear();
            _propuestasRecibidas[_nodoActual.Id] = estado;
        }

        public void RecibirPropuesta(int estado, int idRemitente) =>
            _propuestasRecibidas[idRemitente] = estado;

        public void EvaluarConsenso() {
            int quorum = ObtenerQuorum();

            if (_propuestasRecibidas.Count >= quorum)
                _nodoActual.EstablecerEstadoConsensuado(_propuestasRecibidas.Values.Max());
        }

        private int ObtenerQuorum() {
            int totalNodos = _nodoActual.Vecinos.ObtenerTodosLosNodos().Count + 1;
            return (totalNodos / 2) + 1;
        }
    }
}
