namespace FERRY_BOOKING.Dialogs
{
    partial class TicketForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpTicket = new FlowLayoutPanel();
            btnPrint = new Button();
            SuspendLayout();
            // 
            // flpTicket
            // 
            flpTicket.FlowDirection = FlowDirection.TopDown;
            flpTicket.WrapContents = false;          // essential: one column only
            flpTicket.AutoScroll = true;           // enables scroll-bars// optional: fill form/client area
            flpTicket.Location = new Point(12, 12);
            flpTicket.Name = "flpTicket";
            flpTicket.Size = new Size(806, 378);
            flpTicket.TabIndex = 0;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.Red;
            btnPrint.ForeColor = SystemColors.ButtonHighlight;
            btnPrint.Location = new Point(698, 396);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(120, 42);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // TicketForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 450);
            Controls.Add(btnPrint);
            Controls.Add(flpTicket);
            Name = "TicketForm";
            Text = "Ticket";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxTickets;
        private FlowLayoutPanel flpTicket;
        private Button btnPrint;
    }
}