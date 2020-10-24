using Microsoft.AspNet.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Ejemplo01_ContadorVisitas.Middleware
{
    public class Conexion : PersistentConnection
    {
        private static int _connections = 0;

        /// <summary>
        /// Se ejecuta cuando un cliente se conecta al aplicativo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        protected override async Task OnConnected(IRequest request, string connectionId)
        {
            //cada que un cliente se conecta _connections incrementa en 1
            Interlocked.Increment(ref _connections);

            //cuando un cliente se conecta se le envia un mensaje de bienvenida
            await Connection.Send(connectionId, "Bienvenido!" + connectionId);

            //se notifica a todos los usuarios actuales sobre la conexión del nuevo usuario
            await Connection.Broadcast($"Nueva conexión {connectionId}, Visitantes actuales: {_connections}");
        }

        /// <summary>
        /// Este metodo se dispara cada que un cliente envia información al servidor
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            string message = $"{connectionId.ToString().Substring(0, 5)}: {data}";

            //este metodo envia el mensaje a todos los clientes que se encuentren conectados
            return Connection.Broadcast(message);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            //el contador se recude en 1
            Interlocked.Decrement(ref _connections);

            //se notifica a los usuarios sobre la desconexión y el total de visitas actuales
            return Connection.Broadcast($"{connectionId}: conexión cerrada, Visitantes actuales: {_connections}");
        }
    }
}