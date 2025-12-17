

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
 * Clase Producto:
 *
 */

namespace PracticaDSMGen.Infraestructure.Repository.PracticaDSM
{
public partial class ProductoRepository : BasicRepository, IProductoRepository
{
public ProductoRepository() : base ()
{
}


public ProductoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ProductoEN ReadOIDDefault (int id
                                  )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.Id);




                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.Stock = producto.Stock;


                productoNH.Formato = producto.Formato;


                productoNH.Estilo = producto.Estilo;


                productoNH.Fotos = producto.Fotos;


                productoNH.Artista = producto.Artista;

                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProductoEN producto)
{
        ProductoNH productoNH = new ProductoNH (producto);

        try
        {
                SessionInitializeTransaction ();

                session.Save (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoNH.Id;
}

public void Modify (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.Id);

                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.Stock = producto.Stock;


                productoNH.Formato = producto.Formato;


                productoNH.Estilo = producto.Estilo;


                productoNH.Fotos = producto.Fotos;


                productoNH.Artista = producto.Artista;

                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
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
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), id);

                // Manually remove the product from associated Estanterias to avoid FK constraint violation
                if (productoNH.Estanteria != null && productoNH.Estanteria.Count > 0) {
                        System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanterias = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> (productoNH.Estanteria);
                        foreach (PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN estanteria in estanterias) {
                                estanteria.Producto.Remove (productoNH);
                                session.Update (estanteria);
                        }
                        productoNH.Estanteria.Clear ();
                }

                session.Delete (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ProductoEN
public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new PracticaDSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
