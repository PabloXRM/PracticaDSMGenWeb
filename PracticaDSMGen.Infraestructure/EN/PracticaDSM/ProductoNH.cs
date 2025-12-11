using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;

namespace PracticaDSMGen.Infraestructure.EN.PracticaDSM
{
    public partial class ProductoNH : ProductoEN
    {
        public ProductoNH()
        {
        }

        public ProductoNH(ProductoEN dto) : base(dto)
        {
        }

        public virtual object Proveedor { get; set; }
        public virtual object Proveedor2 { get; set; }
    }
}
