using System;
using XamarinMediatorPatternTest.Domain.Common.Enums;

namespace XamarinMediatorPatternTest.Domain.Common.Contracts
{
    /// <summary>
    /// Enables view models and other components to communicate by adhering to a message contract.
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Sends a strong type message that has no arguments.
        /// </summary>
        /// <param name="message">The message that will be sent to objects that are listening to it.</param>
        void Send(ApplicationEvents message);

        /// <summary>
        /// Sends a strong type message with arguments of type: <typeparamref name="TArgs"/>.
        /// </summary>
        /// <typeparam name="TArgs">The type of the objects that are used as message arguments for the message.</typeparam>
        /// <param name="message">The message that will be sent to objects that are listening to it.</param>
        /// <param name="args">The arguments that will be passed to the listener's callback.</param>
        void Send<TArgs>(ApplicationEvents message, TArgs args);

        /// <summary>
        /// Run the callback on subscriber in response to a strong type message that has no arguments.
        /// </summary>
        /// <param name="message">The message that will call the call-back action.</param>
        /// <param name="action">The callback action that will be call on messages of type: <see cref="CorotosAppEvents"/>.</param>
        void Subscribe(ApplicationEvents message, Action action);

        /// <summary>
        /// Run the callback on subscriber in response to a strong type message with arguments of type: <typeparamref name="TArgs"/>.
        /// </summary>
        /// <typeparam name="TArgs">The type of the objects that are used as message arguments for the message.</typeparam>
        /// <param name="message">The message that will call the call-back action.</param>
        /// <param name="action">The callback action that will be call on messages of type: <see cref="CorotosAppEvents"/>.</param>
        void Subscribe<TArgs>(ApplicationEvents message, Action<TArgs> action);

        /// <summary>
        /// Removes the registered callback form the list of subscribed.
        /// </summary>
        /// <param name="message">The message that the specified callback was subscribe in.</param>
        /// <param name="action">The callback action that will be removed from the list of subscribed.</param>
        void Unsubscribe(ApplicationEvents message, Action action);

        /// <summary>
        /// Removes the registered callback form the list of subscribed.
        /// </summary>
        /// <typeparam name="TArgs">The type of the objects that are used as message arguments for the message.</typeparam>
        /// <param name="message">The message that the specified callback was subscribe in.</param>
        /// <param name="action">The callback action that will be removed from the list of subscribed.</param>
        void Unsubscribe<TArgs>(ApplicationEvents message, Action<TArgs> action);
    }
}
