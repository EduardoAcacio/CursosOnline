using System;
using System.Collections.Generic;
using System.Text;

namespace CursosOnline.Domain.Cursos
{
    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor, string descricao)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome invalido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horaria invalida");

            if (valor < 1)
                throw new ArgumentException("Valor invalido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }
    }
}
