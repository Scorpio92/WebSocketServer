﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DialogMessage.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the DialogMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebSocketServer.Messages.Payloads.Server
{
    /// <inheritdoc />
    public class DialogMessage : BaseMessage
    {
        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Gets or sets the receiver.
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public long Time { get; set; } = (long)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1)).TotalSeconds;

        /// <inheritdoc />
        protected override string MessageType => Types.DialogMessage;
    }
}
