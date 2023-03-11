using System;
using System.Collections.Generic;

namespace CCPSA_WS.ModelsContext
{
    public partial class Producto
    {
        public string Codigo { get; set; } = null!;
        public string Referencia { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Precio { get; set; } = null!;
        public string Existencia { get; set; } = null!;
        public string Pum { get; set; } = null!;
    }
}
