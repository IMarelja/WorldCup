using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Models;
using WCRepo.Repository;
using WorldCupWPF.Utilities;

namespace WorldCupWPF.Windows_Tools
{
    /// <summary>
    /// Interaction logic for PlayerInformation.xaml
    /// </summary>
    public partial class PlayerInformation : Window
    {
        private Player selectedPlayer;
        private string playerMatchID;

        private static readonly IRepository repository = RepositoryFactory.GetRepository();
        public PlayerInformation(Player player, string MatchID)
        {
            selectedPlayer = player;
            playerMatchID = MatchID;
            InitializeComponent();
        }

        private void PlayerInformation_Loaded(object sender, RoutedEventArgs e)
        {
            FormAutomization.ApplyLanguage(this, Settings.LoadLanguageTagSetting());
            lbName.Content = selectedPlayer.name;
            lbPosition.Content = selectedPlayer.position;
            lbShirtNumber.Content = selectedPlayer.shirt_number;
            if (!(selectedPlayer.captain == true))
            {
                lbCaptain.Visibility = Visibility.Collapsed;
            }

            try
            {

                String picture = Utilities.Settings.LoadPlayerPicturePath(selectedPlayer as Player);

                if (picture != null)
                {
                    FormAutomization.LoadImageIntoImageControl(picture, imagePlayer);
                }

                Models.Match match = repository.GetMatch(playerMatchID, Settings.LoadGenderTagSetting());

                int goals = match.home_team_events
                    .Concat(match.away_team_events)
                    .Count(e => (e.type_of_event == "goal" || e.type_of_event == "goal-penalty") &&
                                e.player.Equals(selectedPlayer.name, StringComparison.OrdinalIgnoreCase));

                int yellowCards = match.home_team_events
                    .Concat(match.away_team_events)
                    .Count(e => e.type_of_event == "yellow-card" &&
                                e.player.Equals(selectedPlayer.name, StringComparison.OrdinalIgnoreCase));

                lbGoalsCount.Content = goals;
                lbYellowCardsCount.Content = yellowCards;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
