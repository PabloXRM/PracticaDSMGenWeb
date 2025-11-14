

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class FacturaCEN
 *
 */
public partial class FacturaCEN
{
private IFacturaRepository _IFacturaRepository;

public FacturaCEN(IFacturaRepository _IFacturaRepository)
{
        this._IFacturaRepository = _IFacturaRepository;
}

public IFacturaRepository get_IFacturaRepository ()
{
        return this._IFacturaRepository;
}

public int New_ (int p_pedido, string p_numero, decimal p_importeTotal, Nullable<DateTime> p_fecha)
{
        FacturaEN facturaEN = null;
        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();

        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                facturaEN.Pedido = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN ();
                facturaEN.Pedido.Id = p_pedido;
        }

        facturaEN.Numero = p_numero;

        facturaEN.ImporteTotal = p_importeTotal;

        facturaEN.Fecha = p_fecha;



        oid = _IFacturaRepository.New_ (facturaEN);
        return oid;
}

public void Modify (int p_Factura_OID, string p_numero, decimal p_importeTotal, Nullable<DateTime> p_fecha)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Id = p_Factura_OID;
        facturaEN.Numero = p_numero;
        facturaEN.ImporteTotal = p_importeTotal;
        facturaEN.Fecha = p_fecha;
        //Call to FacturaRepository

        _IFacturaRepository.Modify (facturaEN);
}

public void Destroy (int id
                     )
{
        _IFacturaRepository.Destroy (id);
}

public FacturaEN ReadOID (int id
                          )
{
        FacturaEN facturaEN = null;

        facturaEN = _IFacturaRepository.ReadOID (id);
        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> list = null;

        list = _IFacturaRepository.ReadAll (first, size);
        return list;
}
}
}
