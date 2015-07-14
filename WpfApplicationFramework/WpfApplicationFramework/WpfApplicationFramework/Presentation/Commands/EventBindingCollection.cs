using System.Windows;

namespace System.Waf.Presentation.Commands
{
    /// <summary>
    /// Collection to store the list of EventBindings. This is done so that you can intiniate it from XAML
    /// This inherits from freezable so that it gets inheritance context for DataBinding to work
    /// </summary>
    public class EventBindingCollection : FreezableCollection<EventBinding>
    {
    }
}
