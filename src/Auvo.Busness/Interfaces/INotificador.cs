using System.Collections.Generic;

namespace Auvo.Busness.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao.Notificacao> ObterNotificacoes();
        void Handle(Notificacao.Notificacao notificacao);
    }
}
