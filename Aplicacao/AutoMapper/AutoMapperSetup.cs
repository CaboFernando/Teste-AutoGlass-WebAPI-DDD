using Aplicacao.ViewModels;
using AutoMapper;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}
