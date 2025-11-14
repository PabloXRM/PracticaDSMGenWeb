using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

using PracticaDSMGen.Infraestructure.EN.PracticaDSM;


namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public static class NHibernateHelper
{
private static ISessionFactory _sessionFactory;

private static ISessionFactory SessionFactory
{
        get
        {
                if (_sessionFactory == null) {
                        var configuration = new Configuration ();
                        configuration.Configure ();
                        configuration.AddAssembly (typeof(UsuarioNH).Assembly);
                        _sessionFactory = configuration.BuildSessionFactory ();
                }

                return _sessionFactory;
        }
}

public static ISession OpenSession ()
{
        return SessionFactory.OpenSession ();
}
}
}
