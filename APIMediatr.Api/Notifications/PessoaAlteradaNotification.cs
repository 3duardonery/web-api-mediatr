﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMediatr.Api.Notifications
{
    public class PessoaAlteradaNotification : INotification
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public bool IsEfetivado { get; set; }
    }

}
