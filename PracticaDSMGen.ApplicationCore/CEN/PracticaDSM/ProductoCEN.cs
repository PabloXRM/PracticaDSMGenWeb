

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoRepository _IProductoRepository;

public ProductoCEN(IProductoRepository _IProductoRepository)
{
        this._IProductoRepository = _IProductoRepository;
}

public IProductoRepository get_IProductoRepository ()
{
        return this._IProductoRepository;
}

public int New_ (string p_descripcion, decimal p_precio, int p_stock, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum p_formato, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum p_estilo, string p_fotos, string p_artista)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Descripcion = p_descripcion;

        productoEN.Precio = p_precio;

        productoEN.Stock = p_stock;

        productoEN.Formato = p_formato;

        productoEN.Estilo = p_estilo;

        productoEN.Fotos = p_fotos;

        productoEN.Artista = p_artista;



        oid = _IProductoRepository.New_ (productoEN);
        return oid;
}

public void Modify (int p_Producto_OID, string p_descripcion, decimal p_precio, int p_stock, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum p_formato, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum p_estilo, string p_fotos, string p_artista)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_Producto_OID;
        productoEN.Descripcion = p_descripcion;
        productoEN.Precio = p_precio;
        productoEN.Stock = p_stock;
        productoEN.Formato = p_formato;
        productoEN.Estilo = p_estilo;
        productoEN.Fotos = p_fotos;
        productoEN.Artista = p_artista;
        //Call to ProductoRepository

        _IProductoRepository.Modify (productoEN);
}

public void Destroy (int id
                     )
{
        _IProductoRepository.Destroy (id);
}

public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoRepository.ReadOID (id);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoRepository.ReadAll (first, size);
        return list;
}
}
}
