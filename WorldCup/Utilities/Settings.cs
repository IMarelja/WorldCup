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
using System.Globalization;
using System.Resources;

namespace WorldCup.Utilities
{
    //Settings values
    public enum SettingsOptions
    {
        Gender,
        Language,
        FavoriteTeamid,
        FavoritePlayersid,
        PlayerPictureAssignid
    }
    
    public enum Language
    {

        [Description("English")]
        en,

        [Description("Hrvatski")]
        hr
    }
    public class Settings
    {

        public static string settingsFilePath = Path.Combine(HomePath.Value(), @"Settings\settings.xml");

        public static string settingsPicturePath = Path.Combine(HomePath.Value(), @"Settings\Pictures");
        
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
                return Enum.TryParse(langText, out Language lang) ? lang : Language.en;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return Language.en;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    int.TryParse(favoriteTeamElement.Attribute("id")?.Value, out int teamid))
                {
                    string teamName = favoriteTeamElement.Value;
                    return new Team { id = teamid, country = teamName };
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
        
        public static void SaveFavoritePlayerSetting(Player player)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                XDocument doc = XDocument.Load(settingsFilePath);
                string gender = LoadGenderTagSetting().ToString();
                string team = LoadFavoriteTeamSetting()?.country;

                if (string.IsNullOrEmpty(team) || string.IsNullOrEmpty(gender))
                {
                    MessageBox.Show("Favorite team or gender is not set.");
                    return;
                }

                // Find existing FavoritePlayer node
                XElement existingTeamNode = doc.Root.Elements("FavoritePlayer")
                    .FirstOrDefault(fp =>
                        (string)fp.Attribute("team") == team &&
                        (string)fp.Attribute("gender") == gender);

                if (existingTeamNode == null)
                {
                    // Create new FavoritePlayer node
                    existingTeamNode = new XElement("FavoritePlayer",
                        new XAttribute("team", team),
                        new XAttribute("gender", gender));

                    doc.Root.Add(existingTeamNode);
                }

                // Create new Player element
                XElement newPlayer = new XElement("Player",
                    new XAttribute("captain", player.captain.ToString().ToLower()),
                    new XAttribute("shirt_number", player.shirt_number),
                    new XAttribute("position", player.position),
                    player.name);

                existingTeamNode.Add(newPlayer);
                doc.Save(settingsFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Player LoadFavoritePlayerSettingByPlayer(Player player)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                var doc = XDocument.Load(settingsFilePath);
                var gender = LoadGenderTagSetting().ToString();
                var team = LoadFavoriteTeamSetting()?.country;

                var playerElement = doc.Descendants("FavoritePlayer")
                    .FirstOrDefault(fp =>
                        (string)fp.Attribute("team") == team &&
                        (string)fp.Attribute("gender") == gender)?
                    .Elements("Player")
                    .FirstOrDefault(p =>
                        (string)p.Value == player.name &&
                        (int)p.Attribute("shirt_number") == player.shirt_number);

                if (playerElement == null) return null;

                return new Player
                {
                    name = playerElement.Value,
                    captain = bool.Parse(playerElement.Attribute("captain")?.Value ?? "false"),
                    shirt_number = int.Parse(playerElement.Attribute("shirt_number")?.Value ?? "0"),
                    position = playerElement.Attribute("position")?.Value
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public static List<Player> LoadFavoritePlayersSetting()
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                var doc = XDocument.Load(settingsFilePath);
                var gender = LoadGenderTagSetting().ToString();
                var team = LoadFavoriteTeamSetting()?.country;

                var players = doc.Descendants("FavoritePlayer")
                    .FirstOrDefault(fp =>
                        (string)fp.Attribute("team") == team &&
                        (string)fp.Attribute("gender") == gender)?
                    .Elements("Player")
                    .Select(p => new Player
                    {
                        name = p.Value,
                        captain = bool.Parse(p.Attribute("captain")?.Value ?? "false"),
                        shirt_number = int.Parse(p.Attribute("shirt_number")?.Value ?? "0"),
                        position = p.Attribute("position")?.Value
                    }).ToList();

                return players ?? new List<Player>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Player>();
            }
        }

        public static void RemoveFavoritePlayerSettingByPlayer(Player player)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                var doc = XDocument.Load(settingsFilePath);
                var gender = LoadGenderTagSetting().ToString();
                var team = LoadFavoriteTeamSetting()?.country;

                var favoritePlayerElement = doc.Descendants("FavoritePlayer")
                    .FirstOrDefault(fp =>
                        (string)fp.Attribute("team") == team &&
                        (string)fp.Attribute("gender") == gender);

                if (favoritePlayerElement == null)
                    return;

                var playerElement = favoritePlayerElement.Elements("Player")
                    .FirstOrDefault(p =>
                        (string)p.Value == player.name &&
                        (int)p.Attribute("shirt_number") == player.shirt_number);

                if (playerElement != null)
                {
                    playerElement.Remove();
                    doc.Save(settingsFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool IsFavoritePlayerSetting(Player player)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                var doc = XDocument.Load(settingsFilePath);
                var gender = LoadGenderTagSetting().ToString();
                var team = LoadFavoriteTeamSetting()?.country;

                if (string.IsNullOrEmpty(team) || string.IsNullOrEmpty(gender))
                    return false;

                var favoritePlayerElement = doc.Descendants("FavoritePlayer")
                    .FirstOrDefault(fp =>
                        (string)fp.Attribute("team") == team &&
                        (string)fp.Attribute("gender") == gender);

                if (favoritePlayerElement == null)
                    return false;

                var playerElement = favoritePlayerElement.Elements("Player")
                    .FirstOrDefault(p =>
                        (string)p.Value == player.name &&
                        (int)p.Attribute("shirt_number") == player.shirt_number);

                return playerElement != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void SavePlayerPicturePath(string picturePath, Player player)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                string gender = LoadGenderTagSetting().ToString();
                string team = LoadFavoriteTeamSetting()?.country;
                string fileName = $"{player.shirt_number}_{player.name}.png";
                string savePath = Path.Combine(settingsPicturePath, fileName);

                // Convert to PNG if not already PNG
                using (Image image = Image.FromFile(picturePath))
                {
                    image.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                }

                XDocument doc = XDocument.Load(settingsFilePath);

                // Remove or create new PlayerPicture section
                XElement playerPictureElement = doc.Root.Elements("PlayerPicture")
                    .FirstOrDefault(pp => pp.Attribute("team")?.Value == team && pp.Attribute("gender")?.Value == gender);

                if (playerPictureElement == null)
                {
                    playerPictureElement = new XElement("PlayerPicture",
                        new XAttribute("team", team),
                        new XAttribute("gender", gender)
                    );
                    doc.Root.Add(playerPictureElement);
                }

                // Add or replace the specific player element
                XElement existing = playerPictureElement.Elements("Player").FirstOrDefault(p =>
                    p.Value == fileName &&
                    (int)p.Attribute("shirt_number") == player.shirt_number);

                if (existing != null)
                {
                    existing.ReplaceWith(new XElement("Player",
                        new XAttribute("captain", player.captain),
                        new XAttribute("shirt_number", player.shirt_number),
                        new XAttribute("position", player.position),
                        new XAttribute("name", player.name),
                        fileName
                    ));
                }
                else
                {
                    playerPictureElement.Add(new XElement("Player",
                        new XAttribute("captain", player.captain),
                        new XAttribute("shirt_number", player.shirt_number),
                        new XAttribute("position", player.position),
                        new XAttribute("name", player.name),
                        fileName
                    ));
                }

                doc.Save(settingsFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving player picture path: " + ex.Message);
            }
        }

        public static string LoadPlayerPicturePath(Player player)
        {
            SettingsFileCheckingAndCorruption();
            try
            {
                string gender = LoadGenderTagSetting().ToString();
                string team = LoadFavoriteTeamSetting()?.country;

                XDocument doc = XDocument.Load(settingsFilePath);

                XElement playerPictureElement = doc.Root.Elements("PlayerPicture")
                    .FirstOrDefault(pp => pp.Attribute("team")?.Value == team && pp.Attribute("gender")?.Value == gender);

                if (playerPictureElement == null) return null;

                XElement playerElement = playerPictureElement.Elements("Player").FirstOrDefault(p =>
                    (int)p.Attribute("shirt_number") == player.shirt_number &&
                    p.Attribute("name")?.Value == player.name);

                if (playerElement != null)
                {
                    string fileName = playerElement.Value;
                    return Path.Combine(settingsPicturePath, fileName);
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
                MessageBox.Show($"{ex.Message}");
            }

        }

        

    }
}
