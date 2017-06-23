using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MVC.Models;
using MVC.DAO;
using System.IO;

namespace MVC.Controllers
{
    public class VeiculoController : Controller
    {  
        
        public ActionResult Index()
        {
            VeiculoBLL objVeiculoBLL = new VeiculoBLL();
            List<VeiculoModel> lst = objVeiculoBLL.ListaVeiculos("");

            return View(lst);
        }

        
        public ActionResult Details(int id)
        {
            VeiculoBLL objVeiculoBLL = new VeiculoBLL();
            VeiculoModel objVeic = objVeiculoBLL.SelecionarVeiculo(id);
            objVeic.ListaImagens = objVeiculoBLL.ListarImagensVeiculo(id);

            return View(objVeic);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(VeiculoModel model)
        {
            try
            {
                bool contemErros = false;

                if (!Util.ValidarCPF(model.CPFProprietario))
                {
                    ModelState.AddModelError("CPFProprietario", "CPF inválido !");
                    contemErros = true;
                }
                else
                {
                    ViewBag.CPF = "";
                }

                if (!Util.ValidaPlaca(model.Placa))
                {
                    ModelState.AddModelError("PLACA", "PLACA inválida !");
                    contemErros = true;
                }
                else
                {
                    ViewBag.PLACA = "";
                }

                if (contemErros)
                    return View(model);

                VeiculoBLL objVeiculoBLL = new VeiculoBLL();
                int ID = objVeiculoBLL.InserirVeiculo(model);
                List<VeiculoImagemModel> lstImagens = new List<VeiculoImagemModel>();

                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        string ext = Path.GetExtension(file.FileName);

                        if (Util.ExtensaoImagemValida(ext))
                        {
                            if (file.ContentLength < 500000)
                            {
                                string caminhoImagemSave = Server.MapPath("~/Imagens/") + file.FileName;

                                file.SaveAs(caminhoImagemSave);

                                VeiculoImagemModel objImagem = new VeiculoImagemModel();
                                objImagem.IDVeiculo = ID;
                                objImagem.CaminhoImagem = Path.GetFileName(caminhoImagemSave);

                                lstImagens.Add(objImagem);
                            }
                        }
                    }

                    objVeiculoBLL.InserirImagens(lstImagens);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            VeiculoBLL objVeiculoBLL = new VeiculoBLL();
            VeiculoModel objVeic = objVeiculoBLL.SelecionarVeiculo(id);       

            return View(objVeic);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, VeiculoModel model)
        {
            try
            {
                VeiculoBLL objVeiculoBLL = new VeiculoBLL();
                model.ID = id;

                objVeiculoBLL.AtualizarVeiculo(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }        
    }
}
