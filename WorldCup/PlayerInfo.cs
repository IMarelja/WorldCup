using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using WorldCup.Utilities;

namespace WorldCup
{
    public partial class PlayerInfo : UserControl
    {
        public bool selectStatusPlayerInfo = false;
        public PlayerInfo()
        {
            InitializeComponent();

        }

        private void PlayerInfo_Load(object sender, EventArgs e)
        {

            FormAutomization.ApplyLanguage(this, Settings.LoadLanguageTagSetting());

        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Title = "Select Image";

                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|" +
                                       "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                       "PNG (*.png)|*.png|" +
                                       "BMP (*.bmp)|*.bmp|" +
                                       "All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    Settings.SavePlayerPicturePath(selectedFile, (Player)this.Tag);

                    ((Player)this.Tag).picturePath = Settings.LoadPlayerPicturePath((Player)this.Tag);

                    FormAutomization.LoadImageIntoPictureBox(selectedFile, pbPlayerPicture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetPlayerInfo(Player player)
        {


            lbName.Text = player.name;
            lbPosition.Text = player.position;
            lbShirtNumber.Text = player.shirt_number.ToString();

            if (player.captain == true)
            {
                lbCaptain.Visible = true;
            }
            else
            {
                lbCaptain.Visible = false;
            }

            if (player.favorite == true)
            {
                FormAutomization.LoadImageIntoPictureBox(Path.Combine(HomePath.Value(), @"Textures\yellow-stars.png"), pbStar);
            }
            else
            {
                pbStar.Image = null;
            }

            string imagePlayer = Settings.LoadPlayerPicturePath(player);

            if (imagePlayer != null)
            {
                FormAutomization.LoadImageIntoPictureBox(Path.Combine(Settings.settingsPicturePath, imagePlayer),pbPlayerPicture);
            }
            else
            {
                FormAutomization.LoadImageIntoPictureBox(Path.Combine(HomePath.Value(), @"Textures\default-picture.png"), pbPlayerPicture);
            }

                this.Tag = player;
        }

        public void SetPlayerInfoFavoriteStatus(bool newFavoriteStatus)
        {
            if (this.Tag is Player player)
            {
                if (newFavoriteStatus)
                {
                    player.favorite = true;
                    FormAutomization.LoadImageIntoPictureBox(Path.Combine(HomePath.Value(), @"Textures\yellow-stars.png"), pbStar);
                }
                else
                {
                    player.favorite = false;
                    pbStar.Image = null;
                }
            }
            else
            {
                throw new Exception("The tag does not contain player or the PlayerInfo User control");
            }
        }

        public void SetSelectedPlayerInfoControl(bool value)
        {
            selectStatusPlayerInfo = value;
        }

        private void tsmiFavoriteIt_Click(object sender, EventArgs e)
        {
            var form = this.FindForm() as WorldCup;
            if (form != null)
            {
                FormAutomization.MoveUserControlBetweenFlowLayoutPanel(this, form.flpPlayers, form.flpFavoritePlayers);
                this.SetPlayerInfoFavoriteStatus(true);
                Settings.SaveFavoritePlayerSetting(this.Tag as Player);
            }
        }

        private void tsmiRemoveFromFavorite_Click(object sender, EventArgs e)
        {
            var form = this.FindForm() as WorldCup;
            if (form != null)
            {
                FormAutomization.MoveUserControlBetweenFlowLayoutPanel(this, form.flpFavoritePlayers, form.flpPlayers);
                this.SetPlayerInfoFavoriteStatus(false);
                Settings.RemoveFavoritePlayerSettingByPlayer(this.Tag as Player);
            }
        }


        private void PlayerInfo_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerInfo playerControl = (PlayerInfo)sender;
            if (e.Button == MouseButtons.Left && ModifierKeys.HasFlag(Keys.Shift))
            {
                // Toggle selection
                if (selectStatusPlayerInfo)
                {
                    // Deselect
                    selectStatusPlayerInfo = false;
                    this.BackColor = DefaultBackColor;
                }
                else
                {
                    // Select
                    selectStatusPlayerInfo = true;
                    this.BackColor = SystemColors.ActiveCaption;
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (playerControl != null)
                    {
                        // Begin drag
                        DoDragDrop(playerControl, DragDropEffects.Move);
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    Player player = (Player)this.Tag;
                    if (player.favorite == true)
                    {
                        tsmiRemoveFromFavorite.Visible = true;
                        tsmiFavoriteIt.Visible = false;
                        cmsPlayerInfo.Show(this, e.Location);
                    }
                    if (player.favorite == false)
                    {
                        tsmiRemoveFromFavorite.Visible = false;
                        tsmiFavoriteIt.Visible = true;
                        cmsPlayerInfo.Show(this, e.Location);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void cmsPlayerInfo_Opening(object sender, CancelEventArgs e)
        {
            FormAutomization.ApplyLanguage(cmsPlayerInfo, Settings.LoadLanguageTagSetting());
        }
    }
}
