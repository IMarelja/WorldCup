using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml.Permissions;
using Models;
using WorldCupWPF.Utilities;

namespace WorldCupWPF.Windows_Tools
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private Player playerInfo;
        private string matchPlayingID;
        public PlayerControl(Player player, string MatchID)
        {
            playerInfo = player;
            matchPlayingID = MatchID;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Tag = playerInfo;
            if (playerInfo != null) { 
                lbName.Content = playerInfo.name;
                lbNumber.Content = playerInfo.shirt_number;

                String picture = Utilities.Settings.LoadPlayerPicturePath(playerInfo as Player);

                if (picture != null)
                {
                    FormAutomization.LoadImageIntoImageControl(picture,imagePlayer);
                }
            }
        }

        private void Content_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                lbName.Effect = new DropShadowEffect
                {
                    Color = Colors.LightGray,
                    BlurRadius = 10,
                    ShadowDepth = 0
                };

                Storyboard hoverOn = (Storyboard)FindResource("HoverOnStoryboard");
                hoverOn.Begin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Content_MouseLeave(object sender, MouseEventArgs e)
        {
            try { 
                lbName.Effect = null;

                Storyboard hoverOff = (Storyboard)FindResource("HoverOffStoryboard");
                hoverOff.Begin();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlayerUserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window PlayerInfo = new PlayerInformation(playerInfo, matchPlayingID);
            PlayerInfo.ShowDialog();
        }
    }
}
