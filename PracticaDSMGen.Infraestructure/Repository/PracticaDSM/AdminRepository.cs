
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
 * Clase Admin:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class AdminRepository : BasicRepository, IAdminRepository
{
public AdminRepository() : base ()
{
}


public AdminRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AdminEN ReadOIDDefault (string email
                               )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminNH), email);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdminNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                        else
                                result = session.CreateCriteria (typeof(AdminNH)).List<AdminEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminNH adminNH = (AdminNH)session.Load (typeof(AdminNH), admin.Email);

                adminNH.IdAdmin = admin.IdAdmin;

                session.Update (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (AdminEN admin)
{
        AdminNH adminNH = new AdminNH (admin);

        try
        {
                SessionInitializeTransaction ();
                if (admin.Perfil != null) {
                        // p_perfil
                        admin.Perfil.Usuario = admin;
                        session.Save (adminNH.Perfil);
                }

                session.Save (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminNH.Email;
}

public void Modify (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminNH adminNH = (AdminNH)session.Load (typeof(AdminNH), admin.Email);

                adminNH.Nombre = admin.Nombre;


                adminNH.Direccion = admin.Direccion;


                adminNH.FechaNacimiento = admin.FechaNacimiento;


                adminNH.CodPostal = admin.CodPostal;


                adminNH.IdAdmin = admin.IdAdmin;

                session.Update (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AdminNH adminNH = (AdminNH)session.Load (typeof(AdminNH), email);
                session.Delete (adminNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AdminEN
public AdminEN ReadOID (string email
                        )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminNH), email);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdminNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                else
                        result = session.CreateCriteria (typeof(AdminNH)).List<AdminEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdminRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
