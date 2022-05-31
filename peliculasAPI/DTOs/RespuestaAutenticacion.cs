using System;

namespace peliculasAPI.DTOs
{
    public class RespuestaAutenticacion
    {
        public string Token { get; set; }
        public DateTime Expiraciom { get; set; }
    }
}
