using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMediatr.Api.Commands
{
    public class DeletaPessoaCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
