using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DadosJson.Models
{
    public class EmailModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Categoria { get; set; }
    }
}