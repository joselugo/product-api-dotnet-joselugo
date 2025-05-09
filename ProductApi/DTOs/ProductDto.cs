﻿namespace ProductApi.DTOs
{
    public class ProductDto
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
    }
}
