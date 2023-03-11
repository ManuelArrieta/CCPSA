using System;
using System.Collections.Generic;

namespace CCPSA_WS.ModelsContext
{
    public partial class ImagenLectura
    {
        public int Idimagen { get; set; }
        public byte[]? Imagen { get; set; }
        public string? NombreImagen { get; set; }
        public int? AnchoImagen { get; set; }
        public int? AltoImagen { get; set; }
        public string? TipoArchivo { get; set; }
    }
}
