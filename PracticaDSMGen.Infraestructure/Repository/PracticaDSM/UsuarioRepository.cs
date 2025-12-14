
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
 * Clase Usuario:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class UsuarioRepository : BasicRepository, IUsuarioRepository
{
public UsuarioRepository() : base ()
{
}


public UsuarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public UsuarioEN ReadOIDDefault (string email
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), email);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }

        return result;
}

        // Modify default (Update all attributes of the class)

        public void ChangePassword(string p_Usuario_OID, string p_newPassHashed)
        {
            try
            {
                SessionInitializeTransaction();

                UsuarioEN usuarioEN = (UsuarioEN)session.Load(typeof(UsuarioEN), p_Usuario_OID);
                usuarioEN.Pass = p_newPassHashed;

                session.Update(usuarioEN);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw;
            }
            finally
            {
                SessionClose();
            }
        }


        public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.Email);


                usuarioNH.Nombre = usuario.Nombre;







                usuarioNH.Direccion = usuario.Direccion;


                usuarioNH.FechaNacimiento = usuario.FechaNacimiento;


                usuarioNH.CodPostal = usuario.CodPostal;


                usuarioNH.Pass = usuario.Pass;

                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (UsuarioEN usuario)
{
        UsuarioNH usuarioNH = new UsuarioNH (usuario);

        try
        {
                SessionInitializeTransaction ();
                if (usuario.Perfil != null) {
                        // p_perfil
                        usuario.Perfil.Usuario = usuario;
                        session.Save (usuarioNH.Perfil);
                }

                session.Save (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioNH.Email;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.Email);

                usuarioNH.Nombre = usuario.Nombre;


                usuarioNH.Direccion = usuario.Direccion;


                usuarioNH.FechaNacimiento = usuario.FechaNacimiento;


                usuarioNH.CodPostal = usuario.CodPostal;

                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
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
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), email);
                session.Delete (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UsuarioEN
public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), email);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> DamePorEstanteria (int ? p_idEstanteria)
{
        System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioNH self where select us FROM UsuarioNH as us inner join us.Estanteria as es where es.Id = :p_idEstanteria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioNHdamePorEstanteriaHQL");
                query.SetParameter ("p_idEstanteria", p_idEstanteria);

                result = query.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> DamePorReseña (int ? p_idReseña)
{
        System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioNH self where select us FROM UsuarioNH as us inner join us.Reseña as res where res.Id = :p_idReseña";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioNHdamePorReseñaHQL");
                query.SetParameter ("p_idReseña", p_idReseña);

                result = query.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
