
using System;
using System.Text;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;
using PracticaDSMGen.Infraestructure.EN.PracticaDSM;


/*
 * Clase Perfil:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class PerfilRepository : BasicRepository, IPerfilRepository
{
public PerfilRepository() : base ()
{
}


public PerfilRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PerfilEN ReadOIDDefault (int id
                                )
{
        PerfilEN perfilEN = null;

        try
        {
                SessionInitializeTransaction ();
                perfilEN = (PerfilEN)session.Get (typeof(PerfilNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return perfilEN;
}

public System.Collections.Generic.IList<PerfilEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PerfilEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PerfilNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PerfilEN>();
                        else
                                result = session.CreateCriteria (typeof(PerfilNH)).List<PerfilEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.Id);


                perfilNH.Tema = perfil.Tema;

                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PerfilEN perfil)
{
        PerfilNH perfilNH = new PerfilNH (perfil);

        try
        {
                SessionInitializeTransaction ();
                if (perfil.Usuario != null) {
                        // Argumento OID y no colección.
                        perfilNH
                        .Usuario = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN), perfil.Usuario.Email);

                        perfilNH.Usuario.Perfil
                                = perfilNH;
                }

                session.Save (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return perfilNH.Id;
}

public void Modify (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.Id);

                perfilNH.Tema = perfil.Tema;

                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), id);
                session.Delete (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PerfilEN
public PerfilEN ReadOID (int id
                         )
{
        PerfilEN perfilEN = null;

        try
        {
                SessionInitializeTransaction ();
                perfilEN = (PerfilEN)session.Get (typeof(PerfilNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return perfilEN;
}

public System.Collections.Generic.IList<PerfilEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PerfilEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PerfilNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PerfilEN>();
                else
                        result = session.CreateCriteria (typeof(PerfilNH)).List<PerfilEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
