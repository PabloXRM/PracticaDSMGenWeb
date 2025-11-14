

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class EstanteriaCEN
 *
 */
public partial class EstanteriaCEN
{
private IEstanteriaRepository _IEstanteriaRepository;

public EstanteriaCEN(IEstanteriaRepository _IEstanteriaRepository)
{
        this._IEstanteriaRepository = _IEstanteriaRepository;
}

public IEstanteriaRepository get_IEstanteriaRepository ()
{
        return this._IEstanteriaRepository;
}

public int New_ (string p_usuario, System.Collections.Generic.IList<int> p_producto, string p_descripcion, string p_valoracion, int p_visitas, bool p_visible)
{
        EstanteriaEN estanteriaEN = null;
        int oid;

        //Initialized EstanteriaEN
        estanteriaEN = new EstanteriaEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                estanteriaEN.Usuario = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN ();
                estanteriaEN.Usuario.Email = p_usuario;
        }


        estanteriaEN.Producto = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN>();
        if (p_producto != null) {
                foreach (int item in p_producto) {
                        PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN en = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN ();
                        en.Id = item;
                        estanteriaEN.Producto.Add (en);
                }
        }

        else{
                estanteriaEN.Producto = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN>();
        }

        estanteriaEN.Descripcion = p_descripcion;

        estanteriaEN.Valoracion = p_valoracion;

        estanteriaEN.Visitas = p_visitas;

        estanteriaEN.Visible = p_visible;



        oid = _IEstanteriaRepository.New_ (estanteriaEN);
        return oid;
}

public void Destroy (int id
                     )
{
        _IEstanteriaRepository.Destroy (id);
}

public EstanteriaEN ReadOID (int id
                             )
{
        EstanteriaEN estanteriaEN = null;

        estanteriaEN = _IEstanteriaRepository.ReadOID (id);
        return estanteriaEN;
}

public System.Collections.Generic.IList<EstanteriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EstanteriaEN> list = null;

        list = _IEstanteriaRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> DameEstanteriaPorProducto (int ? p_idProducto)
{
        return _IEstanteriaRepository.DameEstanteriaPorProducto (p_idProducto);
}
}
}
