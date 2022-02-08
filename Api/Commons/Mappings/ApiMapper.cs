using Api.Commons.Models.Dtos;
using AutoMapper;
using Domain.Common.Entities;
using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Commons.Mappings
{
    public partial class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<VPedidosModel, VPedidosResponse>();
            CreateMap<VEnderecoModel, VEnderecoResponse>();
            CreateMap<Produto, ProdutoResponse>();
        }
    }
}
