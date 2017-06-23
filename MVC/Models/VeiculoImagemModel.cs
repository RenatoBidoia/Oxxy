using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class VeiculoImagemModel
    {
        public int ID { get; set; }
        public int IDVeiculo { get; set; }
        public string CaminhoImagem { get; set; }
    }
}