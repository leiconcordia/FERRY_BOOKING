namespace FERRY_BOOKING.UC_Ferry
{
    partial class Dashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Header / cards controls
        private System.Windows.Forms.Panel headerCardsPanel;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.Panel cardPanel1;
        private System.Windows.Forms.PictureBox cardIcon1;
        private System.Windows.Forms.Label cardTitle1;
        private System.Windows.Forms.Label cardValue1;
        private System.Windows.Forms.Label cardSub1;

        private System.Windows.Forms.Panel cardPanel2;
        private System.Windows.Forms.PictureBox cardIcon2;
        private System.Windows.Forms.Label cardTitle2;
        private System.Windows.Forms.Label cardValue2;
        private System.Windows.Forms.Label cardSub2;

        private System.Windows.Forms.Panel cardPanel3;
        private System.Windows.Forms.PictureBox cardIcon3;
        private System.Windows.Forms.Label cardTitle3;
        private System.Windows.Forms.Label cardValue3;
        private System.Windows.Forms.Label cardSub3;

        private System.Windows.Forms.Panel cardPanel4;
        private System.Windows.Forms.PictureBox cardIcon4;
        private System.Windows.Forms.Label cardTitle4;
        private System.Windows.Forms.Label cardValue4;
        private System.Windows.Forms.Label cardSub4;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();

            // header / cards
            headerCardsPanel = new System.Windows.Forms.Panel();
            flpCards = new System.Windows.Forms.FlowLayoutPanel();

            // card 1
            cardPanel1 = new System.Windows.Forms.Panel();
            cardIcon1 = new System.Windows.Forms.PictureBox();
            cardTitle1 = new System.Windows.Forms.Label();
            cardValue1 = new System.Windows.Forms.Label();
            cardSub1 = new System.Windows.Forms.Label();

            // card 2
            cardPanel2 = new System.Windows.Forms.Panel();
            cardIcon2 = new System.Windows.Forms.PictureBox();
            cardTitle2 = new System.Windows.Forms.Label();
            cardValue2 = new System.Windows.Forms.Label();
            cardSub2 = new System.Windows.Forms.Label();

            // card 3
            cardPanel3 = new System.Windows.Forms.Panel();
            cardIcon3 = new System.Windows.Forms.PictureBox();
            cardTitle3 = new System.Windows.Forms.Label();
            cardValue3 = new System.Windows.Forms.Label();
            cardSub3 = new System.Windows.Forms.Label();

            // card 4
            cardPanel4 = new System.Windows.Forms.Panel();
            cardIcon4 = new System.Windows.Forms.PictureBox();
            cardTitle4 = new System.Windows.Forms.Label();
            cardValue4 = new System.Windows.Forms.Label();
            cardSub4 = new System.Windows.Forms.Label();

            SuspendLayout();
            // 
            // headerCardsPanel
            // 
            headerCardsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerCardsPanel.Height = 150;
            headerCardsPanel.BackColor = System.Drawing.Color.Transparent;
            headerCardsPanel.Padding = new System.Windows.Forms.Padding(16);
            headerCardsPanel.Controls.Add(flpCards);
            // 
            // flpCards
            // 
            flpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            flpCards.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            flpCards.WrapContents = false;
            flpCards.AutoScroll = true;
            flpCards.Padding = new System.Windows.Forms.Padding(8);
            flpCards.Margin = new System.Windows.Forms.Padding(0);
            // card size used across all cards
            var cardSize = new System.Drawing.Size(300, 110);
            var cardMargin = new System.Windows.Forms.Padding(8);

            // --------------------
            // cardPanel1
            // --------------------
            cardPanel1.BackColor = System.Drawing.Color.White;
            cardPanel1.Size = cardSize;
            cardPanel1.Margin = cardMargin;
            cardPanel1.Padding = new System.Windows.Forms.Padding(14);
            cardPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // icon
            cardIcon1.Size = new System.Drawing.Size(28, 28);
            cardIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // lightweight placeholder icon; replace with your resource if preferred:
            cardIcon1.Image = System.Drawing.SystemIcons.Information.ToBitmap();
            cardIcon1.Location = new System.Drawing.Point(cardPanel1.Width - 48, 12);
            cardIcon1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            // title
            cardTitle1.AutoSize = true;
            cardTitle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            cardTitle1.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            cardTitle1.Location = new System.Drawing.Point(14, 12);
            cardTitle1.Text = "Total Ferries";
            // value
            cardValue1.AutoSize = true;
            cardValue1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            cardValue1.ForeColor = System.Drawing.Color.FromArgb(11, 95, 235); // accent blue
            cardValue1.Location = new System.Drawing.Point(14, 34);
            cardValue1.Text = "0";
            // subtitle
            cardSub1.AutoSize = true;
            cardSub1.Font = new System.Drawing.Font("Segoe UI", 8F);
            cardSub1.ForeColor = System.Drawing.Color.Gray;
            cardSub1.Location = new System.Drawing.Point(14, 78);
            cardSub1.Text = "0 total seats";
            // add to panel
            cardPanel1.Controls.Add(cardIcon1);
            cardPanel1.Controls.Add(cardTitle1);
            cardPanel1.Controls.Add(cardValue1);
            cardPanel1.Controls.Add(cardSub1);

            // --------------------
            // cardPanel2
            // --------------------
            cardPanel2.BackColor = System.Drawing.Color.White;
            cardPanel2.Size = cardSize;
            cardPanel2.Margin = cardMargin;
            cardPanel2.Padding = new System.Windows.Forms.Padding(14);
            cardPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardIcon2.Size = new System.Drawing.Size(28, 28);
            cardIcon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            cardIcon2.Image = System.Drawing.SystemIcons.Shield.ToBitmap();
            cardIcon2.Location = new System.Drawing.Point(cardPanel2.Width - 48, 12);
            cardIcon2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cardTitle2.AutoSize = true;
            cardTitle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            cardTitle2.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            cardTitle2.Location = new System.Drawing.Point(14, 12);
            cardTitle2.Text = "Active Routes";
            cardValue2.AutoSize = true;
            cardValue2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            cardValue2.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7); // accent gold
            cardValue2.Location = new System.Drawing.Point(14, 34);
            cardValue2.Text = "0";
            cardSub2.AutoSize = true;
            cardSub2.Font = new System.Drawing.Font("Segoe UI", 8F);
            cardSub2.ForeColor = System.Drawing.Color.Gray;
            cardSub2.Location = new System.Drawing.Point(14, 78);
            cardSub2.Text = "0 active schedules";
            cardPanel2.Controls.Add(cardIcon2);
            cardPanel2.Controls.Add(cardTitle2);
            cardPanel2.Controls.Add(cardValue2);
            cardPanel2.Controls.Add(cardSub2);

            // --------------------
            // cardPanel3
            // --------------------
            cardPanel3.BackColor = System.Drawing.Color.White;
            cardPanel3.Size = cardSize;
            cardPanel3.Margin = cardMargin;
            cardPanel3.Padding = new System.Windows.Forms.Padding(14);
            cardPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardIcon3.Size = new System.Drawing.Size(28, 28);
            cardIcon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            cardIcon3.Image = System.Drawing.SystemIcons.Application.ToBitmap();
            cardIcon3.Location = new System.Drawing.Point(cardPanel3.Width - 48, 12);
            cardIcon3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cardTitle3.AutoSize = true;
            cardTitle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            cardTitle3.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            cardTitle3.Location = new System.Drawing.Point(14, 12);
            cardTitle3.Text = "Total Bookings";
            cardValue3.AutoSize = true;
            cardValue3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            cardValue3.ForeColor = System.Drawing.Color.FromArgb(11, 95, 235); // blue
            cardValue3.Location = new System.Drawing.Point(14, 34);
            cardValue3.Text = "0";
            cardSub3.AutoSize = true;
            cardSub3.Font = new System.Drawing.Font("Segoe UI", 8F);
            cardSub3.ForeColor = System.Drawing.Color.Gray;
            cardSub3.Location = new System.Drawing.Point(14, 78);
            cardSub3.Text = "0.0% occupancy rate";
            cardPanel3.Controls.Add(cardIcon3);
            cardPanel3.Controls.Add(cardTitle3);
            cardPanel3.Controls.Add(cardValue3);
            cardPanel3.Controls.Add(cardSub3);

            // --------------------
            // cardPanel4
            // --------------------
            cardPanel4.BackColor = System.Drawing.Color.White;
            cardPanel4.Size = cardSize;
            cardPanel4.Margin = cardMargin;
            cardPanel4.Padding = new System.Windows.Forms.Padding(14);
            cardPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardIcon4.Size = new System.Drawing.Size(28, 28);
            cardIcon4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            cardIcon4.Image = System.Drawing.SystemIcons.Warning.ToBitmap();
            cardIcon4.Location = new System.Drawing.Point(cardPanel4.Width - 48, 12);
            cardIcon4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cardTitle4.AutoSize = true;
            cardTitle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            cardTitle4.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            cardTitle4.Location = new System.Drawing.Point(14, 12);
            cardTitle4.Text = "Total Revenue";
            cardValue4.AutoSize = true;
            cardValue4.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            cardValue4.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7); // gold
            cardValue4.Location = new System.Drawing.Point(14, 34);
            cardValue4.Text = "₱0";
            cardSub4.AutoSize = true;
            cardSub4.Font = new System.Drawing.Font("Segoe UI", 8F);
            cardSub4.ForeColor = System.Drawing.Color.Gray;
            cardSub4.Location = new System.Drawing.Point(14, 78);
            cardSub4.Text = "All time earnings";
            cardPanel4.Controls.Add(cardIcon4);
            cardPanel4.Controls.Add(cardTitle4);
            cardPanel4.Controls.Add(cardValue4);
            cardPanel4.Controls.Add(cardSub4);

            // add cards to flowpanel
            flpCards.Controls.Add(cardPanel1);
            flpCards.Controls.Add(cardPanel2);
            flpCards.Controls.Add(cardPanel3);
            flpCards.Controls.Add(cardPanel4);

            // 
            // groupBox1 (existing)
            // 
            groupBox1.Location = new System.Drawing.Point(22, 200); // move down so cards stay on top
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(250, 125);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";

            // 
            // Dashboard (user control)
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new System.Drawing.Size(0, 1000);

            // add header/cards first so they appear on top
            Controls.Add(groupBox1);
            Controls.Add(headerCardsPanel);
            Name = "Dashboard";
            Size = new System.Drawing.Size(1233, 800);

            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
    }
}