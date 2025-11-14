
using System;
// Definición clase PerfilEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class PerfilEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario;



/**
 *	Atributo tema
 */
private PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TemaEnum tema;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TemaEnum Tema {
        get { return tema; } set { tema = value;  }
}





public PerfilEN()
{
}



public PerfilEN(int id, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TemaEnum tema
                )
{
        this.init (Id, usuario, tema);
}


public PerfilEN(PerfilEN perfil)
{
        this.init (perfil.Id, perfil.Usuario, perfil.Tema);
}

private void init (int id
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TemaEnum tema)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Tema = tema;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PerfilEN t = obj as PerfilEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
