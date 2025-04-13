using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace WorldCup
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
            // Clear existing controls
            groupBox.Controls.Clear();

            // Variables for positioning
            int xPos = 20;
            int yPos = 30; // Space for GroupBox title
            int yStart = 20;
            int maxButtonsPerColumn = 3;
            int buttonCount = 0;
            int buttonWidth = 100;
            int buttonVerticalSpacing = 30;
            int buttonHorizontalSpacing = 20;
            bool isFirst = true;

            // Add radio buttons
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                RadioButton rb = new RadioButton();
                rb.Text = value.ToString();
                rb.Location = new Point(xPos, yPos);
                rb.AutoSize = true;
                rb.Checked = isFirst; // First enum value is selected by default

                groupBox.Controls.Add(rb);

                // Update positioning
                buttonCount++;
                if (buttonCount >= maxButtonsPerColumn)
                {
                    // Move to next column
                    buttonCount = 0;
                    yPos = yStart;
                    xPos += buttonWidth + buttonHorizontalSpacing;
                }
                else
                {
                    // Move to next row in current column
                    yPos += buttonVerticalSpacing;
                }

                isFirst = false;
            }
        }

        public static void SetDefaultRadioButtonForGroupBox(GroupBox groupBox, SettingsOptions setting)
        {
            string settingsSelected = Settings.LoadSetting(setting);

            foreach (RadioButton rb in groupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Text == settingsSelected)
                {
                    rb.Checked = true;
                    break;
                }
            }
        }
    }
}
