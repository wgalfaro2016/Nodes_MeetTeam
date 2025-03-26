namespace MeetTeamTest.Nodes
{
    public class GestorDeNodosVecinos
    {
        private readonly List<Nodo> _nodoVecinos = new();

        public void Agregar(Nodo nodo) => _nodoVecinos.Add(nodo);

        public IEnumerable<Nodo> ObtenerVecinosActivos(GestorDeParticiones particiones) =>
            _nodoVecinos.Where(v => !particiones.EstaParticionado(v.Id));

        public List<Nodo> ObtenerTodosLosNodos() => _nodoVecinos;
    }
}
