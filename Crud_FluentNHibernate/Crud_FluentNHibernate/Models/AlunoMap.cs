using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace Crud_FluentNHibernate.Models
{
    public class AlunoMap:ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.Email);
            Map(x => x.Curso);
            Map(x => x.Sexo);
            Table("Alunos");
        }
    }
}