

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class MetodoPagoCEN
 *
 */
public partial class MetodoPagoCEN
{
private IMetodoPagoRepository _IMetodoPagoRepository;

public MetodoPagoCEN(IMetodoPagoRepository _IMetodoPagoRepository)
{
        this._IMetodoPagoRepository = _IMetodoPagoRepository;
}

public IMetodoPagoRepository get_IMetodoPagoRepository ()
{
        return this._IMetodoPagoRepository;
}

public void Modify (int p_MetodoPago_OID, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoPagoEnum p_tipo, bool p_valido)
{
        MetodoPagoEN metodoPagoEN = null;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();
        metodoPagoEN.Id = p_MetodoPago_OID;
        metodoPagoEN.Tipo = p_tipo;
        metodoPagoEN.Valido = p_valido;
        //Call to MetodoPagoRepository

        _IMetodoPagoRepository.Modify (metodoPagoEN);
}

public void Destroy (int id
                     )
{
        _IMetodoPagoRepository.Destroy (id);
}

public MetodoPagoEN ReadOID (int id
                             )
{
        MetodoPagoEN metodoPagoEN = null;

        metodoPagoEN = _IMetodoPagoRepository.ReadOID (id);
        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> list = null;

        list = _IMetodoPagoRepository.ReadAll (first, size);
        return list;
}
}
}
