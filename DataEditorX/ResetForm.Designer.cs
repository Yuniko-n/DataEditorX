namespace DataEditorX
{
    partial class ResetForm
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
            this.checkResetPhase = new System.Windows.Forms.CheckBox();
            this.checkResetEvent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkResetPhase
            // 
            this.checkResetPhase.AutoSize = true;
            this.checkResetPhase.Location = new System.Drawing.Point(12, 12);
            this.checkResetPhase.Name = "checkResetPhase";
            this.checkResetPhase.Size = new System.Drawing.Size(108, 16);
            this.checkResetPhase.TabIndex = 0;
            this.checkResetPhase.Text = "阶段结束时消失";
            this.checkResetPhase.UseVisualStyleBackColor = true;
            // 
            // checkResetEvent
            // 
            this.checkResetEvent.AutoSize = true;
            this.checkResetEvent.Location = new System.Drawing.Point(12, 170);
            this.checkResetEvent.Name = "checkResetEvent";
            this.checkResetEvent.Size = new System.Drawing.Size(108, 16);
            this.checkResetEvent.TabIndex = 1;
            this.checkResetEvent.Text = "发生事件时消失";
            this.checkResetEvent.UseVisualStyleBackColor = true;
            // 
            // ResetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 290);
            this.Controls.Add(this.checkResetEvent);
            this.Controls.Add(this.checkResetPhase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "效果消失设定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkResetPhase;
        private System.Windows.Forms.CheckBox checkResetEvent;
    }
}