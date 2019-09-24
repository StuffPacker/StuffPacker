using StuffPacker.Model.Messaging;
using System;

namespace StuffPacker.Services
{
    public interface IMessageService
    {
        void SendMessage(ActionMessage message);

        IObservable<ActionMessage> MessageStream();

        IDisposable Subscribe(Action<ActionMessage> onNext);
    }
}
