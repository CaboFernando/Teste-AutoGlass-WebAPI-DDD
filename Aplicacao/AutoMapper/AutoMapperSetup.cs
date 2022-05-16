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
            #region ViewModel -> Entidade

            CreateMap<ProdutoViewModel, Produto>();

            #endregion

            #region Entidade -> ViewModel 

            CreateMap<Produto, ProdutoViewModel>();

            #endregion

        }
    }
}
