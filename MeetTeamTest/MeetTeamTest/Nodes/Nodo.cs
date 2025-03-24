namespace MeetTeamTest.Nodes
{
    /// <summary>
    /// Representa un nodo dentro del sistema distribuido.
    /// Cada nodo puede proponer un estado, recibir propuestas,
    /// simular fallas y particiones de red, y alcanzar consenso.
    /// </summary>
    public class Nodo
    {
        public int Id { get; }
        public int? EstadoActual { get; private set; }
        public bool EstaActivo { get; private set; } = true;

        public List<Nodo> Vecinos { get; } = new();
        public List<string> Registro { get; } = new();

        private readonly HashSet<int> NodosParticionados = new();
        private readonly GestorDePropuestas _gestorDePropuestas;

        public Nodo(int id) {
            Id = id;
            _gestorDePropuestas = new GestorDePropuestas(this);
        }

        /// <summary>
        /// Conecta este nodo con otro nodo vecino.
        /// </summary>
        public void AgregarVecino(Nodo nodo) {
            Vecinos.Add(nodo);
        }

        /// <summary>
        /// Propuesta inicial de un nuevo estado por parte de este nodo.
        /// </summary>
        public void ProponerEstado(int estado) {
            if (!EstaActivo) return;

            Registro.Add($"Nodo {Id} propone el estado {estado}.");
            _gestorDePropuestas.IniciarPropuesta(estado);

            foreach (var vecino in Vecinos) {
                if (!EstaParticionado(vecino.Id)) {
                    vecino.RecibirPropuesta(estado, Id);
                }
            }

            _gestorDePropuestas.EvaluarConsenso();
        }

        /// <summary>
        /// Recibe una propuesta de estado desde otro nodo.
        /// </summary>
        public void RecibirPropuesta(int estado, int idNodoRemitente) {
            if (!EstaActivo || EstaParticionado(idNodoRemitente)) return;

            Registro.Add($"Nodo {Id} recibió propuesta {estado} del Nodo {idNodoRemitente}.");
            _gestorDePropuestas.RecibirPropuesta(estado, idNodoRemitente);
            _gestorDePropuestas.EvaluarConsenso();
        }

        /// <summary>
        /// Simula una partición de red que aísla a este nodo de otros.
        /// </summary>
        public void SimularParticion(List<Nodo> nodos) {
            foreach (var nodo in nodos)
                NodosParticionados.Add(nodo.Id);

            Registro.Add($"Nodo {Id} ahora está particionado de: {string.Join(", ", nodos.Select(n => n.Id))}");
        }

        /// <summary>
        /// Simula una falla en este nodo.
        /// </summary>
        public void SimularFalla() {
            EstaActivo = false;
            Registro.Add($"Nodo {Id} ha fallado.");
        }

        /// <summary>
        /// Recupera al nodo luego de una falla simulada.
        /// </summary>
        public void RecuperarDeFalla() {
            EstaActivo = true;
            Registro.Add($"Nodo {Id} se ha recuperado.");
        }

        /// <summary>
        /// Verifica si este nodo está particionado de otro nodo por su ID.
        /// </summary>
        public bool EstaParticionado(int idNodo) {
            return NodosParticionados.Contains(idNodo);
        }

        /// <summary>
        /// Establece el estado consensuado una vez que se alcanza mayoría.
        /// </summary>
        public void EstablecerEstadoConsensuado(int estado) {
            if (EstadoActual != estado) {
                EstadoActual = estado;
                Registro.Add($"Nodo {Id} alcanzó consenso en el estado {EstadoActual}.");
            }
        }

        /// <summary>
        /// Devuelve el log completo de acciones y eventos de este nodo.
        /// </summary>
        public string ObtenerRegistro() {
            return $"Registro del Nodo {Id}:\n" + string.Join("\n", Registro);
        }
    }
}
