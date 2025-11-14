
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
 * Clase LineaPedido:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class LineaPedidoRepository : BasicRepository, ILineaPedidoRepository
{
public LineaPedidoRepository() : base ()
{
}


public LineaPedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LineaPedidoEN ReadOIDDefault (int num
                                     )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoNH), num);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).List<LineaPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Num);


                lineaPedidoNH.Cantidad = lineaPedido.Cantidad;



                lineaPedidoNH.Precio = lineaPedido.Precio;

                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (LineaPedidoEN lineaPedido)
{
        LineaPedidoNH lineaPedidoNH = new LineaPedidoNH (lineaPedido);

        try
        {
                SessionInitializeTransaction ();
                if (lineaPedido.Pedido != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Pedido = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN), lineaPedido.Pedido.Id);

                        lineaPedidoNH.Pedido.LineaPedido
                        .Add (lineaPedidoNH);
                }
                if (lineaPedido.Producto != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Producto = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN), lineaPedido.Producto.Id);

                        lineaPedidoNH.Producto.LineaPedido
                        .Add (lineaPedidoNH);
                }

                session.Save (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoNH.Num;
}

public void Modify (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Num);

                lineaPedidoNH.Cantidad = lineaPedido.Cantidad;


                lineaPedidoNH.Precio = lineaPedido.Precio;

                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int num
                     )
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), num);
                session.Delete (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: LineaPedidoEN
public LineaPedidoEN ReadOID (int num
                              )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoNH), num);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaPedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                else
                        result = session.CreateCriteria (typeof(LineaPedidoNH)).List<LineaPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
