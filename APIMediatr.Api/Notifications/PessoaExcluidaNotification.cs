using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMediatr.Api.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public string Id { get; set; }
        public bool IsEfetivado { get; set; }
    }

}
