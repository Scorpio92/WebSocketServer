﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppContext.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the AppContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebSocketServer.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public sealed class AppContext : DbContext
    {
        /// <summary>
        /// The sync root.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The instance.
        /// </summary>
        private static volatile AppContext instance;

        /// <inheritdoc />
        private AppContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static AppContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AppContext();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// Gets or sets the users tokens.
        /// </summary>
        public DbSet<UserTokenModel> UsersTokens { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.Get("ConnectionString"));
        }
    }
}