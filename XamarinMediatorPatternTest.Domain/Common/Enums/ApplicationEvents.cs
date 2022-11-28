
namespace XamarinMediatorPatternTest.Domain.Common.Enums
{
    /// <summary>
    /// Holds all application's events.
    /// </summary>
    public enum ApplicationEvents : byte
    {
        /// <summary>
        /// Indicates a not selected event.
        /// </summary>
        None,

        #region Mediator Test Events

        /// <summary>
        /// Test event triggered on send message.
        /// </summary>
        SendMessage,

        /// <summary>
        /// Test event triggered on send message with parameter.
        /// </summary>
        SendMessageWithParameter,
        
        /// <summary>
        /// Test event triggered on Mediator flow challenged.
        /// </summary>
        MediatorChallenged,

        /// <summary>
        /// Test event triggered on Mediator flow challenged.
        /// </summary>
        MediatorChallengedWithParameter,

        #endregion
    }
    }
