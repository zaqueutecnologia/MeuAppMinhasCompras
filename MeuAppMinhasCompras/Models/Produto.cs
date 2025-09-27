﻿using SQLite; // Professor Argeli! Segue o código da atividade da Agenda 05.

namespace MeuAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Descricao {
            get => _descricao;
            set
            {
                if(value == null) 
                {
                    throw new Exception("Por favor, preencha a descrição");
                }

                _descricao = value;
            }
        }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }
    }
}
