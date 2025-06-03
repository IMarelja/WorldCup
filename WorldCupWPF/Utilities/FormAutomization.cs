using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WCRepo.Model;
using WorldCupWPF;

namespace WorldCupWPF.Utilities
{
    public class FormAutomization
    {
        private FormAutomization() { }

        public static RadioButton GetSelectedRadioButton(GroupBox groupBox)
        {
            if (groupBox?.Content is Grid grid)
            {
                foreach (var child in grid.Children)
                {
                    if (child is StackPanel panel)
                    {
                        foreach (var element in panel.Children)
                        {
                            if (element is RadioButton radioButton && radioButton.IsChecked == true)
                                return radioButton;
                        }
                    }
                }
            }

            throw new Exception("GroupBox is unselected or it is null");
        }




        public static void CreateRadioButtonsFromSettingsOptionEnum<T>(GroupBox groupBox) where T : Enum
        {
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(WorldCupWPF.App).Assembly);

            // Create a Grid to layout the RadioButtons
            var grid = new Grid();
            groupBox.Content = grid;

            int maxButtonsPerColumn = 4;
            int buttonCount = 0;
            int columnCount = 0;

            // Dynamically add first column
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Track how many buttons per column (vertical stacking)
            var currentStack = new StackPanel { Margin = new Thickness(10) };
            grid.Children.Add(currentStack);
            Grid.SetColumn(currentStack, columnCount);

            bool isFirst = true;

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                var rb = new RadioButton
                {
                    Name = value.ToString().ToLower(),
                    Content = rm.GetString(value.ToString().ToLower()) ?? value.ToString(),
                    Tag = value,
                    IsChecked = isFirst,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                currentStack.Children.Add(rb);

                buttonCount++;
                if (buttonCount > maxButtonsPerColumn)
                {
                    buttonCount = 0;
                    columnCount++;

                    // Add new column and new StackPanel
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    currentStack = new StackPanel { Margin = new Thickness(10) };
                    grid.Children.Add(currentStack);
                    Grid.SetColumn(currentStack, columnCount);
                }

                isFirst = false;
            }
        }

        public static void CreateRadioButtonsFromSettingsOptionDescriptionEnum<T>(GroupBox groupBox) where T : Enum
        {
            // Create a Grid to layout the RadioButtons
            var grid = new Grid();
            groupBox.Content = grid;

            int maxButtonsPerColumn = 4;
            int buttonCount = 0;
            int columnCount = 0;

            // Dynamically add first column
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Track how many buttons per column (vertical stacking)
            var currentStack = new StackPanel { Margin = new Thickness(10) };
            grid.Children.Add(currentStack);
            Grid.SetColumn(currentStack, columnCount);

            bool isFirst = true;

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                var rb = new RadioButton
                {
                    Name = value.ToString().ToLower(),
                    Content = GetEnumDescription(value) ?? value.ToString(),
                    Tag = value,
                    IsChecked = isFirst,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                currentStack.Children.Add(rb);

                buttonCount++;
                if (buttonCount > maxButtonsPerColumn)
                {
                    buttonCount = 0;
                    columnCount++;

                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    currentStack = new StackPanel { Margin = new Thickness(10) };
                    grid.Children.Add(currentStack);
                    Grid.SetColumn(currentStack, columnCount);
                }

                isFirst = false;
            }
        }


        public static void CreateRadioButtonsFromSettingsOptionLanguageEnum(System.Windows.Controls.GroupBox groupBox)
        {

            var grid = new Grid();
            groupBox.Content = grid;

            int maxButtonsPerColumn = 4;
            int buttonCount = 0;
            int columnCount = 0;


            grid.ColumnDefinitions.Add(new ColumnDefinition());

            var currentStack = new StackPanel { Margin = new Thickness(10) };
            grid.Children.Add(currentStack);
            Grid.SetColumn(currentStack, columnCount);

            bool isFirst = true;

            foreach (Language value in Enum.GetValues(typeof(Language)))
            {
                var rb = new RadioButton
                {
                    Content = GetEnumDescription(value) ?? value.ToString(),
                    IsChecked = isFirst,
                    Margin = new Thickness(0, 5, 0, 5),
                    Tag = value
                };

                currentStack.Children.Add(rb);

                buttonCount++;
                if (buttonCount > maxButtonsPerColumn)
                {
                    buttonCount = 0;
                    columnCount++;

                    grid.ColumnDefinitions.Add(new ColumnDefinition());

                    currentStack = new StackPanel { Margin = new Thickness(10) };
                    grid.Children.Add(currentStack);
                    Grid.SetColumn(currentStack, columnCount);
                }

                isFirst = false;
            }
        }

        public static void SetDefaultRadioButtonForGroupBox(GroupBox groupBox, string loadedSettingFromTag)
        {
            void SetCheckedRecursive(DependencyObject parent)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);

                    if (child is RadioButton rb && rb.Tag?.ToString() == loadedSettingFromTag)
                    {
                        rb.IsChecked = true;
                        return; // Stop as soon as we find and set the correct RadioButton
                    }

                    SetCheckedRecursive(child); // Recursively check all children
                }
            }

            if (groupBox?.Content is DependencyObject root)
            {
                SetCheckedRecursive(root);
            }
        }


        public static void SetDefaultRadioButtonForLanguageGroupBox(System.Windows.Controls.GroupBox groupBox, string loadedSetting)
        {
            void SetCheckedRecursive(DependencyObject parent)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);

                    if (child is RadioButton rb && rb.Content?.ToString() == loadedSetting)
                    {
                        rb.IsChecked = true;
                        return;
                    }

                    SetCheckedRecursive(child); // Recursively search children
                }
            }

            if (groupBox?.Content is DependencyObject root)
            {
                SetCheckedRecursive(root);
            }
        }


        public static void SetDefaultRadioButtonForDescriptionEnumGroupBox(GroupBox groupBox, string loadedDescription)
        {
            void SetCheckedRecursive(DependencyObject parent)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);

                    if (child is RadioButton rb && rb.Content?.ToString() == loadedDescription)
                    {
                        rb.IsChecked = true;
                        return;
                    }

                    SetCheckedRecursive(child);
                }
            }

            if (groupBox?.Content is DependencyObject root)
            {
                SetCheckedRecursive(root);
            }
        }

        public static void SetWindowResolutionBasedOnResolutionSettings(Window window)
        {
            Resolution resolution = Settings.LoadResolutionTagSetting();

            switch (resolution)
            {
                case Resolution.Resolution800x600:
                    window.Width = 800;
                    window.Height = 600;
                    window.WindowState = WindowState.Normal;
                    break;
                case Resolution.Resolution1366x768:
                    window.Width = 1366;
                    window.Height = 768;
                    window.WindowState = WindowState.Normal;
                    break;
                case Resolution.Resolution1600x900:
                    window.Width = 1600;
                    window.Height = 900;
                    window.WindowState = WindowState.Normal;
                    break;
                case Resolution.ResolutionFullscreen:
                    window.WindowState = WindowState.Maximized;
                    window.WindowStyle = WindowStyle.None;
                    break;
                default:
                    MessageBox.Show("Failed to load Resolution.\nWrongly stored in settings.xml file or Wrongly extracted");
                    window.Width = 800;
                    window.Height = 600;
                    window.WindowState = WindowState.Normal;
                    break;
            }
        }


        public static void ApplyLanguage(Window window, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(App).Assembly);

            string windowTitle = rm.GetString(window.Name);
            if (!string.IsNullOrEmpty(windowTitle))
            {
                window.Title = windowTitle;
            }

            ApplyLanguage(window, rm);
        }


        public static void ApplyLanguage(UserControl UC, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(App).Assembly);

            // Apply resources to the form itself (the form might have a name/title too)
            string formText = rm.GetString(UC.Name);


            ApplyLanguage(UC as DependencyObject, rm);
        }

        public static void ApplyLanguage(ContextMenu menu, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(App).Assembly);

            ApplyLanguage(menu.Items, rm);
        }

        private static void ApplyLanguage(DependencyObject parent, ResourceManager rm)
        {
            if (parent == null) return;

            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is FrameworkElement fe && !string.IsNullOrEmpty(fe.Name))
                {
                    string localizedText = rm.GetString(fe.Name);
                    if (!string.IsNullOrEmpty(localizedText))
                    {
                        if (fe is HeaderedContentControl hcc)
                            hcc.Header = localizedText;

                        if (fe is ContentControl cc)
                            cc.Content = localizedText;

                        if (fe is TextBlock tb)
                            tb.Text = localizedText;

                        var textProp = fe.GetType().GetProperty("Text");
                        if (textProp != null && textProp.CanWrite)
                            textProp.SetValue(fe, localizedText);
                    }
                }

                ApplyLanguage(child, rm);
            }
        }




        private static void ApplyLanguage(UserControl parent, ResourceManager rm)
        {
            foreach (var child in LogicalTreeHelper.GetChildren(parent))
            {
                if (child is FrameworkElement fe && !string.IsNullOrEmpty(fe.Name))
                {
                    string localizedText = rm.GetString(fe.Name);
                    if (!string.IsNullOrEmpty(localizedText))
                    {
                        switch (fe)
                        {
                            case ContentControl cc:
                                cc.Content = localizedText;
                                break;
                            case TextBlock tb:
                                tb.Text = localizedText;
                                break;
                            case TextBox textBox:
                                textBox.Text = localizedText;
                                break;
                                // Add more UI types if needed
                        }
                    }
                }
            }
        }

        private static void ApplyLanguage(ItemCollection items, ResourceManager rm)
        {
            foreach (var obj in items)
            {
                if (obj is MenuItem menuItem && !string.IsNullOrEmpty(menuItem.Name))
                {
                    string localizedText = rm.GetString(menuItem.Name);
                    if (!string.IsNullOrEmpty(localizedText))
                    {
                        menuItem.Header = localizedText;
                    }

                    if (menuItem.HasItems)
                    {
                        ApplyLanguage(menuItem.Items, rm);
                    }
                }
            }
        }


        private static string GetEnumDescription<T>(T value) where T : Enum
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            return null;
        }


        public static void LoadImageIntoImageControl(string imagePath, System.Windows.Controls.Image imageControl)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                if (imageControl.Width > 0)
                    bitmap.DecodePixelWidth = (int)imageControl.Width;
                if (imageControl.Height > 0)
                    bitmap.DecodePixelHeight = (int)imageControl.Height;

                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();

                imageControl.Source = bitmap;

                imageControl.Stretch = Stretch.Fill;
                imageControl.HorizontalAlignment = HorizontalAlignment.Center;
                imageControl.VerticalAlignment = VerticalAlignment.Center;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

    }
}
