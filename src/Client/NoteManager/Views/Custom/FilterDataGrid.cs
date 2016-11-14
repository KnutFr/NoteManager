using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace NoteManager.Views.Custom
{
    public class FilteringDataGrid : Microsoft.Windows.Controls.DataGrid
    {
        private Dictionary<string, string> columnFilters;

        private Dictionary<string, PropertyInfo> propertyCache;

        public static DependencyProperty IsFilteringCaseSensitiveProperty =
             DependencyProperty.Register("IsFilteringCaseSensitive", typeof(bool), typeof(FilteringDataGrid), new PropertyMetadata(true));

        public bool IsFilteringCaseSensitive
        {
            get { return (bool)(GetValue(IsFilteringCaseSensitiveProperty)); }
            set { SetValue(IsFilteringCaseSensitiveProperty, value); }
        }

        public FilteringDataGrid()
        {
            columnFilters = new Dictionary<string, string>();
            propertyCache = new Dictionary<string, PropertyInfo>();

            AddHandler(TextBox.TextChangedEvent, new TextChangedEventHandler(OnTextChanged), true);
            DataContextChanged += new DependencyPropertyChangedEventHandler(FilteringDataGrid_DataContextChanged);
        }

        private void FilteringDataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            propertyCache.Clear();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox filterTextBox = e.OriginalSource as TextBox;

            DataGridColumnHeader header = TryFindParent<DataGridColumnHeader>(filterTextBox);
            if (header != null)
            {
                UpdateFilter(filterTextBox, header);
                ApplyFilters();
            }
        }

        private void UpdateFilter(TextBox textBox, DataGridColumnHeader header)
        {
            string columnBinding = header.DataContext != null ? header.DataContext.ToString() : "";

            if (header.Column is Microsoft.Windows.Controls.DataGridTextColumn)
                columnBinding = ((Binding)((Microsoft.Windows.Controls.DataGridTextColumn)header.Column).Binding).Path.Path;

            if (!String.IsNullOrEmpty(columnBinding))
                columnFilters[columnBinding] = textBox.Text;
        }

        private void ApplyFilters()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ItemsSource);
            if (view != null)
            {
                view.Filter = delegate(object item)
                {
                    bool show = true;

                    foreach (KeyValuePair<string, string> filter in columnFilters)
                    {
                        object property = GetPropertyValue(item, filter.Key);
                        if (property != null)
                        {
                            bool containsFilter = false;
                            if (IsFilteringCaseSensitive)
                                containsFilter = property.ToString().Contains(filter.Value);
                            else
                                containsFilter = property.ToString().ToLower().Contains(filter.Value.ToLower());

                            if (!containsFilter)
                            {
                                show = false;
                                break;
                            }
                        }
                    }

                    return show;
                };
            }
        }

        private object GetPropertyValue(object item, string property)
        {
            object value = null;

            PropertyInfo pi = null;
            if (propertyCache.ContainsKey(property))
                pi = propertyCache[property];
            else
            {
                pi = item.GetType().GetProperty(property);
                propertyCache.Add(property, pi);
            }

            if (pi != null)
                value = pi.GetValue(item, null);

            return value;
        }

        public static T TryFindParent<T>(DependencyObject child)
          where T : DependencyObject
        {
            DependencyObject parentObject = GetParentObject(child);

            if (parentObject == null) 
                return null;

            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return TryFindParent<T>(parentObject);
            }
        }

        public static DependencyObject GetParentObject(DependencyObject child)
        {
            if (child == null) return null;
            ContentElement contentElement = child as ContentElement;

            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement);
                if (parent != null) return parent;

                FrameworkContentElement fce = contentElement as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }

            return VisualTreeHelper.GetParent(child);
        } 
    }
}
