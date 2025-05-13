using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCRepo.Models;
using WorldCup.Utilities;

namespace WorldCup
{
    public partial class PlayerInfo : UserControl
    {
        public bool selectStatusPlayerInfo = false;
        private Player containedPlayerInformation;
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
            MessageBox.Show("Test");
        }

        public void SetPlayerInfo(Player player)
        {
            containedPlayerInformation = player;

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
                pbStar.Image = Image.FromFile(Path.Combine(HomePath.Value(), @"Textures\yellow-stars.png"));
                pbStar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbStar.Image = null;
            }

            this.Tag = player;
        }

        public bool getSelectedPlayerInfoControl()
        {
            if (selectStatusPlayerInfo == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void SetPlayerInfoFavoriteStatus(bool newFavoriteStatus)
        {
            if (this.Tag is Player player )
            {
                if (newFavoriteStatus)
                {
                    player.favorite = true;
                    pbStar.Image = Image.FromFile(Path.Combine(HomePath.Value(), @"Textures\yellow-stars.png"));
                    pbStar.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    player.favorite = false;
                    pbStar.Image = null;
                }
            }
        }

        public void setSelectedPlayerInfoControl(bool value)
        {
            selectStatusPlayerInfo = value;
        }

        private void tsmiFavoriteIt_Click(object sender, EventArgs e)
        {

        }

        private void tsmiRemoveFromFavorite_Click(object sender, EventArgs e)
        {

        }


        private void LoadImageIntoPictureBox(string imagePath, PictureBox pictureBox)
        {
            try
            {
                // Load the original image
                using (Image originalImage = Image.FromFile(imagePath))
                {
                    // Calculate the scale factor to fit the image within the PictureBox
                    float scaleWidth = (float)pictureBox.Width / originalImage.Width;
                    float scaleHeight = (float)pictureBox.Height / originalImage.Height;
                    float scale = Math.Min(scaleWidth, scaleHeight);

                    // Calculate new dimensions
                    int newWidth = (int)(originalImage.Width * scale);
                    int newHeight = (int)(originalImage.Height * scale);

                    // Create a new bitmap with the new dimensions
                    Bitmap resizedImage = new Bitmap(newWidth, newHeight);

                    // Create a graphics object to draw the resized image
                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                    {
                        // Set the interpolation mode for better quality
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                        // Draw the resized image
                        graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                    }

                    // Assign the resized image to the PictureBox
                    pictureBox.Image = resizedImage;

                    // Optional: Set the SizeMode if needed
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
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
            
        }

    }
}
