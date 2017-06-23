using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC.DAO
{
    public class VeiculoBLL
    {
        VeiculoEntities contextoDados = new VeiculoEntities();

        /// <summary>
        /// Retorna um registro da tabela Veiculo por ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public VeiculoModel SelecionarVeiculo(int ID)
        {
            Veiculo objVeic = contextoDados.Veiculoes.Find(ID);

            VeiculoModel objRetorno = new VeiculoModel();
            objRetorno.Bloqueado = objVeic.Bloqueado;
            objRetorno.CPFProprietario = objVeic.CPFProprietario;
            objRetorno.ID = objVeic.ID;
            objRetorno.NomeProprietario = objVeic.NomeProprietario;
            objRetorno.Placa = objVeic.Placa;
            objRetorno.Renavam = objVeic.Renavam;
            objRetorno.ListaImagens = new List<VeiculoImagemModel>();

            List<VeiculoImagem> lst = contextoDados.VeiculoImagems.Where(v => v.IDVeiculo.Equals(ID)).ToList();

            foreach (var imagem in lst)
            {
                VeiculoImagemModel objImagem = new VeiculoImagemModel();
                objImagem.ID = imagem.ID;
                objImagem.IDVeiculo = imagem.IDVeiculo;
                objImagem.CaminhoImagem = imagem.CaminhoImagem;

                objRetorno.ListaImagens.Add(objImagem);
            }

            return objRetorno;
        }

        /// <summary>
        /// Insere novo registro na Tabela "Veiculo"
        /// </summary>
        /// <param name="_model">Valores a serem inseridos</param>
        public int InserirVeiculo(VeiculoModel _model)
        {
            try
            {
                Veiculo objVeic = new Veiculo();
                objVeic.Placa = _model.Placa;
                objVeic.Renavam = _model.Renavam;
                objVeic.NomeProprietario = _model.NomeProprietario;
                objVeic.CPFProprietario = _model.CPFProprietario;
                objVeic.Bloqueado = _model.Bloqueado;

                contextoDados.Veiculoes.Add(objVeic);
                contextoDados.SaveChanges();

                return objVeic.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Faz update de registro na tabela "Veiculo"
        /// </summary>
        /// <param name="_model">Valores a serem alterados</param>
        public int AtualizarVeiculo(VeiculoModel _model)
        {
            // Seleciona o registro pelo ID
            var objVeic = contextoDados.Veiculoes.Find(_model.ID);

            if (objVeic != null)
            {
                // Seta os novos valores no registro
                contextoDados.Entry(objVeic).CurrentValues.SetValues(_model);
                return contextoDados.SaveChanges();
            }

            return 0;
        }

        /// <summary>
        /// Lista os registros da tabela Veiculos
        /// </summary>
        /// <param name="_placa">Filtra pela placa do Veiculo</param>
        /// <returns>Lista com registros de veículos.</returns>
        public List<VeiculoModel> ListaVeiculos(string _placa)
        {
            List<VeiculoModel> lstRetorno = new List<VeiculoModel>();
            List<Veiculo> lstVeiculos = new List<Veiculo>();

            if (!String.IsNullOrWhiteSpace(_placa))
            {
                // Retorna os registros da tabela filtrando pela placa
                lstVeiculos = contextoDados.Veiculoes.Where(v => v.Placa.Equals(_placa)).ToList();
            }
            else
            {
                // Retorna todos os registros da tabela
                lstVeiculos = contextoDados.Veiculoes.ToList();
            }

            foreach (var item in lstVeiculos)
            {
                VeiculoModel _veic = new VeiculoModel();
                _veic.Bloqueado = item.Bloqueado;
                _veic.CPFProprietario = item.CPFProprietario;
                _veic.ID = item.ID;
                _veic.NomeProprietario = item.NomeProprietario;
                _veic.Placa = item.Placa;
                _veic.Renavam = item.Renavam;

                lstRetorno.Add(_veic);
            }

            return lstRetorno;
        }

        public void InserirImagens(List<VeiculoImagemModel> _lstVeicImagensParam)
        {
            try
            {
                List<VeiculoImagem> lstVeicImagem = new List<VeiculoImagem>();
                VeiculoImagem objVeicImagem = new VeiculoImagem();

                foreach (var imagemParam in _lstVeicImagensParam)
                {
                    objVeicImagem.IDVeiculo = imagemParam.IDVeiculo;
                    objVeicImagem.CaminhoImagem = imagemParam.CaminhoImagem;

                    contextoDados.VeiculoImagems.Add(objVeicImagem);

                    contextoDados.SaveChanges();
                }
                 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<VeiculoImagemModel> ListarImagensVeiculo(int ID)
        {
            try
            {
                List<VeiculoImagemModel> lstRetorno = new List<VeiculoImagemModel>();
                var listaImagens = contextoDados.VeiculoImagems.Where(v => v.IDVeiculo.Equals(ID)).ToList();

                foreach (var img in listaImagens)
                {
                    VeiculoImagemModel obj = new VeiculoImagemModel();
                    obj.CaminhoImagem = img.CaminhoImagem;

                    lstRetorno.Add(obj);
                }

                return lstRetorno;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}