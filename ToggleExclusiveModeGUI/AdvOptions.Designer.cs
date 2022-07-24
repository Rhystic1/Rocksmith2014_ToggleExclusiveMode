namespace ToggleExclusiveModeGUI
{
    partial class AdvOptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvOptions));
            this.bufferSizeText = new System.Windows.Forms.TextBox();
            this.ultraLowLatModeText = new System.Windows.Forms.TextBox();
            this.latencyBuffOpt = new System.Windows.Forms.ComboBox();
            this.ultraLowLatOpt = new System.Windows.Forms.ComboBox();
            this.bufferSizeOpt = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.latBuffTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.buffSizeTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.uLLTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.latencyBuffText = new System.Windows.Forms.TextBox();
            this.readSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.readSettingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bufferSizeText
            // 
            this.bufferSizeText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bufferSizeText.Cursor = System.Windows.Forms.Cursors.Default;
            this.bufferSizeText.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.bufferSizeText.Location = new System.Drawing.Point(12, 48);
            this.bufferSizeText.Name = "bufferSizeText";
            this.bufferSizeText.ReadOnly = true;
            this.bufferSizeText.Size = new System.Drawing.Size(59, 20);
            this.bufferSizeText.TabIndex = 1;
            this.bufferSizeText.TabStop = false;
            this.bufferSizeText.Text = "Buffer Size";
            // 
            // ultraLowLatModeText
            // 
            this.ultraLowLatModeText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ultraLowLatModeText.Cursor = System.Windows.Forms.Cursors.Default;
            this.ultraLowLatModeText.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ultraLowLatModeText.Location = new System.Drawing.Point(12, 84);
            this.ultraLowLatModeText.Name = "ultraLowLatModeText";
            this.ultraLowLatModeText.ReadOnly = true;
            this.ultraLowLatModeText.Size = new System.Drawing.Size(124, 20);
            this.ultraLowLatModeText.TabIndex = 3;
            this.ultraLowLatModeText.TabStop = false;
            this.ultraLowLatModeText.Text = "Ultra Low Latency Mode";
            // 
            // latencyBuffOpt
            // 
            this.latencyBuffOpt.BackColor = System.Drawing.SystemColors.Info;
            this.latencyBuffOpt.FormattingEnabled = true;
            this.latencyBuffOpt.Location = new System.Drawing.Point(248, 12);
            this.latencyBuffOpt.Name = "latencyBuffOpt";
            this.latencyBuffOpt.Size = new System.Drawing.Size(121, 21);
            this.latencyBuffOpt.TabIndex = 4;
            this.latencyBuffOpt.SelectedIndexChanged += new System.EventHandler(this.LatencyBuffOpt_SelectedIndexChanged);
            // 
            // ultraLowLatOpt
            // 
            this.ultraLowLatOpt.BackColor = System.Drawing.SystemColors.Info;
            this.ultraLowLatOpt.FormattingEnabled = true;
            this.ultraLowLatOpt.Location = new System.Drawing.Point(248, 83);
            this.ultraLowLatOpt.Name = "ultraLowLatOpt";
            this.ultraLowLatOpt.Size = new System.Drawing.Size(121, 21);
            this.ultraLowLatOpt.TabIndex = 5;
            this.ultraLowLatOpt.SelectedIndexChanged += new System.EventHandler(this.UltraLowLatOpt_SelectedIndexChanged);
            // 
            // bufferSizeOpt
            // 
            this.bufferSizeOpt.BackColor = System.Drawing.SystemColors.Info;
            this.bufferSizeOpt.FormattingEnabled = true;
            this.bufferSizeOpt.Location = new System.Drawing.Point(248, 48);
            this.bufferSizeOpt.Name = "bufferSizeOpt";
            this.bufferSizeOpt.Size = new System.Drawing.Size(121, 21);
            this.bufferSizeOpt.TabIndex = 6;
            this.bufferSizeOpt.SelectedIndexChanged += new System.EventHandler(this.BufferSizeOpt_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(13, 268);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // latBuffTooltip
            // 
            this.latBuffTooltip.AutoPopDelay = 32000;
            this.latBuffTooltip.InitialDelay = 500;
            this.latBuffTooltip.ReshowDelay = 100;
            // 
            // buffSizeTooltip
            // 
            this.buffSizeTooltip.AutoPopDelay = 32000;
            this.buffSizeTooltip.InitialDelay = 500;
            this.buffSizeTooltip.ReshowDelay = 100;
            // 
            // uLLTooltip
            // 
            this.uLLTooltip.AutoPopDelay = 32000;
            this.uLLTooltip.InitialDelay = 500;
            this.uLLTooltip.ReshowDelay = 100;
            // 
            // latencyBuffText
            // 
            this.latencyBuffText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.latencyBuffText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.latencyBuffText.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.latencyBuffText.Location = new System.Drawing.Point(12, 12);
            this.latencyBuffText.Name = "latencyBuffText";
            this.latencyBuffText.ReadOnly = true;
            this.latencyBuffText.ShortcutsEnabled = false;
            this.latencyBuffText.Size = new System.Drawing.Size(76, 20);
            this.latencyBuffText.TabIndex = 0;
            this.latencyBuffText.TabStop = false;
            this.latencyBuffText.Text = "Latency Buffer";
            // 
            // readSettingsBindingSource
            // 
            this.readSettingsBindingSource.DataSource = typeof(ToggleExclusiveModeGUI.ReadSettings);
            // 
            // AdvOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(638, 303);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.bufferSizeOpt);
            this.Controls.Add(this.ultraLowLatOpt);
            this.Controls.Add(this.latencyBuffOpt);
            this.Controls.Add(this.ultraLowLatModeText);
            this.Controls.Add(this.bufferSizeText);
            this.Controls.Add(this.latencyBuffText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvOptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Options";
            ((System.ComponentModel.ISupportInitialize)(this.readSettingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox bufferSizeText;
        private System.Windows.Forms.TextBox ultraLowLatModeText;
        private System.Windows.Forms.ComboBox ultraLowLatOpt;
        private System.Windows.Forms.ComboBox bufferSizeOpt;
        private System.Windows.Forms.Button backButton;
        public System.Windows.Forms.ComboBox latencyBuffOpt;
        private System.Windows.Forms.BindingSource readSettingsBindingSource;
        private System.Windows.Forms.ToolTip latBuffTooltip;
        private System.Windows.Forms.ToolTip buffSizeTooltip;
        private System.Windows.Forms.ToolTip uLLTooltip;
        private System.Windows.Forms.TextBox latencyBuffText;
    }
}