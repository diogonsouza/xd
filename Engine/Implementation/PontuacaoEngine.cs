using System;
using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core.Cryptography;
using Model;

namespace Engine.Implementation
{
    public class PontuacaoEngine : IPontuacaoEngine
    {
        private readonly IPontuacaoBusiness _pontuacaoBusiness;
        private readonly ITokenEngine _tokenEngine;
        private readonly IPontosEngine _pontosEngine;

        public PontuacaoEngine(SymmetricBase crypto,
                             IPontuacaoBusiness pontuacaoBusiness,ITokenEngine tokenEngine,
                             IPontosEngine pontosEngine)
        {
            this._pontuacaoBusiness = pontuacaoBusiness;
            this._tokenEngine = tokenEngine;
            this._pontosEngine = pontosEngine;
        }

        public decimal Cadastrar(Pontuacao pontuacao)
        {
            pontuacao.TotalPontos = atualizarBase(pontuacao);
            return pontuacao.TotalPontos;
        }

        private decimal atualizarBase(Pontuacao pontuacao)
        {
            Pontuacao pontuacaoResult = cadastrarPontuacao(pontuacao);
            return pontuacaoResult.TotalPontos;
        }

        private Pontuacao cadastrarPontuacao(Pontuacao pontuacao)
        {
            this._pontuacaoBusiness.Add(pontuacao);
            try
            {
                this._pontuacaoBusiness.Save();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string message = (ex.InnerException?.InnerException?.Message) ?? string.Empty;
                if (message.ToLower().Contains("IX_TB_SITE_USUARIO_NR_CPF".ToLower()))
                    throw new CPFJaCadastradoException();
                else if (message.ToLower().Contains("IX_TB_SITE_USUARIO_EN_EMAI".ToLower()))
                    throw new EmailJaCadastradoException();
                else throw;
            }

            return pontuacao;
        }

        public Pontuacao Atualizar(Pontuacao pontuacao)
        {
            this._pontuacaoBusiness.Update(pontuacao);
            this._pontuacaoBusiness.Save();
            return pontuacao;
        }

        public Pontuacao ObterPorId(int usuarioId)
        {
            return this._pontuacaoBusiness.ObterPorUsuario(usuarioId);
        }

       
        public Pontuacao PontuarCompartilhamento(Compartilhamento compartilhamento) {

            Token token = this._tokenEngine.ObterPorId(compartilhamento.TokenId);
            int tipo = (int) EnumTipoPonto.compartilhamento;
            RegrasPontuacao pontos = this._pontosEngine.ObterPorTipo(tipo);
            Pontuacao pontuacao = ObterPorId(token.Id_usuario);
            pontuacao.TotalPontos = pontuacao.TotalPontos + pontos.Valor;
            Pontuacao pontuacaoResult = Atualizar(pontuacao);
            return pontuacao;
               
        }

        public int ObterPosicao(Pontuacao pontuacao, Usuario usuario)
        {
            int posicao = this._pontuacaoBusiness.ObterPosicao(pontuacao, usuario);
            int posicaoRepetidos = this._pontuacaoBusiness.ObterRepetidos(pontuacao, usuario);
            int posicaoDesempate = this._pontuacaoBusiness.ObterPorDataDesenpate(pontuacao, usuario);

            int resultado = (posicao - posicaoRepetidos) + posicaoDesempate;

            return resultado;
        }

        public Pontuacao PontuarQuiz(Usuario usuario) {
            int tipo = (int)EnumTipoPonto.questionario;
            RegrasPontuacao pontos = this._pontosEngine.ObterPorTipo(tipo);
            Pontuacao pontuacao = ObterPorId(usuario.UsuarioId);

            pontuacao.TotalPontos = pontuacao.TotalPontos + pontos.Valor;
            pontuacao = Atualizar(pontuacao);
            return pontuacao;
        }

        public Pontuacao PontuarPorTempo(Usuario usuario)
        {
            //criar regras de tempo para pontuar;
            
            int tipo = (int)EnumTipoPonto.tempo;
            RegrasPontuacao pontos = this._pontosEngine.ObterPorTipo(tipo);
            Pontuacao pontuacao = ObterPorId(usuario.UsuarioId);
            pontuacao.TotalPontos = pontuacao.TotalPontos + 1;

            int daysDiff = (usuario.DataCriacao - pontos.DataInicio).Days;
            decimal bonus =0;
            switch (pontos.TipoRecorrencia)
            {
                case 1:
                    bonus = PontuaPorSemana(pontos, daysDiff);
                    break;
                case 2:
                    bonus = PontuaPorMes(pontos, daysDiff);
                    break;
                default:
                    bonus = 0;
                    break;
            }
            pontuacao.TotalPontos = pontuacao.TotalPontos + bonus;
            pontuacao = Atualizar(pontuacao);
            return pontuacao;
        }

        public decimal PontuaPorSemana(RegrasPontuacao ponto,int dateDiff)
        {
            double total = 0;
            double percentual = 10.0 / 100.0;
            double valor = double.Parse(ponto.Valor.ToString());

            if (dateDiff <= ponto.Recorrencia)
            {
                total = valor;
            }
            else if (dateDiff <= (ponto.Recorrencia * 2))
            {
                total = valor - (percentual * valor);
            }
            else if (dateDiff <= (ponto.Recorrencia * 3))
            {
                percentual = 20.0 / 100.0;
                total = valor - (percentual * valor);
            }
            else if (dateDiff <= (ponto.Recorrencia * 4))
            {
                percentual = 30.0 / 100.0;
                total = valor - (percentual * valor);
            }
            else if (dateDiff <= (ponto.Recorrencia * 5))
            {
                percentual = 40.0 / 100.0;
                total = valor - (percentual * valor);
            }
            else {
                percentual = 50.0 / 100.0;
                total = valor - (percentual * valor);
            }

            decimal ResultTotal = decimal.Parse(total.ToString());
            return ResultTotal;
        }

        public decimal PontuaPorMes(RegrasPontuacao ponto, int dateDiff)
        {
            double total = 0;
            double percentual = 10.0 / 100.0;
            int month = 30 * ponto.Recorrencia;
            double valor = double.Parse(ponto.Valor.ToString());

            if (dateDiff <= 30)
            {
                total = valor;
            }
            else if (dateDiff <= (month*2))
            {
                total = valor - (percentual * valor);
            }
            else if (dateDiff <= (month * 3))
            {
                percentual = 20.0 / 100.0;
                total = valor - (percentual * valor);
            }
            else if (dateDiff <= (month * 4))
            {
                percentual = 30.0 / month;
                total = valor - (percentual * valor);
            }
            else if (dateDiff <= (month * 5))
            {
                percentual = 40.0 / 100.0;
                total = valor - (percentual * valor);
            }
            else
            {
                percentual = 50.0 / 100.0;
                total = valor - (percentual * valor);
            }
            decimal ResultTotal = decimal.Parse(total.ToString());

            return ResultTotal;
        }
    }
}
