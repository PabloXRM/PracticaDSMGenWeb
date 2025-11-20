
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Producto_decrementarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class ProductoCEN
{
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public void Crear(string descripcion, decimal precio, int stock)
        {
            throw new NotImplementedException();
        }

        public void DecrementarStock (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Producto_decrementarStock) ENABLED START*/

        // Write here your custom code...

        ProductoEN en = _IProductoRepository.ReadOID (p_oid);

        if (!(en.Stock >= p_cantidad))
                throw new ModelException ("La cantidad siempre tiene que ser inferior o igual al stock disponible");

        en.Stock -= p_cantidad;

        _IProductoRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
