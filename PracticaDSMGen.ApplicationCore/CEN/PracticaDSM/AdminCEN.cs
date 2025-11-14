

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminRepository _IAdminRepository;

public AdminCEN(IAdminRepository _IAdminRepository)
{
        this._IAdminRepository = _IAdminRepository;
}

public IAdminRepository get_IAdminRepository ()
{
        return this._IAdminRepository;
}

public string New_ (string p_email, string p_nombre, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN p_perfil, string p_direccion, Nullable<DateTime> p_fechaNacimiento, int p_codPostal, String p_pass, string p_idAdmin)
{
        AdminEN adminEN = null;
        string oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_email;

        adminEN.Nombre = p_nombre;

        adminEN.Perfil = p_perfil;

        adminEN.Direccion = p_direccion;

        adminEN.FechaNacimiento = p_fechaNacimiento;

        adminEN.CodPostal = p_codPostal;

        adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        adminEN.IdAdmin = p_idAdmin;



        oid = _IAdminRepository.New_ (adminEN);
        return oid;
}

public void Modify (string p_Admin_OID, string p_nombre, string p_direccion, Nullable<DateTime> p_fechaNacimiento, int p_codPostal, string p_idAdmin)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_Admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Direccion = p_direccion;
        adminEN.FechaNacimiento = p_fechaNacimiento;
        adminEN.CodPostal = p_codPostal;
        adminEN.IdAdmin = p_idAdmin;
        //Call to AdminRepository

        _IAdminRepository.Modify (adminEN);
}

public void Destroy (string email
                     )
{
        _IAdminRepository.Destroy (email);
}

public AdminEN ReadOID (string email
                        )
{
        AdminEN adminEN = null;

        adminEN = _IAdminRepository.ReadOID (email);
        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> list = null;

        list = _IAdminRepository.ReadAll (first, size);
        return list;
}
}
}
