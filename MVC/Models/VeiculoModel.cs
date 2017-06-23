using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    [Serializable]
    public class VeiculoModel
    {
        public int ID { get; set; }
                
        [Required(ErrorMessage = "O Campo PLACA é obrigatório")]
        [StringLength(8)]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O Campo RENAVAM é obrigatório")]   
        [MinLength(9)]
        [MaxLength(11)]
        public string Renavam { get; set; }

        [Required(ErrorMessage = "O Campo NOME DO PROPRIETÁRIO é obrigatório")] 
        public string NomeProprietario { get; set; }

        [Required(ErrorMessage = "O Campo CPF é obrigatório")]
        [StringLength(11)]
        public string CPFProprietario { get; set; }

        public bool Bloqueado { get; set; }

        public List<VeiculoImagemModel> ListaImagens { get; set; }

    }
}