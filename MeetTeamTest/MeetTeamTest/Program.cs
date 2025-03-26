namespace MeetTeamTest
{
    public class Simulador
    {
        public static void Main() {
            var nodos = new[] { new Nodo(1), new Nodo(2), new Nodo(3) };

            ConectarNodos(nodos);

            nodos[0].ProponerEstado(1);
            nodos[1].ProponerEstado(2);

            nodos[2].Particiones.Simular(new List<Nodo> { nodos[0] });

            nodos[1].ProponerEstado(3);

            foreach (var nodo in nodos)
                ImprimirRegistro(nodo);
        }

        private static void ConectarNodos(Nodo[] nodos) {
            foreach (var nodo in nodos) {
                foreach (var vecino in nodos.Where(n => n.Id != nodo.Id))
                    nodo.Vecinos.Agregar(vecino);
            }
        }

        private static void ImprimirRegistro(Nodo nodo) {
            Console.WriteLine(nodo.ObtenerRegistro());
            Console.WriteLine(new string('-', 50));
        }
    }
}
