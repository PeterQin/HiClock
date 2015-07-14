using System.Windows;
using System.Windows.Input;

namespace System.Waf.Presentation.Commands
{
    /// <summary>
    /// A single event command binding.
    /// </summary>
    public class SingleEventBinding
    {
        #region Field

        #region Property

        #region Actuator

        /// <summary>
        /// Behavior Attached Dependency Property
        /// </summary>
        private static readonly DependencyProperty ActuatorProperty =
            DependencyProperty.RegisterAttached("Actuator", typeof(EventActuator), typeof(SingleEventBinding),
                new FrameworkPropertyMetadata((EventActuator)null));

        #endregion
        
        #region EventName
        /// <summary>
        /// Event name
        /// </summary>
        public static readonly DependencyProperty EventNameProperty =
          DependencyProperty.RegisterAttached("EventName", typeof(string), typeof(SingleEventBinding),
          new PropertyMetadata((string)String.Empty,
                    new PropertyChangedCallback(OnEventChanged)));

        /// <summary>
        /// Gets the EventName property.
        /// </summary>
        public static string GetEventName(DependencyObject d)
        {
            return (string)d.GetValue(EventNameProperty);
        }

        /// <summary>
        /// Sets the EventName property.
        /// </summary>
        public static void SetEventName(DependencyObject d, string value)
        {
            d.SetValue(EventNameProperty, value);
        }

        /// <summary>
        /// Handles changes to the Event property.
        /// </summary>
        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EventActuator actuator = FetchOrCreateActuator(d);
            
            //bind the new event to the command
            actuator.BindEvent(d, e.NewValue + "");
        }
        #endregion

        #region Command
        /// <summary>
        /// Command to fire
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
          DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(SingleEventBinding),
          new PropertyMetadata((ICommand)null,
                    new PropertyChangedCallback(OnCommandChanged)));

        /// <summary>
        /// Gets the Command property.  
        /// </summary>
        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        /// <summary>
        /// Sets the Command property. 
        /// </summary>
        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Handles changes to the Command property.
        /// </summary>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EventActuator actuator = FetchOrCreateActuator(d);
            actuator.Command = (ICommand)e.NewValue;
        }
        #endregion

        #region CommandParameter
        /// <summary>
        /// Command para
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
          DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(SingleEventBinding),
          new PropertyMetadata((object)null,
                    new PropertyChangedCallback(OnCommandParameterChanged)));

        /// <summary>
        /// Gets the CommandParameter property.  
        /// </summary>
        public static object GetCommandParameter(DependencyObject d)
        {
            return (object)d.GetValue(CommandParameterProperty);
        }

        /// <summary>
        /// Sets the CommandParameter property. 
        /// </summary>
        public static void SetCommandParameter(DependencyObject d, object value)
        {
            d.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Handles changes to the CommandParameter property.
        /// </summary>
        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EventActuator actuator = FetchOrCreateActuator(d);
            actuator.CommandParameter = e.NewValue;
        }
        #endregion

        #endregion Property

        #endregion Field

        #region Helpers
        /// <summary>
        /// tries to get a EventActuator from the element. Creates a new instance if there is not one attached
        /// </summary>
        private static EventActuator FetchOrCreateActuator(DependencyObject d)
        {
            EventActuator actuator = (EventActuator)d.GetValue(ActuatorProperty);
            if (actuator == null)
            {
                actuator = new EventActuator();
                d.SetValue(ActuatorProperty, actuator);
            }
            return actuator;
        }
        #endregion
    }
}
