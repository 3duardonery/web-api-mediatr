using APIMediatr.Domain.Commands;
using APIMediatr.Domain.Interfaces;
using APIMediatr.Domain.Models;
using APIMediatr.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIMediatr.Domain.Handlers
{
    public class ExcluiPessoaCommandHandler : IRequestHandler<DeletaPessoaCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;
        public ExcluiPessoaCommandHandler(IMediator mediator, 
            IRepository<Pessoa> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(DeletaPessoaCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);

                await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, IsEfetivado = true });

                return await Task.FromResult("Pessoa excluída com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, IsEfetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}
