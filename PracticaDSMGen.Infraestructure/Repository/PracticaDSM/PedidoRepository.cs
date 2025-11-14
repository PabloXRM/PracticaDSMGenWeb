
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
 * Clase Pedido:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class PedidoRepository : BasicRepository, IPedidoRepository
{
public PedidoRepository() : base ()
{
}


public PedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PedidoEN ReadOIDDefault (int id
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.Id);





                pedidoNH.Carrito = pedido.Carrito;


                pedidoNH.Numero = pedido.Numero;


                pedidoNH.Fecha = pedido.Fecha;


                pedidoNH.TotalPrecio = pedido.TotalPrecio;


                pedidoNH.EstadoPedido = pedido.EstadoPedido;

                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PedidoEN pedido)
{
        PedidoNH pedidoNH = new PedidoNH (pedido);

        try
        {
                SessionInitializeTransaction ();
                if (pedido.Usuario != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Usuario = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN), pedido.Usuario.Email);

                        pedidoNH.Usuario.Pedido
                        .Add (pedidoNH);
                }
                if (pedido.MetodoPago != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .MetodoPago = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN), pedido.MetodoPago.Id);

                        pedidoNH.MetodoPago.Pedido
                        .Add (pedidoNH);
                }

                session.Save (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoNH.Id;
}

public void Modify (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.Id);

                pedidoNH.Carrito = pedido.Carrito;


                pedidoNH.Numero = pedido.Numero;


                pedidoNH.Fecha = pedido.Fecha;


                pedidoNH.TotalPrecio = pedido.TotalPrecio;


                pedidoNH.EstadoPedido = pedido.EstadoPedido;

                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
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
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), id);
                session.Delete (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PedidoEN
public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> DamePedidosPorProducto (int ? p_idProducto)
{
        System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoNH self where select ped FROM PedidoNH as ped inner join ped.LineaPedido as linea where linea.Producto.id = :p_idProducto";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoNHdamePedidosPorProductoHQL");
                query.SetParameter ("p_idProducto", p_idProducto);

                result = query.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
