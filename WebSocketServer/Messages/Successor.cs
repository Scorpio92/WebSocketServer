﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Successor.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the Successor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebSocketServer.Messages
{
    using System.Collections.Generic;
    using Handlers;
    using IWebSocketConnection = Fleck2.Interfaces.IWebSocketConnection;

    /// <summary>
    /// The handlers facade.
    /// </summary>
    public static class Successor
    {
        /// <summary>
        /// Initializes static members of the <see cref="Successor"/> class.
        /// </summary>
        static Successor()
        {
            Handlers = new List<BaseHandler>()
                           {
                               // Сортировать желательно по частоте применимости
                               new DialogHandler(),
                               new ChatHandler(),
                               new AuthHandler(),
                           };

            InvalidHandler = new InvalidHandler();
        }

        /// <summary>
        /// Gets the invalid handler.
        /// </summary>
        public static InvalidHandler InvalidHandler { get; }

        /// <summary>
        /// Gets the handlers.
        /// </summary>
        private static List<BaseHandler> Handlers { get; }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="socket">
        /// The socket.
        /// </param>
        /// <param name="webSocketMessage">
        /// The message type.
        /// </param>
        /// <param name="server">
        /// The server.
        /// </param>
        public static void Handle(IWebSocketConnection socket, string webSocketMessage, IServer server)
        {
            var messageType = Newtonsoft.Json.JsonConvert
                .DeserializeObject<WebSocketMessage<Payloads.BaseMessage>>(webSocketMessage).Type;

            foreach (var handler in Handlers)
            {
                if (handler.CanHandle(socket, messageType, server))
                {
                    handler.Handle(socket, webSocketMessage, server);
                    return;
                }
            }
            
            InvalidHandler.Handle(socket, webSocketMessage, server);
        }
    }
}
