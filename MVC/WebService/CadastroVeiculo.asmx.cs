using MVC.DAO;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MVC.WebService
{
    /// <summary>
    /// Summary description for CadastroVeiculo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CadastroVeiculo : System.Web.Services.WebService
    {
        [WebMethod]
        public List<VeiculoModel> ListarVeiculo(string placa)
        {
            VeiculoBLL objVeiculoBLL = new VeiculoBLL();
            List<VeiculoModel> lstVeic = objVeiculoBLL.ListaVeiculos(placa);

            return lstVeic;
        }
    }
}
