using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Cyprom.TableTennisTournaments.View.Extensions
{

    public static class DependencyObjectExtensions
    {
        public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            if (parent == null)
            {
                return null;
            }
            var cast = parent as T;
            if (cast != null)
            {
                return cast;
            }
            return parent.FindParent<T>();
        }
    }
}
