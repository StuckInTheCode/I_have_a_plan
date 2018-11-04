using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace I_have_a_plan.Views
{
    public class ProgressIndicator : Grid
    {
        public ProgressIndicator()
        {
            Color = Color.Crimson;
            SecondColor = Color.White;
        }

        public static readonly BindableProperty SecondColorProperty =
            BindableProperty.Create(nameof(SecondColor), typeof(Color), typeof(ProgressIndicator), default(Color));

        public Color SecondColor
        {
            get => (Color)GetValue(SecondColorProperty);
            set => SetValue(SecondColorProperty, value);
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(ProgressIndicator), default(Color));

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty MaxValueProperty =
            BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(ProgressIndicator), 0);

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(int), typeof(ProgressIndicator), 0);

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Color))
            {
                DrawProgress(Value, MaxValue);
            }

            if (propertyName == nameof(SecondColor))
            {
                DrawProgress(Value, MaxValue);
            }

            if (propertyName == nameof(MaxValue) || propertyName == nameof(Value))
            {
                if (CheckValueOverflawMax())
                    DrawProgress(Value, MaxValue);
            }
        }

        private bool CheckValueOverflawMax()
        {
            if (Value <= MaxValue || MaxValue == 0)
                return true;

            return false;
        }

        private void DrawProgress(int value, int maxValue)
        {
            ColumnDefinitions.Clear();
            Children.Clear();

            for (int i = 0; i <= maxValue - 1; i++)
            {
                var view = new ContentView
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    BackgroundColor = value >= i + 1 ? Color : SecondColor
                };

                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


                Children.Add(view, i, 0);
            }
        }
    }
}
