using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace System.Waf.Presentation.Commands
{
    /// <summary>
    /// Defines the command behavior binding
    /// </summary>
    public class EventActuator : IDisposable
    {
        #region Properties
        /// <summary>
        /// The event name to hook up to
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public string EventName { get; private set; }

        #region Execution
        /// <summary>
        /// Gets or sets a CommandParameter
        /// </summary>
        public object CommandParameter { get; set; }

        /// <summary>
        /// The command to execute when the specified event is raised
        /// </summary>
        public ICommand Command { get; set; }

        /// <summary>
        /// Get the owner of the event binding ex: a Button
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public object Owner { get; private set; }

        /// <summary>
        /// The event info of the event
        /// </summary>
        public EventInfo Event { get; private set; }

        /// <summary>
        /// Gets the EventHandler for the binding with the event
        /// </summary>
        public Delegate EventHandler { get; private set; }
        #endregion

        #endregion
        /// <summary>
        /// Event binding
        /// </summary>
        /// <param name="aOwner"></param>
        /// <param name="aEventName"></param>
        public void BindEvent(object aOwner, string aEventName)
        {
            this.EventName = aEventName;
            this.Owner = aOwner;

            if (string.IsNullOrEmpty(aEventName) == false)
            {
                try
                {
                    //  Get the event info from the event name.
                    EventInfo eventInfo = aOwner.GetType().GetEvent(EventName);

                    //  Get the method info for the event proxy.
                    MethodInfo methodInfo = GetType().GetMethod("EventProxy", BindingFlags.NonPublic | BindingFlags.Instance);

                    //  Create a delegate for the event to the event proxy.
                    Delegate del = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);

                    //  Add the event handler. (Removing it first if it already exists!)
                    eventInfo.RemoveEventHandler(aOwner, del);
                    eventInfo.AddEventHandler(aOwner, del);

                    this.Event = eventInfo;
                    this.EventHandler = del;
                }
                catch (Exception e)
                {
                    e.ToString(); // Avoid warning. :)
#if DEBUG
                    throw e;
#endif
                }
            }
            else
            {
                Debug.Write("A empty event name pass into EventActuator.BindEvent function.");
            }
        }

        /// <summary>
        /// Proxy to actually fire the event.
        /// </summary>
        /// <param name="o">The object.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void EventProxy(object o, EventArgs e)
        {
            if (Command == null)
                throw new InvalidOperationException("Command property cannot be null when executing");

            if (Command.CanExecute(CommandParameter) == true)
                Command.Execute(CommandParameter);
        }

        #region IDisposable Members
        bool disposed = false;
        /// <summary>
        /// Unregisters the EventHandler from the Event
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                if (Event != null)
                {
                    Event.RemoveEventHandler(Owner, EventHandler);
                }
                disposed = true;
            }
        }

        #endregion
    }
}
