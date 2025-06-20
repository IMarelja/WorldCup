﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace WorldCup.Utilities
{
    public class FormAutomization
    {
        private FormAutomization() { }

        public static RadioButton GetSelectedRadioButton(GroupBox groupBox)
        {
            foreach (RadioButton radioButton in groupBox.Controls)
            {
                if (radioButton.Checked)
                    return radioButton;
            }
            throw new Exception("GroupBox is unselected or it is null");
        }

        
        public static void CreateRadioButtonsFromSettingsOptionEnum<T>(GroupBox groupBox) where T : Enum
        {

            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.LoadGenderTagSetting().ToString());

            ResourceManager rm = new ResourceManager("WorldCup.Textures.Languages.Lang", typeof(Program).Assembly);

            groupBox.Controls.Clear();

            
            int xPos = 20;
            int yPos = 30; 
            int yStart = 20;
            int maxButtonsPerColumn = 3;
            int buttonCount = 0;
            int buttonWidth = 100;
            int buttonVerticalSpacing = 30;
            int buttonHorizontalSpacing = 20;
            bool isFirst = true;

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                RadioButton rb = new RadioButton();

                // Set Name from enum value in lowercase (e.g., "men")
                rb.Name = value.ToString().ToLower();

                // Get localized text from resource using the name
                rb.Text = rm.GetString(rb.Name) ?? value.ToString();

                // Store the enum value in Tag for later use
                rb.Tag = value;

                rb.Location = new Point(xPos, yPos);
                rb.AutoSize = true;
                rb.Checked = isFirst;

                groupBox.Controls.Add(rb);

                buttonCount++;
                if (buttonCount >= maxButtonsPerColumn)
                {
                    buttonCount = 0;
                    yPos = yStart;
                    xPos += buttonWidth + buttonHorizontalSpacing;
                }
                else
                {
                    yPos += buttonVerticalSpacing;
                }

                isFirst = false;
            }
            /*
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                RadioButton rb = new RadioButton();
                rb.Text = GetEnumDescription(value) ?? value.ToString();
                rb.Location = new Point(xPos, yPos);
                rb.AutoSize = true;
                rb.Checked = isFirst;

                groupBox.Controls.Add(rb);

                buttonCount++;
                if (buttonCount >= maxButtonsPerColumn)
                {
                    buttonCount = 0;
                    yPos = yStart;
                    xPos += buttonWidth + buttonHorizontalSpacing;
                }
                else
                {
                    yPos += buttonVerticalSpacing;
                }

                isFirst = false;
            }*/
        }

        public static void SetDefaultRadioButtonForGroupBox(GroupBox groupBox, String LoadedSettingFromTag)
        {

            foreach (RadioButton rb in groupBox.Controls.OfType<RadioButton>())
            {

                if (rb.Tag.ToString() == LoadedSettingFromTag)
                {
                    rb.Checked = true;
                    break;
                }
            }
        }

        public static void MoveUserControlBetweenFlowLayoutPanel(Control userControl, FlowLayoutPanel sender, FlowLayoutPanel receiver)
        {
            if (userControl == null || sender == null || receiver == null) return;

            if (sender.Controls.Contains(userControl))
            {
                sender.Controls.Remove(userControl);
                receiver.Controls.Add(userControl);
            }
        }


        public static void CreateRadioButtonsFromSettingsOptionLanguageEnum(GroupBox groupBox)
        {


            groupBox.Controls.Clear();


            int xPos = 20;
            int yPos = 30;
            int yStart = 20;
            int maxButtonsPerColumn = 3;
            int buttonCount = 0;
            int buttonWidth = 100;
            int buttonVerticalSpacing = 30;
            int buttonHorizontalSpacing = 20;
            bool isFirst = true;

            foreach (Language value in Enum.GetValues(typeof(Language)))
            {
                RadioButton rb = new RadioButton();
                rb.Text = GetEnumDescription(value) ?? value.ToString();
                rb.Location = new Point(xPos, yPos);
                rb.AutoSize = true;
                rb.Checked = isFirst;

                groupBox.Controls.Add(rb);

                buttonCount++;
                if (buttonCount >= maxButtonsPerColumn)
                {
                    buttonCount = 0;
                    yPos = yStart;
                    xPos += buttonWidth + buttonHorizontalSpacing;
                }
                else
                {
                    yPos += buttonVerticalSpacing;
                }

                isFirst = false;
            }
        }

        public static void SetDefaultRadioButtonForLanguageGroupBox(GroupBox groupBox, String LoadedSetting)
        {

            foreach (RadioButton rb in groupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Text == LoadedSetting)
                {
                    rb.Checked = true;
                    break;
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



        public static void ApplyLanguage(Form form, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCup.Textures.Languages.Lang", typeof(Program).Assembly);

            // Apply resources to the form itself (the form might have a name/title too)
            string formText = rm.GetString(form.Name);
            if (!string.IsNullOrEmpty(formText))
            {
                form.Text = formText;
            }

            ApplyResourcesToControls(form, rm);
        }

        public static void ApplyLanguage(UserControl UC, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCup.Textures.Languages.Lang", typeof(Program).Assembly);

            // Apply resources to the form itself (the form might have a name/title too)
            string formText = rm.GetString(UC.Name);
            if (!string.IsNullOrEmpty(formText))
            {
                UC.Text = formText;
            }

            ApplyResourcesToControls(UC, rm);
        }

        public static void ApplyLanguage(ContextMenuStrip CMS, Language cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode.ToString());
            ResourceManager rm = new ResourceManager("WorldCup.Textures.Languages.Lang", typeof(Program).Assembly);

            ApplyResourcesToMenuItems(CMS.Items, rm);
        }

        private static void ApplyResourcesToControls(Control parent, ResourceManager rm)
        {
            foreach (Control ctrl in parent.Controls)
            {
                string localizedText = rm.GetString(ctrl.Name);
                if (!string.IsNullOrEmpty(localizedText))
                {
                    ctrl.Text = localizedText;
                }

                // If the control contains child controls (like Panels, GroupBoxes, Tabs)
                if (ctrl.HasChildren)
                {
                    ApplyResourcesToControls(ctrl, rm);
                }
            }
        }

        private static void ApplyResourcesToMenuItems(ToolStripItemCollection items, ResourceManager rm)
        {
            foreach (ToolStripItem item in items)
            {
                string localizedText = rm.GetString(item.Name);
                if (!string.IsNullOrEmpty(localizedText))
                {
                    item.Text = localizedText;
                }

                // Handle nested drop-down menus recursively
                if (item is ToolStripMenuItem menuItem && menuItem.HasDropDownItems)
                {
                    ApplyResourcesToMenuItems(menuItem.DropDownItems, rm);
                }
            }
        }

        public static void LoadImageIntoPictureBox(string imagePath, PictureBox pictureBox)
        {
            try
            {
                // Load the original image
                using (Image originalImage = Image.FromFile(imagePath))
                {
                    // Calculate the scale factor to fit the image within the PictureBox
                    float scaleWidth = (float)pictureBox.Width / originalImage.Width;
                    float scaleHeight = (float)pictureBox.Height / originalImage.Height;
                    float scale = Math.Min(scaleWidth, scaleHeight);

                    // Calculate new dimensions
                    int newWidth = (int)(originalImage.Width * scale);
                    int newHeight = (int)(originalImage.Height * scale);

                    // Create a new bitmap with the new dimensions
                    Bitmap resizedImage = new Bitmap(newWidth, newHeight);

                    // Create a graphics object to draw the resized image
                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                    {
                        // Set the interpolation mode for better quality
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                        // Draw the resized image
                        graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                    }

                    // Assign the resized image to the PictureBox
                    pictureBox.Image = resizedImage;

                    // Optional: Set the SizeMode if needed
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }
}
