using System.Windows;
using System.Windows.Input;

namespace System.Waf.Presentation.Commands
{
    /// <summary>
    /// A multiple event command binding.
    /// This inherits from freezable so that it gets inheritance context for DataBinding to work.
    /// </summary>
    public class EventBinding : Freezable
    {
        #region Field

        #region Property
        private EventActuator FActuator;
        /// <summary>
        /// Stores the EventActuator
        /// </summary>
        internal EventActuator Actuator
        {
            get
            {
                if (FActuator == null)
                    FActuator = new EventActuator();
                return FActuator;
            }
        }

        #region EventName
        private static readonly DependencyProperty EventNameProperty =
          DependencyProperty.Register("EventName", typeof(string), typeof(EventBinding),
          new PropertyMetadata((string)String.Empty));

        /// <summary>
        /// Event name to fire command
        /// </summary>
        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

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
        #endregion

        #region Command
        /// <summary>
        /// Command to fire
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
          DependencyProperty.Register("Command", typeof(ICommand), typeof(EventBinding),
          new PropertyMetadata((ICommand)null));

        /// <summary>
        /// Command to fire
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

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
        #endregion

        #region CommandParameter
        /// <summary>
        /// Command para
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
          DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventBinding),
          new PropertyMetadata((object)null));

        /// <summary>
        /// Command para
        /// </summary>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

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
        #endregion

        #endregion Property

        #endregion Field

        #region Constructor & Destroyer
        /// <summary>
        /// Create Event binding
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore()
        {
            return new EventBinding();
        }
        #endregion Constructor & Destroyer

        #region Public Section
        /// <summary>
        /// Bind the command to the event owner.
        /// </summary>
        public void Bind(object aOwner)
        {
            Actuator.Command = this.Command;
            Actuator.CommandParameter = this.CommandParameter;
            Actuator.BindEvent(aOwner, this.EventName);
        }
        #endregion Public Section
    }
}
