using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using Models;

namespace WorldCupWPF.Utilities
{
    //Settings values
    
    public enum Language
    {

        [Description("English")]
        en,

        [Description("Hrvatski")]
        hr
    }

    public enum Resolution
    {
        [Description("800x600")]
        Resolution800x600,
        [Description("1366x768")]
        Resolution1366x768,
        [Description("1600x900")]
        Resolution1600x900,
        [Description("Fullscreen")]
        ResolutionFullscreen
    }
    public class Settings
    {

        public static string settingsFilePath = Path.Combine(HomePath.Value(), @"Settings\settings.xml");

        public static string settingsPicturePath = Path.Combine(HomePath.Value(), @"Settings\Pictures");

        public static string settingsWindowsFormFilePath = Path.Combine(Path.Combine(Directory.GetParent(HomePath.Value()).FullName, @"WorldCup"), @"Settings\settings.xml");

        public static string settingsWindowsFormPicturePath = Path.Combine(Path.Combine(Directory.GetParent(HomePath.Value()).FullName, @"WorldCup"), @"Settings\Pictures");

        private Settings() { }
        
        public static void SaveGenderSetting(Gender group)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                XElement languageElement = doc.Root.Element("Gender");

                languageElement?.Remove();

                languageElement = new XElement("Gender", group.ToString());

                doc.Root.Add(languageElement);
                doc.Save(settingsFilePath);
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static void SaveGenderSetting(string group)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                Gender genderEnum = GetEnumValueFromDescription<Gender>(group);

                XDocument doc = XDocument.Load(settingsFilePath);
                XElement languageElement = doc.Root.Element("Gender");

                languageElement?.Remove();

                languageElement = new XElement("Gender", genderEnum.ToString());

                doc.Root.Add(languageElement);
                doc.Save(settingsFilePath);
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static Gender LoadGenderTagSetting()
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                var doc = XDocument.Load(settingsFilePath);
                var genderText = doc.Root.Element("Gender")?.Value;
                return Enum.TryParse(genderText, out Gender gender) ? gender : Gender.men;
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return Gender.men;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return Gender.men;
            }
        }

        public static string LoadGenderDescriptionSetting()
        {
            try
            {
                var gender = LoadGenderTagSetting();
                var field = typeof(Gender).GetField(gender.ToString());
                var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                return attr?.Description ?? gender.ToString();
            }
            catch (FileNotFoundException ex)
            {
                throw;
            }
        }

        public static void SaveLanguageSettings(Language language)
        {
            SettingsFileCheckingAndCorruption();
            try
            {

                XDocument doc = XDocument.Load(settingsFilePath);
                XElement languageElement = doc.Root.Element("Language");

                languageElement?.Remove();

                languageElement = new XElement("Language", language.ToString());

                doc.Root.Add(languageElement);
                doc.Save(settingsFilePath);
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static void SaveLanguageSettings(String language)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                Language languageEnum = GetEnumValueFromDescription<Language>(language);

                XDocument doc = XDocument.Load(settingsFilePath);
                XElement languageElement = doc.Root.Element("Language");

                languageElement?.Remove();

                languageElement = new XElement("Language", languageEnum.ToString());

                doc.Root.Add(languageElement);
                doc.Save(settingsFilePath);
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static Language LoadLanguageTagSetting()
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                var langText = doc.Root.Element("Language")?.Value;
                return Enum.TryParse(langText, out Language lang) ? lang : Language.en;
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return Language.en;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return Language.en;
            }
        }

        public static string LoadLanguageDescriptionSetting()
        {
            var language = LoadLanguageTagSetting();
            var field = typeof(Language).GetField(language.ToString());
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attr?.Description ?? language.ToString();
        }

        public static void SaveResolutionSetting(Resolution resolution)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                XElement resolutionElement = doc.Root.Element("Resolution");

                resolutionElement?.Remove();

                resolutionElement = new XElement("Resolution", resolution.ToString());

                doc.Root.Add(resolutionElement);
                doc.Save(settingsFilePath);
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static void SaveResolutionSetting(string resolution)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                if (string.IsNullOrEmpty(resolution))
                {
                    throw new Exception("Resolution value is empty");
                }

                Resolution resolutionEnum = GetEnumValueFromDescription<Resolution>(resolution);

                XDocument doc = XDocument.Load(settingsFilePath);
                XElement resolutionElement = doc.Root.Element("Resolution");

                resolutionElement?.Remove();

                resolutionElement = new XElement("Resolution", resolutionEnum.ToString());

                doc.Root.Add(resolutionElement);
                doc.Save(settingsFilePath);
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static Resolution LoadResolutionTagSetting()
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                var resText = doc.Root.Element("Resolution")?.Value;
                return Enum.TryParse(resText, out Resolution resolution) ? resolution : Resolution.Resolution1366x768;
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return Resolution.Resolution1366x768;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return Resolution.Resolution1366x768;
            }
        }

        public static string LoadResolutionDescriptionSetting()
        {
            var resolution = LoadResolutionTagSetting();
            var field = typeof(Resolution).GetField(resolution.ToString());
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attr?.Description ?? resolution.ToString();
        }

        public static string LoadPlayerPicturePath(Player player)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                string gender = LoadGenderTagSetting().ToString();
                

                XDocument doc = XDocument.Load(settingsWindowsFormFilePath);

                XElement teamElementHome = doc.Root
                .Elements("PlayerPicture")
                .FirstOrDefault(pp =>
                    pp.Attribute("team")?.Value == MainWindow.HomeTeam.country &&
                     pp.Attribute("gender")?.Value == gender);

                XElement teamElementAway = doc.Root
                .Elements("PlayerPicture")
                .FirstOrDefault(pp =>
                    pp.Attribute("team")?.Value == MainWindow.AwayTeam.country &&
                     pp.Attribute("gender")?.Value == gender);

                XElement playerPictureElementHome = null;
                XElement playerPictureElementAway = null;

                if (teamElementHome != null) {
                    playerPictureElementHome = teamElementHome
                    .Elements("Player")
                    .FirstOrDefault(p =>
                        (int)p.Attribute("shirt_number") == player.shirt_number &&
                        p.Attribute("name")?.Value == player.name);
                }

                if (teamElementAway != null)
                {
                   playerPictureElementAway = teamElementAway
                    .Elements("Player")
                    .FirstOrDefault(p =>
                        (int)p.Attribute("shirt_number") == player.shirt_number &&
                        p.Attribute("name")?.Value == player.name);
                }
                


                if (playerPictureElementHome != null)
                {
                    string fileName = playerPictureElementHome.Value;
                    return Path.Combine(settingsWindowsFormPicturePath, fileName);
                }
                if (playerPictureElementAway != null)
                {
                    string fileName = playerPictureElementAway.Value;
                    return Path.Combine(settingsWindowsFormPicturePath, fileName);
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading player picture path: " + ex.Message);
                return null;
            }
        }



        private static void SettingsFileCheckingAndCorruption()
        {
            if (!File.Exists(settingsFilePath))
            {
                // Create new XML document with root element
                XDocument doc = new XDocument(new XElement("Settings"));
                doc.Save(settingsFilePath);
                
            }
        }

        // Test
        private static T GetEnumValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                if ((attribute != null && attribute.Description == description) || field.Name.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException($"No {typeof(T).Name} with description '{description}' found.");
        }
        
        public static void Correction()
        {
            try
            {
                Directory.CreateDirectory(settingsPicturePath);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"{ex.Message}");
            }

        }

        

    }
}
