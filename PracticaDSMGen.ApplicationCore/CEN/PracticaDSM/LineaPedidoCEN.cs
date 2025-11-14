

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class LineaPedidoCEN
 *
 */
public partial class LineaPedidoCEN
{
private ILineaPedidoRepository _ILineaPedidoRepository;

public LineaPedidoCEN(ILineaPedidoRepository _ILineaPedidoRepository)
{
        this._ILineaPedidoRepository = _ILineaPedidoRepository;
}

public ILineaPedidoRepository get_ILineaPedidoRepository ()
{
        return this._ILineaPedidoRepository;
}

public void Modify (int p_LineaPedido_OID, int p_cantidad, decimal p_precio)
{
        LineaPedidoEN lineaPedidoEN = null;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Num = p_LineaPedido_OID;
        lineaPedidoEN.Cantidad = p_cantidad;
        lineaPedidoEN.Precio = p_precio;
        //Call to LineaPedidoRepository

        _ILineaPedidoRepository.Modify (lineaPedidoEN);
}

public void Destroy (int num
                     )
{
        _ILineaPedidoRepository.Destroy (num);
}

public LineaPedidoEN ReadOID (int num
                              )
{
        LineaPedidoEN lineaPedidoEN = null;

        lineaPedidoEN = _ILineaPedidoRepository.ReadOID (num);
        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> list = null;

        list = _ILineaPedidoRepository.ReadAll (first, size);
        return list;
}
}
}
