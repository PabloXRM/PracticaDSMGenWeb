
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
 * Clase Estanteria:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class EstanteriaRepository : BasicRepository, IEstanteriaRepository
{
public EstanteriaRepository() : base ()
{
}


public EstanteriaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public EstanteriaEN ReadOIDDefault (int id
                                    )
{
        EstanteriaEN estanteriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                estanteriaEN = (EstanteriaEN)session.Get (typeof(EstanteriaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return estanteriaEN;
}

public System.Collections.Generic.IList<EstanteriaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EstanteriaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EstanteriaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<EstanteriaEN>();
                        else
                                result = session.CreateCriteria (typeof(EstanteriaNH)).List<EstanteriaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in EstanteriaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EstanteriaEN estanteria)
{
        try
        {
                SessionInitializeTransaction ();
                EstanteriaNH estanteriaNH = (EstanteriaNH)session.Load (typeof(EstanteriaNH), estanteria.Id);



                estanteriaNH.Descripcion = estanteria.Descripcion;


                estanteriaNH.Valoracion = estanteria.Valoracion;


                estanteriaNH.Visitas = estanteria.Visitas;


                estanteriaNH.Visible = estanteria.Visible;

                session.Update (estanteriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in EstanteriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (EstanteriaEN estanteria)
{
        EstanteriaNH estanteriaNH = new EstanteriaNH (estanteria);

        try
        {
                SessionInitializeTransaction ();
                if (estanteria.Usuario != null) {
                        // Argumento OID y no colección.
                        estanteriaNH
                        .Usuario = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN), estanteria.Usuario.Email);

                        estanteriaNH.Usuario.Estanteria
                        .Add (estanteriaNH);
                }
                if (estanteria.Producto != null) {
                        for (int i = 0; i < estanteria.Producto.Count; i++) {
                                estanteria.Producto [i] = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN), estanteria.Producto [i].Id);
                                estanteria.Producto [i].Estanteria.Add (estanteriaNH);
                        }
                }

                session.Save (estanteriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in EstanteriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return estanteriaNH.Id;
}

public void Modify (EstanteriaEN estanteria)
{
        try
        {
                SessionInitializeTransaction ();
                EstanteriaNH estanteriaNH = (EstanteriaNH)session.Load (typeof(EstanteriaNH), estanteria.Id);

                estanteriaNH.Descripcion = estanteria.Descripcion;


                estanteriaNH.Valoracion = estanteria.Valoracion;


                estanteriaNH.Visitas = estanteria.Visitas;

                session.Update (estanteriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in EstanteriaRepository.", ex);
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
                EstanteriaNH estanteriaNH = (EstanteriaNH)session.Load (typeof(EstanteriaNH), id);
                session.Delete (estanteriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in EstanteriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: EstanteriaEN
public EstanteriaEN ReadOID (int id
                             )
{
        EstanteriaEN estanteriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                estanteriaEN = (EstanteriaEN)session.Get (typeof(EstanteriaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return estanteriaEN;
}

public System.Collections.Generic.IList<EstanteriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EstanteriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EstanteriaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<EstanteriaEN>();
                else
                        result = session.CreateCriteria (typeof(EstanteriaNH)).List<EstanteriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in EstanteriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> DameEstanteriaPorProducto (int ? p_idProducto)
{
        System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EstanteriaNH self where select es FROM EstanteriaNH as es join es.Producto as pro where pro.id = :p_idProducto";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EstanteriaNHdameEstanteriaPorProductoHQL");
                query.SetParameter ("p_idProducto", p_idProducto);

                result = query.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in EstanteriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
