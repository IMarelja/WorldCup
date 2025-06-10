using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Models;
using WCRepo.Repository;
using WorldCupWPF.Utilities;
using WorldCupWPF.Windows_Tools;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {
        public static Team HomeTeam;
        public static Team AwayTeam;

        private static readonly IRepository repository = RepositoryFactory.GetRepository();
        public MainWindow()
        {
            InitializeComponent();

            FormAutomization.SetWindowResolutionBasedOnResolutionSettings(this);

        }

        private void LoadCountriesIntoComboBox(ComboBox comboBox)
        {
            //suppressLoadEvents = true;
            try
            {
                comboBox.Items.Clear();

                foreach (Team team in repository.GetTeams(Settings.LoadGenderTagSetting()))
                {
                    comboBox.Items.Add(team);
                    
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }


        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Window settings = new SettingsWindow();
            settings.ShowDialog();
        }

        private void cbTeam1_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCountriesIntoComboBox(cbTeam1);
        }

        private void cbTeam2_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCountriesIntoComboBox(cbTeam2);
        }

        private void ComboBoxPartnerListener(ComboBox comboBox1, ComboBox comboBox2)
        {
            if (!(comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1))
            {
                if (!(comboBox1.SelectedIndex == comboBox2.SelectedIndex))
                {
                    FillTheMatchFieldGridWithPlayers(playingFieldWorldCup, comboBox1, comboBox2);
                }
                else
                {
                    MessageBox.Show("Two values are the SAME");

                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                }
            }
        }

        private void FillTheMatchFieldGridWithPlayers(Grid playingFieldWorldCup, ComboBox comboBox1, ComboBox comboBox2)
        {
            try
            {
                HomeTeam = comboBox1.SelectedItem as Team;
                AwayTeam = comboBox2.SelectedItem as Team;

                Gender group = Settings.LoadGenderTagSetting();

                playingFieldWorldCup.Children.Clear();

                Models.Match match = repository.GetMatchBetweenTeams(HomeTeam.id, AwayTeam.id, group);

                playingFieldWorldCup.Children.Clear();

                if (match == null)
                {
                    MessageBox.Show("No match found between selected teams.", "Match Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    return;
                }

                Dictionary<string, int> homePositionMap = new Dictionary<string, int>
                {
                    { "Goalie", 0 },
                    { "Defender", 1 },
                    { "Midfield", 2 },
                    { "Forward", 3 }
                };

                Dictionary<string, int> awayPositionMap = new Dictionary<string, int>
                {
                    { "Forward", 4 },
                    { "Midfield", 5 },
                    { "Defender", 6 },
                    { "Goalie", 7 }
                };

                for (int col = 0; col < 8; col++)
                {
                    Grid columnGrid = new Grid();
                    Grid.SetColumn(columnGrid, col);
                    playingFieldWorldCup.Children.Add(columnGrid);
                }

                // Add home players
                Dictionary<int, int> homeRowTracker = new();
                foreach (var player in match.home_team_statistics.starting_eleven)
                {
                    if (!homePositionMap.TryGetValue(player.position, out int column)) continue;

                    // Find the grid for this column
                    Grid targetGrid = playingFieldWorldCup.Children
                        .OfType<Grid>()
                        .Where(g => Grid.GetColumn(g) == column)
                        .FirstOrDefault();

                    if (targetGrid == null) continue;

                    UserControl control = new PlayerControl(player, match.fifa_id);

                    // Add row definition to the column grid
                    targetGrid.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(control, targetGrid.RowDefinitions.Count - 1);

                    targetGrid.Children.Add(control);
                }

                // Add away players
                Dictionary<int, int> awayRowTracker = new();
                foreach (var player in match.away_team_statistics.starting_eleven)
                {
                    if (!awayPositionMap.TryGetValue(player.position, out int column)) continue;

                    // Find the grid for this column
                    Grid targetGrid = playingFieldWorldCup.Children
                        .OfType<Grid>()
                        .Where(g => Grid.GetColumn(g) == column)
                        .FirstOrDefault();

                    if (targetGrid == null) continue;

                    UserControl control = new PlayerControl(player, match.fifa_id);

                    // Add row definition to the column grid
                    targetGrid.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(control, targetGrid.RowDefinitions.Count - 1);

                    targetGrid.Children.Add(control);
                }

                lbMatchResult.Content = $"({match.home_team.country}) {match.home_team.goals} : {match.away_team.goals} ({match.away_team.country})";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void cbTeam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxPartnerListener(cbTeam1, cbTeam2);
        }

        private void cbTeam1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxPartnerListener(cbTeam1, cbTeam2);
        }

        private void btnTeam2Info_Click(object sender, RoutedEventArgs e)
        {
            var sb = (Storyboard)FindResource("BounceRed");
            Storyboard.SetTarget(sb, btnTeam2Info);
            sb.Begin();

            if (!(cbTeam2.SelectedIndex == -1))
            {
                Window TeamInfo = new TeamInformation(cbTeam2.SelectedItem as Team);
                TeamInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a team!");
            }
        }
        

        private void btnTeam1Info_Click(object sender, RoutedEventArgs e)
        {
            var sb = (Storyboard)FindResource("BounceBlue");
            Storyboard.SetTarget(sb, btnTeam1Info);
            sb.Begin();

            if (!(cbTeam1.SelectedIndex == -1)) { 
                Window TeamInfo = new TeamInformation(cbTeam1.SelectedItem as Team);
                TeamInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a team!");
            }
        }

        private void btnTeam1Info_MouseEnter(object sender, MouseEventArgs e)
        {
            var sb = (Storyboard)FindResource("BlueButtonAnimation");
            Storyboard.SetTarget(sb, btnTeam1Info);
            sb.Begin();
        }

        private void btnTeam2Info_MouseEnter(object sender, MouseEventArgs e)
        {
            var sb = (Storyboard)FindResource("RedButtonAnimation");
            Storyboard.SetTarget(sb, btnTeam2Info);
            sb.Begin();
        }

        private void windowMain_Loaded(object sender, RoutedEventArgs e)
        {
            FormAutomization.ApplyLanguage(this, Settings.LoadLanguageTagSetting());
        }
    }
}