using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Music.Maps;


namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<SongInfo> songProperties =  FileReader.GetProperties("music.txt");


            FluentConfiguration config = Fluently
                 .Configure()
                 .Database(MsSqlConfiguration
                               .MsSql2008
                               .ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=Songs;Integrated Security=True;Pooling=False"))
                               .Mappings(configuration => configuration
                               .FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                              ;

            var export = new SchemaUpdate(config.BuildConfiguration());
            export.Execute(true, true);

            ISessionFactory sessionFactory = config.BuildSessionFactory();


            using (ISession session = sessionFactory.OpenSession())
            {
                var tracks = session.QueryOver<ArtistInfo>().List();

                foreach (var track in tracks)
                {
                    Console.WriteLine(track);
                    Console.WriteLine("=====");

                }

                
            }

        }
    }
}
