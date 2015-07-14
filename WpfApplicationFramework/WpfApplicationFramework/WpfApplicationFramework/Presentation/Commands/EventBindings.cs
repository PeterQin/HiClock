using System.Windows;

namespace System.Waf.Presentation.Commands
{
    /// <summary>
    /// Bind any event to a command.
    /// </summary>
    ///The event binding technology is copy from apex.
    ///http://apex.codeplex.com/
    ///
    public static class EventBindings
    {
        /// <summary>
        /// The Event Bindings Property.
        /// </summary>
        private static readonly DependencyProperty EventBindingsProperty =
          DependencyProperty.RegisterAttached("EventBindings", typeof(EventBindingCollection), typeof(EventBindings),
          new PropertyMetadata(null, new PropertyChangedCallback(OnEventBindingsChanged)));

        /// <summary>
        /// Gets the event bindings.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static EventBindingCollection GetEventBindings(DependencyObject o)
        {
            return (EventBindingCollection)o.GetValue(EventBindingsProperty);
        }

        /// <summary>
        /// Sets the event bindings.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="value">The value.</param>
        public static void SetEventBindings(DependencyObject o, EventBindingCollection value)
        {
            o.SetValue(EventBindingsProperty, value);
        }

        /// <summary>
        /// Called when event bindings changed.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnEventBindingsChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Cast the data.
            EventBindingCollection oldEventBindings = args.OldValue as EventBindingCollection;
            EventBindingCollection newEventBindings = args.NewValue as EventBindingCollection;

            //  If we have new set of event bindings, bind each one.
            if (newEventBindings != null)
            {
                foreach (EventBinding binding in newEventBindings)
                {
                    binding.Bind(o);
                }
            }
        }
    }
}
