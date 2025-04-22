using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void SetDefaultRadioButtonForGroupBox(GroupBox groupBox, String LoadedSetting)
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
    }
}
