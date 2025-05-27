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
            if (groupBox?.Content is Panel panel)
            {
                foreach (var child in panel.Children)
                {
                    if (child is RadioButton radioButton && radioButton.IsChecked == true)
                        return radioButton;
                }
            }

            throw new Exception("GroupBox is unselected or it is null");
        }



        //============================================================================
        // Warning: Grid might not be great, replace if something obviously goes wrong
        //============================================================================
        public static void CreateRadioButtonsFromSettingsOptionEnum<T>(GroupBox groupBox) where T : Enum
        {
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(WorldCupWPF.App).Assembly);

            // Create a Grid to layout the RadioButtons
            var grid = new Grid();
            groupBox.Content = grid;

            int maxButtonsPerColumn = 3;
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
                if (buttonCount >= maxButtonsPerColumn)
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

            int maxButtonsPerColumn = 3;
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
                if (buttonCount >= maxButtonsPerColumn)
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



        //============================================================================
        // Warning: ⚠️ If using nested panels: If your layout is more complex (e.g. multiple nested StackPanels or a Grid), you’ll need a recursive version. Just let me know if that’s your case, and I’ll provide it.
        //============================================================================
        public static void SetDefaultRadioButtonForGroupBox(System.Windows.Controls.GroupBox groupBox, string loadedSettingFromTag)
        {
            if (groupBox.Content is Panel panel)
            {
                foreach (var rb in panel.Children.OfType<RadioButton>())
                {
                    if (rb.Tag?.ToString() == loadedSettingFromTag)
                    {
                        rb.IsChecked = true;
                        break;
                    }
                }
            }
        }

        public static void CreateRadioButtonsFromSettingsOptionLanguageEnum(System.Windows.Controls.GroupBox groupBox)
        {

            var grid = new Grid();
            groupBox.Content = grid;

            int maxButtonsPerColumn = 3;
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
                if (buttonCount >= maxButtonsPerColumn)
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

        public static void SetDefaultRadioButtonForLanguageGroupBox(System.Windows.Controls.GroupBox groupBox, string loadedSetting)
        {
            if (groupBox.Content is Panel panel)
            {
                foreach (var rb in panel.Children.OfType<RadioButton>())
                {
                    if (rb.Content?.ToString() == loadedSetting)
                    {
                        rb.IsChecked = true;
                        break;
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


        public static void ApplyLanguage(Window window, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(App).Assembly);

            string windowTitle = rm.GetString(window.Name);
            if (!string.IsNullOrEmpty(windowTitle))
            {
                window.Title = windowTitle;
            }

            ApplyResourcesToFrameworkElements(window, rm);
        }


        public static void ApplyLanguage(UserControl UC, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(App).Assembly);

            // Apply resources to the form itself (the form might have a name/title too)
            string formText = rm.GetString(UC.Name);
            

            ApplyResourcesToControls(UC, rm);
        }

        public static void ApplyLanguage(ContextMenu menu, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCupWPF.Textures.Languages.Lang", typeof(App).Assembly);

            ApplyResourcesToMenuItems(menu.Items, rm);
        }

        private static void ApplyResourcesToFrameworkElements(DependencyObject parent, ResourceManager rm)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is FrameworkElement fe && !string.IsNullOrEmpty(fe.Name))
                {
                    string localizedText = rm.GetString(fe.Name);
                    if (!string.IsNullOrEmpty(localizedText))
                    {
                        if (fe is ContentControl cc)
                            cc.Content = localizedText;
                        else if (fe is HeaderedContentControl hcc)
                            hcc.Header = localizedText;
                        else if (fe is TextBlock tb)
                            tb.Text = localizedText;
                    }
                }

                ApplyResourcesToFrameworkElements(child, rm);
            }
        }



        private static void ApplyResourcesToControls(UserControl parent, ResourceManager rm)
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

        private static void ApplyResourcesToMenuItems(ItemCollection items, ResourceManager rm)
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
                        ApplyResourcesToMenuItems(menuItem.Items, rm);
                    }
                }
            }
        }


        public static void LoadImageIntoImageControl(string imagePath, System.Windows.Controls.Image imageControl)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                bitmap.DecodePixelWidth = (int)imageControl.Width;
                bitmap.DecodePixelHeight = (int)imageControl.Height;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();

                imageControl.Source = bitmap;

                imageControl.Stretch = Stretch.Uniform;
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
