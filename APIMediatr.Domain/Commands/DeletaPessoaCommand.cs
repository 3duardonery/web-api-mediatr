using MediatR;

namespace APIMediatr.Domain.Commands
{
    public class DeletaPessoaCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
