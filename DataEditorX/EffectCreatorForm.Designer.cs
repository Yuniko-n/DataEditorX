namespace DataEditorX
{
    partial class EffectCreatorForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listEffectCode = new System.Windows.Forms.CheckedListBox();
            this.gbSpecialOptions = new System.Windows.Forms.GroupBox();
            this.checkEnableReviveLimit = new System.Windows.Forms.CheckBox();
            this.gbEffectType = new System.Windows.Forms.GroupBox();
            this.gbSpecialOptions.SuspendLayout();
            this.gbEffectType.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(721, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 441);
            this.textBox1.TabIndex = 0;
            // 
            // listEffectCode
            // 
            this.listEffectCode.FormattingEnabled = true;
            this.listEffectCode.Location = new System.Drawing.Point(6, 20);
            this.listEffectCode.Name = "listEffectCode";
            this.listEffectCode.Size = new System.Drawing.Size(251, 132);
            this.listEffectCode.TabIndex = 1;
            // 
            // gbSpecialOptions
            // 
            this.gbSpecialOptions.Controls.Add(this.checkEnableReviveLimit);
            this.gbSpecialOptions.Location = new System.Drawing.Point(12, 12);
            this.gbSpecialOptions.Name = "gbSpecialOptions";
            this.gbSpecialOptions.Size = new System.Drawing.Size(148, 54);
            this.gbSpecialOptions.TabIndex = 2;
            this.gbSpecialOptions.TabStop = false;
            this.gbSpecialOptions.Text = "特殊选项";
            // 
            // checkEnableReviveLimit
            // 
            this.checkEnableReviveLimit.AutoSize = true;
            this.checkEnableReviveLimit.Location = new System.Drawing.Point(6, 20);
            this.checkEnableReviveLimit.Name = "checkEnableReviveLimit";
            this.checkEnableReviveLimit.Size = new System.Drawing.Size(96, 16);
            this.checkEnableReviveLimit.TabIndex = 0;
            this.checkEnableReviveLimit.Text = "开启召唤限制";
            this.checkEnableReviveLimit.UseVisualStyleBackColor = true;
            // 
            // gbEffectType
            // 
            this.gbEffectType.Controls.Add(this.listEffectCode);
            this.gbEffectType.Location = new System.Drawing.Point(166, 12);
            this.gbEffectType.Name = "gbEffectType";
            this.gbEffectType.Size = new System.Drawing.Size(263, 173);
            this.gbEffectType.TabIndex = 3;
            this.gbEffectType.TabStop = false;
            this.gbEffectType.Text = "效果种类";
            // 
            // EffectCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 465);
            this.Controls.Add(this.gbEffectType);
            this.Controls.Add(this.gbSpecialOptions);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EffectCreatorForm";
            this.TabText = "Effect Creator";
            this.Text = "Effect Creator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EffectCreatorForm_Load);
            this.gbSpecialOptions.ResumeLayout(false);
            this.gbSpecialOptions.PerformLayout();
            this.gbEffectType.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox listEffectCode;
        private System.Windows.Forms.GroupBox gbSpecialOptions;
        private System.Windows.Forms.CheckBox checkEnableReviveLimit;
        private System.Windows.Forms.GroupBox gbEffectType;
    }
}