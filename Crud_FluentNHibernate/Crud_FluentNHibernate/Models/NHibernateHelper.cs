using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Crud_FluentNHibernate.Models
{
    public class NHibernateHelper
    {
        public static ISession OpeSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        @"Server=138.97.105.157;Database=TestTemp;User Id=sa;Password=LO4602$#ze;").ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Aluno>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}