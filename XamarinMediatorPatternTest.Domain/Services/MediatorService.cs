using System;
using System.Threading.Tasks;
using XamarinMediatorPatternTest.Domain.Common.Enums;

namespace XamarinMediatorPatternTest.Domain.Services
{
    /// <summary>
    /// The Main mediator service class for subscribing end emitting events. 
    /// </summary>
    public static class MediatorService
    {
        private static Mediator _mediator { get; set; } = new Mediator();

        public static void InitService()
        {
            MediatorService.Subscribe(
                ApplicationEvents.SendMessage,
                MediatorService.MediatorFlowSimulateHeavyTask);
        }

        //Test Method for the mediator flow.
        public static async void MediatorFlowSimulateHeavyTask()
        {
            await Task.Delay(15000);

            _mediator.Send(ApplicationEvents.MediatorChallenged);
        }

        #region Indirect Mediator Methods Access.
        public static void Send(ApplicationEvents message)
        {
            _mediator.Send(message);
        }

        public static void Send<TArgs>(ApplicationEvents message, TArgs args)
        {
            _mediator.Send(message, args);
        }

        public static void Subscribe(ApplicationEvents message, Action action)
        {
            _mediator.Subscribe(message, action);
        }

        public static void Subscribe<TArgs>(ApplicationEvents message, Action<TArgs> action)
        {
            _mediator.Subscribe(message, action);
        }

        public static void Unsubscribe(ApplicationEvents message, Action action)
        {
            _mediator.Unsubscribe(message, action);
        }

        public static void Unsubscribe<TArgs>(ApplicationEvents message, Action<TArgs> action)
        {
            _mediator.Unsubscribe(message, action);
        }
        #endregion
    }
}
