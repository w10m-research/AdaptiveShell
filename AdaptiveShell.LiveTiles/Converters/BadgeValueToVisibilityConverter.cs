using AdaptiveShell.LiveTiles.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveShell.LiveTiles.Converters {
    public sealed class BadgeValueToVisibilityConverter : IValueConverter {
        public Object Convert(Object value, Type targetType, Object parameter, String language) {
            var badgeValue = value as BadgeValue;
            if (badgeValue == null)
                return Visibility.Collapsed;

            if (badgeValue.HasBadge())
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, String language) {
            throw new NotImplementedException();
        }
    }
}
