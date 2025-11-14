

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class ReseñaCEN
 *
 */
public partial class ReseñaCEN
{
private IReseñaRepository _IReseñaRepository;

public ReseñaCEN(IReseñaRepository _IReseñaRepository)
{
        this._IReseñaRepository = _IReseñaRepository;
}

public IReseñaRepository get_IReseñaRepository ()
{
        return this._IReseñaRepository;
}

public int New_ (string p_usuario, int p_producto, string p_descripcion, int p_nota, Nullable<DateTime> p_fecha)
{
        ReseñaEN reseñaEN = null;
        int oid;

        //Initialized ReseñaEN
        reseñaEN = new ReseñaEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                reseñaEN.Usuario = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN ();
                reseñaEN.Usuario.Email = p_usuario;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                reseñaEN.Producto = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN ();
                reseñaEN.Producto.Id = p_producto;
        }

        reseñaEN.Descripcion = p_descripcion;

        reseñaEN.Nota = p_nota;

        reseñaEN.Fecha = p_fecha;



        oid = _IReseñaRepository.New_ (reseñaEN);
        return oid;
}

public void Modify (int p_Reseña_OID, string p_descripcion, int p_nota, Nullable<DateTime> p_fecha)
{
        ReseñaEN reseñaEN = null;

        //Initialized ReseñaEN
        reseñaEN = new ReseñaEN ();
        reseñaEN.Id = p_Reseña_OID;
        reseñaEN.Descripcion = p_descripcion;
        reseñaEN.Nota = p_nota;
        reseñaEN.Fecha = p_fecha;
        //Call to ReseñaRepository

        _IReseñaRepository.Modify (reseñaEN);
}

public void Destroy (int id
                     )
{
        _IReseñaRepository.Destroy (id);
}

public ReseñaEN ReadOID (int id
                         )
{
        ReseñaEN reseñaEN = null;

        reseñaEN = _IReseñaRepository.ReadOID (id);
        return reseñaEN;
}

public System.Collections.Generic.IList<ReseñaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ReseñaEN> list = null;

        list = _IReseñaRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> DameReseñaPorProducto (int ? p_idProducto)
{
        return _IReseñaRepository.DameReseñaPorProducto (p_idProducto);
}
}
}
