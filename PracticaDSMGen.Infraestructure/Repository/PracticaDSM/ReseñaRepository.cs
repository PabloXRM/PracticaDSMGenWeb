
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
 * Clase Reseña:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class ReseñaRepository : BasicRepository, IReseñaRepository
{
public ReseñaRepository() : base ()
{
}


public ReseñaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ReseñaEN ReadOIDDefault (int id
                                )
{
        ReseñaEN reseñaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reseñaEN = (ReseñaEN)session.Get (typeof(ReseñaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reseñaEN;
}

public System.Collections.Generic.IList<ReseñaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReseñaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReseñaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReseñaEN>();
                        else
                                result = session.CreateCriteria (typeof(ReseñaNH)).List<ReseñaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReseñaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReseñaEN reseña)
{
        try
        {
                SessionInitializeTransaction ();
                ReseñaNH reseñaNH = (ReseñaNH)session.Load (typeof(ReseñaNH), reseña.Id);



                reseñaNH.Descripcion = reseña.Descripcion;


                reseñaNH.Nota = reseña.Nota;


                reseñaNH.Fecha = reseña.Fecha;

                session.Update (reseñaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReseñaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ReseñaEN reseña)
{
        ReseñaNH reseñaNH = new ReseñaNH (reseña);

        try
        {
                SessionInitializeTransaction ();
                if (reseña.Usuario != null) {
                        // Argumento OID y no colección.
                        reseñaNH
                        .Usuario = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN), reseña.Usuario.Email);

                        reseñaNH.Usuario.Reseña
                        .Add (reseñaNH);
                }
                if (reseña.Producto != null) {
                        // Argumento OID y no colección.
                        reseñaNH
                        .Producto = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN), reseña.Producto.Id);

                        reseñaNH.Producto.Reseña
                        .Add (reseñaNH);
                }

                session.Save (reseñaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReseñaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reseñaNH.Id;
}

public void Modify (ReseñaEN reseña)
{
        try
        {
                SessionInitializeTransaction ();
                ReseñaNH reseñaNH = (ReseñaNH)session.Load (typeof(ReseñaNH), reseña.Id);

                reseñaNH.Descripcion = reseña.Descripcion;


                reseñaNH.Nota = reseña.Nota;


                reseñaNH.Fecha = reseña.Fecha;

                session.Update (reseñaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReseñaRepository.", ex);
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
                ReseñaNH reseñaNH = (ReseñaNH)session.Load (typeof(ReseñaNH), id);
                session.Delete (reseñaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReseñaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ReseñaEN
public ReseñaEN ReadOID (int id
                         )
{
        ReseñaEN reseñaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reseñaEN = (ReseñaEN)session.Get (typeof(ReseñaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reseñaEN;
}

public System.Collections.Generic.IList<ReseñaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ReseñaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReseñaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReseñaEN>();
                else
                        result = session.CreateCriteria (typeof(ReseñaNH)).List<ReseñaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReseñaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> DameReseñaPorProducto (int ? p_idProducto)
{
        System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReseñaNH self where select res FROM ReseñaNH as res join res.Producto as pro where pro.id = :p_idProducto";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReseñaNHdameReseñaPorProductoHQL");
                query.SetParameter ("p_idProducto", p_idProducto);

                result = query.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReseñaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
