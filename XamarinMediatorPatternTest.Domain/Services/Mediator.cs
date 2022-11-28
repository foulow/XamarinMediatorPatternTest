using System;
using System.Collections.Generic;
using System.Linq;
using XamarinMediatorPatternTest.Domain.Common.Contracts;
using XamarinMediatorPatternTest.Domain.Common.Enums;

namespace XamarinMediatorPatternTest.Domain.Services
{
    /// <summary>
    /// Enables view models and other components to communicate by adhering to a message contract.
    /// </summary>
    public class Mediator : IMediator
    {
        #region Fields

        private Dictionary<ApplicationEvents, List<Action>> _eventList;
        private Dictionary<ApplicationEvents, List<object>> _eventListGeneric;

        #endregion

        /// <summary>
        /// Default constructor use only on the IoC container.
        /// </summary>
        public Mediator()
        {
            _eventList = new Dictionary<ApplicationEvents, List<Action>>();
            _eventListGeneric = new Dictionary<ApplicationEvents, List<object>>();
        }

        #region Send Message

        /// <inheritdoc/>
        public void Send(ApplicationEvents message)
        {
            // Returns y event doesn't have subscribers. (Is not registered).
            // Removes callBack from the list if object was collected by the CG.
            // Calls the callbacks if found.
            // Checks if event does not have subscribers and removes it from the list.
            if (!_eventList.Keys.Contains(message))
                return;

            var subscribers = _eventList[message];
            for (var index = 0; index < subscribers.Count; index++)
            {
                var callBack = subscribers[index];
                if (callBack is null)
                {
                    subscribers.Remove(callBack);
                    index--;
                    continue;
                }

                callBack.Invoke();
            }

            if (subscribers.Count == 0)
                _eventList.Remove(message);
        }

        /// <inheritdoc/>
        public void Send<TArgs>(ApplicationEvents message, TArgs args)
        {
            if (!_eventListGeneric.Keys.Contains(message))
                return;

            var subscribers = _eventListGeneric[message];
            for (var i = 0; i < subscribers.Count; i++)
            {
                var subscriber = subscribers[i];
                if (!(subscriber is Action<TArgs> action))
                {
                    subscribers.Remove(subscriber);
                    i--;
                    continue;
                }

                action.Invoke(args);
            }

            if (subscribers.Count == 0)
                _eventListGeneric.Remove(message);
        }

        #endregion

        #region Subscribe Message

        /// <inheritdoc/>
        public void Subscribe(ApplicationEvents message, Action action)
        {
            // Fist condition: prevents null reference exception.
            // Second condition: checks if action is already subscribe before adding it.
            // Else condition: checks if key does not exits and adds to the events list.
            if (_eventList.Keys.Contains(message) && !_eventList[message].Contains(action))
                _eventList[message].Add(action);
            else if (!_eventList.Keys.Contains(message))
                _eventList.Add(message, new List<Action> { action });
        }

        /// <inheritdoc/>
        public void Subscribe<TArgs>(ApplicationEvents message, Action<TArgs> action)
        {
            if (_eventListGeneric.Keys.Contains(message) && !_eventListGeneric[message].Contains(action))
                _eventListGeneric[message].Add(action);
            else if (!_eventListGeneric.Keys.Contains(message))
                _eventListGeneric.Add(message, new List<object> { action });
        }

        #endregion

        #region Unsubscribe

        /// <inheritdoc/>
        public void Unsubscribe(ApplicationEvents message, Action action)
        {
            // Returns y event doesn't have subscribers. (Is not registered).
            // Checks if action is already subscribe before removing it.
            // Checks if event does not have subscribers and removes it from the list.
            if (!_eventList.Keys.Contains(message))
                return;

            if (_eventList[message].Contains(action))
                _eventList[message].Remove(action);

            if (_eventList[message].Count == 0)
                _eventList.Remove(message);
        }

        /// <inheritdoc/>
        public void Unsubscribe<TArgs>(ApplicationEvents message, Action<TArgs> action)
        {
            if (!_eventListGeneric.Keys.Contains(message))
                return;

            if (_eventListGeneric[message].Contains(action))
                _eventListGeneric[message].Remove(action);

            if (_eventListGeneric[message].Count == 0)
                _eventListGeneric.Remove(message);
        }

        #endregion
    }
}
