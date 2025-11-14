
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
 * Clase MetodoPago:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class MetodoPagoRepository : BasicRepository, IMetodoPagoRepository
{
public MetodoPagoRepository() : base ()
{
}


public MetodoPagoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MetodoPagoEN ReadOIDDefault (int id
                                    )
{
        MetodoPagoEN metodoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                metodoPagoEN = (MetodoPagoEN)session.Get (typeof(MetodoPagoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                        else
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).List<MetodoPagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.Id);



                metodoPagoNH.Tipo = metodoPago.Tipo;


                metodoPagoNH.Valido = metodoPago.Valido;

                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (MetodoPagoEN metodoPago)
{
        MetodoPagoNH metodoPagoNH = new MetodoPagoNH (metodoPago);

        try
        {
                SessionInitializeTransaction ();
                if (metodoPago.Usuario != null) {
                        // Argumento OID y no colección.
                        metodoPagoNH
                        .Usuario = (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN)session.Load (typeof(PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN), metodoPago.Usuario.Email);

                        metodoPagoNH.Usuario.MetodoPago
                        .Add (metodoPagoNH);
                }

                session.Save (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoNH.Id;
}

public void Modify (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.Id);

                metodoPagoNH.Tipo = metodoPago.Tipo;


                metodoPagoNH.Valido = metodoPago.Valido;

                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
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
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), id);
                session.Delete (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: MetodoPagoEN
public MetodoPagoEN ReadOID (int id
                             )
{
        MetodoPagoEN metodoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                metodoPagoEN = (MetodoPagoEN)session.Get (typeof(MetodoPagoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MetodoPagoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                else
                        result = session.CreateCriteria (typeof(MetodoPagoNH)).List<MetodoPagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
