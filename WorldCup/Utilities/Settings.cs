using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using WCRepo.Model;
using WCRepo.Models;

namespace WorldCup.Utilities
{
    //Settings values
    public enum SettingsOptions
    {
        Gender,
        Language,
        FavoriteTeamID,
        FavoritePlayersID,
        PlayerPictureAssignID
    }
    
    public enum Language
    {
        [Description("EN-US")]
        EnUs,

        [Description("HR")]
        Hr
    }
    public class Settings
    {

        public static string settingsFilePath = Path.Combine(HomePath.Value(), @"Settings\settings.xml");

        //public static string settingsFilePath = "C:\\Users\\windsten\\source\\repos\\WorldCupProject\\WorldCup\\Settings\\settings.xml";

        public static string settingsPicturePath = Path.Combine(HomePath.Value(), @"Settings\Pictures");
        /*
        public static readonly Gender SelectedGender = LoadSettings(SettingsOptions.Gender, str =>
                                                       Enum.TryParse(str, out Gender g) ? g : Gender.men);

        public static readonly Language SelectedLanguage = LoadSettings(SettingsOptions.Language, str =>
                                                           Enum.TryParse(str, out Language l) ? l : Language.EnUs);*/
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
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
                return Gender.men;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Language LoadLanguageTagSetting()
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                var langText = doc.Root.Element("Language")?.Value;
                return Enum.TryParse(langText, out Language lang) ? lang : Language.EnUs;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return Language.EnUs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return Language.EnUs;
            }
        }

        public static string LoadLanguageDescriptionSetting()
        {
            var language = LoadLanguageTagSetting();
            var field = typeof(Language).GetField(language.ToString());
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attr?.Description ?? language.ToString();
        }

        public static void SaveFavoriteTeamSetting(Team team)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                XElement favoriteTeamElement = doc.Root.Elements("FavoriteTeam").FirstOrDefault(e => e.Attribute("gender")?.Value == Settings.LoadGenderTagSetting().ToString()); ;

                favoriteTeamElement?.Remove();

                favoriteTeamElement = new XElement("FavoriteTeam", new XAttribute("id", team.id), new XAttribute("gender", Settings.LoadGenderTagSetting()), team.country);

                doc.Root.Add(favoriteTeamElement);

                doc.Save(settingsFilePath);
                

                
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Team LoadFavoriteTeamSetting()
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                XElement favoriteTeamElement = doc.Root.Elements("FavoriteTeam")
                    .FirstOrDefault(e => e.Attribute("gender")?.Value == LoadGenderTagSetting().ToString());

                if (favoriteTeamElement != null &&
                    int.TryParse(favoriteTeamElement.Attribute("id")?.Value, out int teamId))
                {
                    string teamName = favoriteTeamElement.Value;
                    return new Team { id = teamId, country = teamName };
                }

                return null;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /*
        public static void SaveFavoritePlayerSetting()
        {
            SettingsFileCheckingAndCorruption();
            try
            {

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */
        private static void SettingsFileCheckingAndCorruption()
        {
            if (!File.Exists(settingsFilePath))
            {
                // Create new XML document with root element
                XDocument doc = new XDocument(new XElement("Settings"));
                doc.Save(settingsFilePath);
                
            }
        }
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
                MessageBox.Show($"{ex.Message}");
            }

        }


    }
}
