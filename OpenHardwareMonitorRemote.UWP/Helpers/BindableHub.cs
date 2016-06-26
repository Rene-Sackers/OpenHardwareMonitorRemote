using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cimbalino.Toolkit.Extensions;
using Syncfusion.Data.Extensions;

namespace OpenHardwareMonitorRemote.UWP.Helpers
{
    public class BindableHub : Hub
    {
        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
            "ItemTemplate", typeof (DataTemplate), typeof (BindableHub), new PropertyMetadata(default(DataTemplate), ItemTemplateChanged));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate) GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty ItemHeaderTemplateProperty = DependencyProperty.Register(
            "ItemHeaderTemplate", typeof (DataTemplate), typeof (BindableHub), new PropertyMetadata(default(DataTemplate), ItemHeaderTemplateChanged));

        public DataTemplate ItemHeaderTemplate
        {
            get { return (DataTemplate) GetValue(ItemHeaderTemplateProperty); }
            set { SetValue(ItemHeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof (IList), typeof (BindableHub), new PropertyMetadata(default(IList), ItemsSourceChanged));

        public IList ItemsSource
        {
            get { return (IList) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void ItemTemplateChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var hub = dependencyObject as Hub;
            if (hub == null) return;

            var dataTemplate = dependencyPropertyChangedEventArgs.NewValue as DataTemplate;
            if (dataTemplate == null) return;

            hub.Sections.ForEach(section => section.ContentTemplate = dataTemplate);
        }

        private static void ItemHeaderTemplateChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var hub = dependencyObject as Hub;
            if (hub == null) return;

            var dataTemplate = dependencyPropertyChangedEventArgs.NewValue as DataTemplate;
            if (dataTemplate == null) return;

            hub.Sections.ForEach(section => section.HeaderTemplate = dataTemplate);
        }

        private static void ItemsSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var hub = dependencyObject as BindableHub;
            if (hub == null) return;

            var items = dependencyPropertyChangedEventArgs.NewValue as IList<object>;
            if (items == null) return;

            hub.Sections.Clear();

            hub.Sections.AddRange(items.Select(item => new HubSection
            {
                DataContext = item,
                Header = item,
                ContentTemplate = hub.ItemTemplate
            }));
        }
    }
}
