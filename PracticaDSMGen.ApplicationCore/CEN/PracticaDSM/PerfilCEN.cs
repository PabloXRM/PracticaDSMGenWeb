

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class PerfilCEN
 *
 */
public partial class PerfilCEN
{
private IPerfilRepository _IPerfilRepository;

public PerfilCEN(IPerfilRepository _IPerfilRepository)
{
        this._IPerfilRepository = _IPerfilRepository;
}

public IPerfilRepository get_IPerfilRepository ()
{
        return this._IPerfilRepository;
}

public void Modify (int p_Perfil_OID, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TemaEnum p_tema)
{
        PerfilEN perfilEN = null;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();
        perfilEN.Id = p_Perfil_OID;
        perfilEN.Tema = p_tema;
        //Call to PerfilRepository

        _IPerfilRepository.Modify (perfilEN);
}

public void Destroy (int id
                     )
{
        _IPerfilRepository.Destroy (id);
}

public PerfilEN ReadOID (int id
                         )
{
        PerfilEN perfilEN = null;

        perfilEN = _IPerfilRepository.ReadOID (id);
        return perfilEN;
}

public System.Collections.Generic.IList<PerfilEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PerfilEN> list = null;

        list = _IPerfilRepository.ReadAll (first, size);
        return list;
}
}
}
