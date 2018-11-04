using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace I_have_a_plan.Views
{
    public class CustomCell : ViewCell
    {
        StackLayout cell;
        StackLayout cellView;
        View headerView;
        View mainView;
        Label textLabel;
        Label titleLabel;
        ProgressBar progress;
        Button show;
        bool showPressed;
        //Button close;

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
            showPressed = false;
            //close = new Button();
            //close.Text = "Close";

            cell = new StackLayout();
            cell.Orientation = StackOrientation.Vertical;

            StackLayout headerLayout = new StackLayout();
            headerLayout.Children.Add(titleLabel);
            headerView = headerLayout;

            cellView = new StackLayout();
            cellView.Orientation = StackOrientation.Horizontal;


            cellView.Children.Add(headerView);
            cellView.Children.Add(show);
            //headerView = cellView;

            cell.Children.Add(cellView);
            //cell.Children.Add(headerView);
            //cell.Children.Add(mainView);

            View = cell;
            show.Clicked += Show_Clicked;
            //close.Clicked += Close_Clicked;
        }

        public CustomCell(View headerView)
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
            showPressed = false;
            //close = new Button();
            //close.Text = "Close";

            cell = new StackLayout();
            cell.Orientation = StackOrientation.Vertical;

            StackLayout headerLayout = new StackLayout();
            headerLayout.Children.Add(titleLabel);
            headerView = headerLayout;

            cellView = new StackLayout();
            cellView.Orientation = StackOrientation.Horizontal;


            cellView.Children.Add(headerView);
            cellView.Children.Add(show);
            //headerView = cellView;

            cell.Children.Add(cellView);
            //cell.Children.Add(headerView);
            //cell.Children.Add(mainView);

            View = cell;
            show.Clicked += Show_Clicked;
            //close.Clicked += Close_Clicked;
        }


        public void Close_Clicked(object sender, EventArgs e)
        {
            
           cell.Children.Remove(MainView);
        }

        private void Show_Clicked(object sender, EventArgs e)
        {

            if (!showPressed)
            {
                cell.Children.Add(MainView);
                show.Text = "Close";
                showPressed = true;
            }
            else
            {
                cell.Children.Remove(MainView);
                show.Text = "Open";
                showPressed = false;
            }
            //this.OnPropertyChanged("MainView");
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomCell), "");


        public static readonly BindableProperty mainViewProperty =
           BindableProperty.Create("MainView", typeof(View), typeof(CustomCell), null);

        public static readonly BindableProperty headerViewProperty =
           BindableProperty.Create("HeaderView", typeof(View), typeof(CustomCell), null);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public View MainView
        {
            get { return (View)GetValue(mainViewProperty); }
            set { SetValue(mainViewProperty, value); }
        }

        public View HeaderView
        {
            get { return (View)GetValue(headerViewProperty); }
            set { SetValue(headerViewProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                titleLabel.Text = Title;
                //cell.Children.Remove(HeaderView);
                //cell.Children.Remove(MainView);
                cellView.Children.Remove(headerView);
                cellView.Children.Remove(show);
                mainView = MainView;
                headerView = HeaderView;
                cellView.Children.Add(headerView);
                cellView.Children.Add(show);
                //cellView.Children.Remove(show);
                //cellView.Children.Insert(0, HeaderView);
                //cellView.Children.Add(show);
                //cell.Children.Insert(0,cellView);
            }
        }
    }
}
