﻿using Mails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.Data
{
    public class MailsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mail> Mails { get; set; }

        //public MailsContext(DbContextOptions<MailContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conectionString = "Persist Security Info=True;data source=DESKTOP-3AKF5J3\\MSSQLFREDD;initial catalog=db_WebEmail; Integrated Security=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(conectionString);
        }

    }
}
