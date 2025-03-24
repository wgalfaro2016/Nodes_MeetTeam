using MeetTeamTest.Nodes;

namespace MeetTeamTest
{
    public class Simulador
    {
        public static void Main() {
            // Crear nodos con sus respectivos identificadores
            var nodo1 = new Nodo(1);
            var nodo2 = new Nodo(2);
            var nodo3 = new Nodo(3);

            // Establecer conexiones (vecinos) entre los nodos
            nodo1.AgregarVecino(nodo2);
            nodo1.AgregarVecino(nodo3);

            nodo2.AgregarVecino(nodo1);
            nodo2.AgregarVecino(nodo3);

            nodo3.AgregarVecino(nodo1);
            nodo3.AgregarVecino(nodo2);

            // Proponer estados desde diferentes nodos
            nodo1.ProponerEstado(1);
            nodo2.ProponerEstado(2);

            // Simular una partición de red entre nodo3 y nodo1
            nodo3.SimularParticion(new List<Nodo> { nodo1 });

            // Propuesta adicional desde nodo2
            nodo2.ProponerEstado(3);

            // Mostrar los registros de cada nodo
            ImprimirRegistro(nodo1);
            ImprimirRegistro(nodo2);
            ImprimirRegistro(nodo3);
        }

        private static void ImprimirRegistro(Nodo nodo) {
            Console.WriteLine(nodo.ObtenerRegistro());
            Console.WriteLine(new string('-', 50));
        }
    }
}
