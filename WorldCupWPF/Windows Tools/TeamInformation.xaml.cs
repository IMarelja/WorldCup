using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for TeamInformation.xaml
    /// </summary>
    public partial class TeamInformation : Window
    {
        private static readonly IRepository repository = RepositoryFactory.GetRepository();

        private Team teamInfo;
        public TeamInformation(Team team)
        {
            this.teamInfo = team;
            InitializeComponent();
        }

        private void windowTeamInformation_Loaded(object sender, RoutedEventArgs e)
        {
            FormAutomization.ApplyLanguage(this,Settings.LoadLanguageTagSetting());
            lbCountry.Content = teamInfo.country;
            lbFifaCode.Content = teamInfo.fifa_code;
            try
            {
                Moduls.Result result = repository.GetResult(teamInfo.id,Settings.LoadGenderTagSetting());

                lbWinsCount.Content = result.wins;
                lbLosesCount.Content = result.losses;
                lbDrawCount.Content = result.draws;
                lbScoredCount.Content = result.goals_for;
                lbConcivedCount.Content = result.goals_against;
                lbDifferenceCount.Content = result.goal_differential;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
