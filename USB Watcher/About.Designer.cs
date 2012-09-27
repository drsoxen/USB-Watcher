namespace USB_Watcher
{
    partial class About
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
            this.button_OK = new System.Windows.Forms.Button();
            this.label_MainText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(48, 111);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_MainText
            // 
            this.label_MainText.AutoSize = true;
            this.label_MainText.Location = new System.Drawing.Point(13, 13);
            this.label_MainText.Name = "label_MainText";
            this.label_MainText.Size = new System.Drawing.Size(35, 13);
            this.label_MainText.TabIndex = 1;
            this.label_MainText.Text = "label1";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 146);
            this.Controls.Add(this.label_MainText);
            this.Controls.Add(this.button_OK);
            this.Icon = global::USB_Watcher.Properties.Resources.USB_Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About USB Watcher";
            this.Shown += new System.EventHandler(this.About_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();            
        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label_MainText;
    }
}