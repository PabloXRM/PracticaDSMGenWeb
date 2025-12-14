

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using Newtonsoft.Json;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public string New_ (string p_email, string p_nombre, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN p_perfil, string p_direccion, Nullable<DateTime> p_fechaNacimiento, int p_codPostal, String p_pass)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Perfil = p_perfil;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.FechaNacimiento = p_fechaNacimiento;

        usuarioEN.CodPostal = p_codPostal;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);



        oid = _IUsuarioRepository.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_nombre, string p_direccion, Nullable<DateTime> p_fechaNacimiento, int p_codPostal)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Direccion = p_direccion;
        usuarioEN.FechaNacimiento = p_fechaNacimiento;
        usuarioEN.CodPostal = p_codPostal;
        //Call to UsuarioRepository

        _IUsuarioRepository.Modify (usuarioEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioRepository.Destroy (email);
}

public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioRepository.ReadOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.ReadAll (first, size);
        return list;
}
public string Login (string p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Email);

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> DamePorEstanteria (int ? p_idEstanteria)
{
        return _IUsuarioRepository.DamePorEstanteria (p_idEstanteria);
}
public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> DamePorReseña (int ? p_idReseña)
{
        return _IUsuarioRepository.DamePorReseña (p_idReseña);
}

public void ChangePassword(string p_Usuario_OID, string p_newPass)
        {
            // hash igual que en New_
            string hashed = Utils.Util.GetEncondeMD5(p_newPass);
            _IUsuarioRepository.ChangePassword(p_Usuario_OID, hashed);
        }


        private string Encode (string email)
{
        var payload = new Dictionary<string, object>(){
                { "email", email }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string email)
{
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (email);
        string token = Encode (en.Email);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerEMAIL (decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);

                if (en != null && ((string)en.Email).Equals (ObtenerEMAIL (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerEMAIL (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string email = (string)results ["email"];
                return email;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
