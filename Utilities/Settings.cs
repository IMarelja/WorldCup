using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Utilities
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
    public enum Gender
    {
        Male,
        Female
    }

    public enum Language
    {
        EN,
        HR
    }

    public class Settings
    {
        //private static string PATH = Path.Combine(AppContext.BaseDirectory, @"Settings/settings.xml");
        private static string PATH = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,@"Settings\settings.xml");
        private static Gender SelectedGender { get; set; }
        private static Language SelectedLanguage { get; set; }

        private Settings() { }
        
        public static bool FileValidation()
        {
            
            if (!File.Exists(PATH))
            {
                return false;
            }
           
            return true;
        }

        

        public static void SaveSettings(Dictionary<SettingsOptions, string> NewSetting)
        {
            if (!File.Exists(PATH))
            {
                // Create new XML document with root element
                XDocument doc = new XDocument(new XElement("Settings"));
                doc.Save(PATH);
            }

            try
            {
                // Load existing XML file
                XDocument doc = XDocument.Load(PATH);
                XElement root = doc.Root;

                // Iterate through settings to add or update
                foreach (var setting in NewSetting)
                {
                    switch (setting.Key)
                    {
                        case SettingsOptions.Gender:
                            // Validate and set Gender
                            string genderValue = setting.Value;
                            if (!Enum.TryParse<Gender>(genderValue, out _))
                            {
                                genderValue = Enum.GetNames(typeof(Gender))[0]; // Default to first enum
                            }

                            XElement genderElement = root.Element(SettingsOptions.Gender.ToString());
                            if (genderElement != null)
                            {
                                genderElement.Value = genderValue;
                            }
                            else
                            {
                                root.Add(new XElement(SettingsOptions.Gender.ToString(), genderValue));
                            }
                            break;

                        case SettingsOptions.Language:
                            // Validate and set Language
                            string languageValue = setting.Value;
                            if (!Enum.TryParse<Language>(languageValue, out _))
                            {
                                languageValue = Enum.GetNames(typeof(Language))[0]; // Default to first enum
                            }

                            XElement languageElement = root.Element(SettingsOptions.Language.ToString());
                            if (languageElement != null)
                            {
                                languageElement.Value = languageValue;
                            }
                            else
                            {
                                root.Add(new XElement(SettingsOptions.Language.ToString(), languageValue));
                            }
                            break;

                        case SettingsOptions.FavoriteTeamID:
                            // Set FavoriteTeamID
                            XElement teamElement = root.Element(SettingsOptions.FavoriteTeamID.ToString());
                            if (teamElement != null)
                            {
                                teamElement.Value = setting.Value;
                            }
                            else
                            {
                                root.Add(new XElement(SettingsOptions.FavoriteTeamID.ToString(), setting.Value));
                            }
                            break;

                        // FIX IT THIS IT BROKEN!!
                        case SettingsOptions.FavoritePlayersID:
                            // Handle FavoritePlayersID which has its own children
                            XElement playersElement = root.Element(SettingsOptions.FavoritePlayersID.ToString());
                            if (playersElement == null)
                            {
                                playersElement = new XElement(SettingsOptions.FavoritePlayersID.ToString());
                                root.Add(playersElement);
                            }

                            // Parse comma-separated player IDs if that's the format being used
                            string[] playerIDs = setting.Value.Split(',');
                            playersElement.RemoveAll(); // Clear existing children

                            foreach (string playerID in playerIDs)
                            {
                                playersElement.Add(new XElement("Player", playerID.Trim()));
                            }
                            break;
                            /*
                        case SettingsOptions.PlayerPictureAssignID:
                            // Handle FavoritePlayersID which has its own children
                            XElement pictureElement = root.Element(SettingsOptions.PlayerPictureAssignID.ToString());
                            if (pictureElement == null)
                            {
                                pictureElement = new XElement(SettingsOptions.FavoritePlayersID.ToString());
                                root.Add(pictureElement);
                            }

                            // Parse comma-separated player IDs if that's the format being used
                            string[] playerIDs = setting.Value.Split(',');
                            pictureElement.RemoveAll(); // Clear existing children

                            foreach (string playerID in playerIDs)
                            {
                                playersElement.Add(new XElement("Player", playerID.Trim()));
                            }
                            break;
                            */
                    }
                }

                // Save changes
                doc.Save(PATH);
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static string LoadSetting(SettingsOptions KeySetting)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(PATH);

            // Select the node specified by KeySetting
            XmlNode node = xmlDoc.SelectSingleNode("//Settings/" + KeySetting);

            if (node != null)
            {
                return node.InnerText;
            }
            else
            {
                return string.Empty; // Or some default value if node not found
            }
        }
    }
}
