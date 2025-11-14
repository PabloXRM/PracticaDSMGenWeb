
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
 * Clase Factura:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class FacturaRepository : BasicRepository, IFacturaRepository
{
public FacturaRepository() : base ()
{
}


public FacturaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FacturaEN ReadOIDDefault (int id
                                 )
{
        FacturaEN facturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                facturaEN = (FacturaEN)session.Get (typeof(FacturaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FacturaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FacturaEN>();
                        else
                                result = session.CreateCriteria (typeof(FacturaNH)).List<FacturaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                FacturaNH facturaNH = (FacturaNH)session.Load (typeof(FacturaNH), factura.Id);


                facturaNH.Numero = factura.Numero;


                facturaNH.ImporteTotal = factura.ImporteTotal;


                facturaNH.Fecha = factura.Fecha;

                session.Update (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (FacturaEN factura)
{
        FacturaNH facturaNH = new FacturaNH (factura);

        try
        {
                SessionInitializeTransaction ();
                if (factura.Pedido != null) {
                        // Argumento OID y no colección.
                        facturaNH
                        .Pedido = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN), factura.Pedido.Id);

                        facturaNH.Pedido.Factura
                                = facturaNH;
                }

                session.Save (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return facturaNH.Id;
}

public void Modify (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                FacturaNH facturaNH = (FacturaNH)session.Load (typeof(FacturaNH), factura.Id);

                facturaNH.Numero = factura.Numero;


                facturaNH.ImporteTotal = factura.ImporteTotal;


                facturaNH.Fecha = factura.Fecha;

                session.Update (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
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
                FacturaNH facturaNH = (FacturaNH)session.Load (typeof(FacturaNH), id);
                session.Delete (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: FacturaEN
public FacturaEN ReadOID (int id
                          )
{
        FacturaEN facturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                facturaEN = (FacturaEN)session.Get (typeof(FacturaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FacturaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FacturaEN>();
                else
                        result = session.CreateCriteria (typeof(FacturaNH)).List<FacturaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
