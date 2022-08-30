using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Models
{
    public class Cliente
    {
        public Cliente(string nome, DateTime nascimento, string email)
        {
            Nome = nome;
            Nascimento = nascimento;
            Email = email;
        }

        public int Id { get; private set; }

        [Required(ErrorMessage ="Nome é necessário")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "Data de nascimento é necessário")]
        [Display(Name ="Data de nascimento")]
        public DateTime Nascimento { get; private set; }

        [Required(ErrorMessage = "Um E-Mail é necessário")]
        public string Email { get; private set; }

        public int Idade()
        {
            int idade = DateTime.Now.Year - Nascimento.Year;

            if (DateTime.Now.DayOfYear < Nascimento.DayOfYear)
                idade--;

            return idade;
        }

        public void AtualizaDados(string nome, DateTime nascimento, string email)
        {
            Nome = nome;
            Nascimento = nascimento;
            Email = email;
        }
    }
}
