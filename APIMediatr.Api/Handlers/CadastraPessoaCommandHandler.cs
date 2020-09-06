﻿using APIMediatr.Api.Commands;
using APIMediatr.Api.Models;
using APIMediatr.Api.Notifications;
using APIMediatr.Api.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace APIMediatr.Api.Handlers
{
    public class CadastraPessoaCommandHandler : 
        IRequestHandler<CadastraPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public CadastraPessoaCommandHandler(IMediator mediator, 
            IRepository<Pessoa> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(CadastraPessoaCommand request, 
            CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa
            {
                Id = Guid.NewGuid().ToString(),
                Nome = request.Nome,
                Idade = request.Idade,
                Sexo = request.Sexo
            };

            try
            {
                await _repository.Add(item: pessoa);
                await _mediator.Publish(new PessoaCriadaNotification 
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Idade = pessoa.Idade,
                    Sexo = pessoa.Sexo
                });

                return await Task.FromResult(pessoa.Id);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }

        }
    }
}
