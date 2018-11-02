using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace I_have_a_plan.Views
{
    public class CustomCell : ViewCell
    {
        StackLayout cell;
        View headerView;
        View mainView;
        Label textLabel;
        Label titleLabel;
        ProgressBar progress;
        Button show;
        Button close;

        public CustomCell()
        {
            titleLabel = new Label { FontSize = 18 };
            titleLabel.Text = "PopUp Menu";
            textLabel = new Label { FontSize = 18 };
            textLabel.Text = "Text";
            progress = new ProgressBar
            {
                Progress = .2,
            };
            show = new Button();
            show.Text = "Open";
            close = new Button();
            close.Text = "Close";

            cell = new StackLayout();
            StackLayout mainLayout = new StackLayout();
            mainLayout.Children.Add(textLabel);
            mainView = mainLayout;
            
            StackLayout cellView = new StackLayout();
            cellView.Orientation = StackOrientation.Horizontal;

            cellView.Children.Add(titleLabel);
            //cellView.Children.Add(progress);
            cellView.Children.Add(close);
            cellView.Children.Add(show);
            headerView = cellView;

            cell.Children.Add(headerView);

            View = cell;
            show.Clicked += Show_Clicked;
            close.Clicked += Close_Clicked;
        }

        public void Close_Clicked(object sender, EventArgs e)
        {
        
           cell.Children.Remove(MainView);
        }

        private void Show_Clicked(object sender, EventArgs e)
        {
           
            cell.Children.Add(MainView);
            //this.OnPropertyChanged(MainView);
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomCell), "");


        public static readonly BindableProperty childViewProperty =
           BindableProperty.Create("MainView", typeof(StackLayout), typeof(CustomCell), null);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public StackLayout MainView
        {
            get { return (StackLayout)GetValue(childViewProperty); }
            set { SetValue(childViewProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                titleLabel.Text = Title;
                mainView = MainView;
            }
        }
    }
}
