using System;
using System.ComponentModel.DataAnnotations;

namespace Site.Areas.w7painel.Models
{
    public class HistoricoLogin
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public Usuario Usuario { get; set; }
    }
}