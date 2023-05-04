﻿using System.Collections.Generic;
using System.Data.Entity;

namespace GameShop.Data.Sql
{
    internal class GameShopContext : DbContext
    {
        internal GameShopContext() : base("GameShop") { }

        public DbSet<GameEntity> Games { get; set; }
        public DbSet<CheckEntity> Checks { get; set; }

        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}