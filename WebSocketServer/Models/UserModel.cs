﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserModel.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   The user model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebSocketServer.Models
{
    /// <summary>
    /// The user model.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }
    }
}