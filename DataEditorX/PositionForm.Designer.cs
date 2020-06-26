namespace DataEditorX
{
    partial class LocationForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkLocationDeck0x1 = new System.Windows.Forms.CheckBox();
            this.checkLocationHand0x2 = new System.Windows.Forms.CheckBox();
            this.checkLocationMZone0x4 = new System.Windows.Forms.CheckBox();
            this.checkLocationSZone0x8 = new System.Windows.Forms.CheckBox();
            this.checkLocationGrave0x10 = new System.Windows.Forms.CheckBox();
            this.checkLocationRemoved0x20 = new System.Windows.Forms.CheckBox();
            this.checkLocationExtra0x40 = new System.Windows.Forms.CheckBox();
            this.checkLocationOverlay0x80 = new System.Windows.Forms.CheckBox();
            this.checkMZoneAndSZone = new System.Windows.Forms.CheckBox();
            this.checkLocationDeckbot0x10000 = new System.Windows.Forms.CheckBox();
            this.checkLocationDeckShf0x20000 = new System.Windows.Forms.CheckBox();
            this.checkLocationFZone0x100 = new System.Windows.Forms.CheckBox();
            this.checkLocationPendulum0x200 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(271, 67);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // checkLocationDeck0x1
            // 
            this.checkLocationDeck0x1.AutoSize = true;
            this.checkLocationDeck0x1.Location = new System.Drawing.Point(12, 12);
            this.checkLocationDeck0x1.Name = "checkLocationDeck0x1";
            this.checkLocationDeck0x1.Size = new System.Drawing.Size(48, 16);
            this.checkLocationDeck0x1.TabIndex = 2;
            this.checkLocationDeck0x1.Text = "卡组";
            this.checkLocationDeck0x1.UseVisualStyleBackColor = true;
            // 
            // checkLocationHand0x2
            // 
            this.checkLocationHand0x2.AutoSize = true;
            this.checkLocationHand0x2.Location = new System.Drawing.Point(66, 12);
            this.checkLocationHand0x2.Name = "checkLocationHand0x2";
            this.checkLocationHand0x2.Size = new System.Drawing.Size(48, 16);
            this.checkLocationHand0x2.TabIndex = 3;
            this.checkLocationHand0x2.Text = "手卡";
            this.checkLocationHand0x2.UseVisualStyleBackColor = true;
            // 
            // checkLocationMZone0x4
            // 
            this.checkLocationMZone0x4.AutoSize = true;
            this.checkLocationMZone0x4.Location = new System.Drawing.Point(120, 12);
            this.checkLocationMZone0x4.Name = "checkLocationMZone0x4";
            this.checkLocationMZone0x4.Size = new System.Drawing.Size(72, 16);
            this.checkLocationMZone0x4.TabIndex = 4;
            this.checkLocationMZone0x4.Text = "怪兽区域";
            this.checkLocationMZone0x4.UseVisualStyleBackColor = true;
            this.checkLocationMZone0x4.CheckedChanged += new System.EventHandler(this.checkLocationMZone0x4_CheckedChanged);
            // 
            // checkLocationSZone0x8
            // 
            this.checkLocationSZone0x8.AutoSize = true;
            this.checkLocationSZone0x8.Location = new System.Drawing.Point(198, 12);
            this.checkLocationSZone0x8.Name = "checkLocationSZone0x8";
            this.checkLocationSZone0x8.Size = new System.Drawing.Size(156, 16);
            this.checkLocationSZone0x8.TabIndex = 5;
            this.checkLocationSZone0x8.Text = "魔法陷阱区域(含场地区)";
            this.checkLocationSZone0x8.UseVisualStyleBackColor = true;
            this.checkLocationSZone0x8.CheckedChanged += new System.EventHandler(this.checkLocationSZone0x8_CheckedChanged);
            // 
            // checkLocationGrave0x10
            // 
            this.checkLocationGrave0x10.AutoSize = true;
            this.checkLocationGrave0x10.Location = new System.Drawing.Point(12, 34);
            this.checkLocationGrave0x10.Name = "checkLocationGrave0x10";
            this.checkLocationGrave0x10.Size = new System.Drawing.Size(48, 16);
            this.checkLocationGrave0x10.TabIndex = 6;
            this.checkLocationGrave0x10.Text = "墓地";
            this.checkLocationGrave0x10.UseVisualStyleBackColor = true;
            // 
            // checkLocationRemoved0x20
            // 
            this.checkLocationRemoved0x20.AutoSize = true;
            this.checkLocationRemoved0x20.Location = new System.Drawing.Point(66, 34);
            this.checkLocationRemoved0x20.Name = "checkLocationRemoved0x20";
            this.checkLocationRemoved0x20.Size = new System.Drawing.Size(60, 16);
            this.checkLocationRemoved0x20.TabIndex = 7;
            this.checkLocationRemoved0x20.Text = "除外区";
            this.checkLocationRemoved0x20.UseVisualStyleBackColor = true;
            // 
            // checkLocationExtra0x40
            // 
            this.checkLocationExtra0x40.AutoSize = true;
            this.checkLocationExtra0x40.Location = new System.Drawing.Point(132, 34);
            this.checkLocationExtra0x40.Name = "checkLocationExtra0x40";
            this.checkLocationExtra0x40.Size = new System.Drawing.Size(60, 16);
            this.checkLocationExtra0x40.TabIndex = 8;
            this.checkLocationExtra0x40.Text = "除外区";
            this.checkLocationExtra0x40.UseVisualStyleBackColor = true;
            // 
            // checkLocationOverlay0x80
            // 
            this.checkLocationOverlay0x80.AutoSize = true;
            this.checkLocationOverlay0x80.Location = new System.Drawing.Point(198, 34);
            this.checkLocationOverlay0x80.Name = "checkLocationOverlay0x80";
            this.checkLocationOverlay0x80.Size = new System.Drawing.Size(66, 16);
            this.checkLocationOverlay0x80.TabIndex = 9;
            this.checkLocationOverlay0x80.Text = "XYZ素材";
            this.checkLocationOverlay0x80.UseVisualStyleBackColor = true;
            // 
            // checkMZoneAndSZone
            // 
            this.checkMZoneAndSZone.AutoSize = true;
            this.checkMZoneAndSZone.Location = new System.Drawing.Point(12, 56);
            this.checkMZoneAndSZone.Name = "checkMZoneAndSZone";
            this.checkMZoneAndSZone.Size = new System.Drawing.Size(48, 16);
            this.checkMZoneAndSZone.TabIndex = 10;
            this.checkMZoneAndSZone.Text = "场上";
            this.checkMZoneAndSZone.UseVisualStyleBackColor = true;
            this.checkMZoneAndSZone.CheckedChanged += new System.EventHandler(this.checkMZoneAndSZone_CheckedChanged);
            // 
            // checkLocationDeckbot0x10000
            // 
            this.checkLocationDeckbot0x10000.AutoSize = true;
            this.checkLocationDeckbot0x10000.Location = new System.Drawing.Point(12, 78);
            this.checkLocationDeckbot0x10000.Name = "checkLocationDeckbot0x10000";
            this.checkLocationDeckbot0x10000.Size = new System.Drawing.Size(192, 16);
            this.checkLocationDeckbot0x10000.TabIndex = 11;
            this.checkLocationDeckbot0x10000.Text = "卡组底部(仅用于重定向类效果)";
            this.checkLocationDeckbot0x10000.UseVisualStyleBackColor = true;
            // 
            // checkLocationDeckShf0x20000
            // 
            this.checkLocationDeckShf0x20000.AutoSize = true;
            this.checkLocationDeckShf0x20000.Location = new System.Drawing.Point(12, 100);
            this.checkLocationDeckShf0x20000.Name = "checkLocationDeckShf0x20000";
            this.checkLocationDeckShf0x20000.Size = new System.Drawing.Size(198, 16);
            this.checkLocationDeckShf0x20000.TabIndex = 12;
            this.checkLocationDeckShf0x20000.Text = "卡组-洗牌(仅用于重定向类效果)";
            this.checkLocationDeckShf0x20000.UseVisualStyleBackColor = true;
            // 
            // checkLocationFZone0x100
            // 
            this.checkLocationFZone0x100.AutoSize = true;
            this.checkLocationFZone0x100.Location = new System.Drawing.Point(66, 56);
            this.checkLocationFZone0x100.Name = "checkLocationFZone0x100";
            this.checkLocationFZone0x100.Size = new System.Drawing.Size(72, 16);
            this.checkLocationFZone0x100.TabIndex = 13;
            this.checkLocationFZone0x100.Text = "场地区域";
            this.checkLocationFZone0x100.UseVisualStyleBackColor = true;
            // 
            // checkLocationPendulum0x200
            // 
            this.checkLocationPendulum0x200.AutoSize = true;
            this.checkLocationPendulum0x200.Location = new System.Drawing.Point(144, 56);
            this.checkLocationPendulum0x200.Name = "checkLocationPendulum0x200";
            this.checkLocationPendulum0x200.Size = new System.Drawing.Size(72, 16);
            this.checkLocationPendulum0x200.TabIndex = 14;
            this.checkLocationPendulum0x200.Text = "灵摆区域";
            this.checkLocationPendulum0x200.UseVisualStyleBackColor = true;
            // 
            // PositionForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(358, 131);
            this.Controls.Add(this.checkLocationPendulum0x200);
            this.Controls.Add(this.checkLocationFZone0x100);
            this.Controls.Add(this.checkLocationDeckShf0x20000);
            this.Controls.Add(this.checkLocationDeckbot0x10000);
            this.Controls.Add(this.checkMZoneAndSZone);
            this.Controls.Add(this.checkLocationOverlay0x80);
            this.Controls.Add(this.checkLocationExtra0x40);
            this.Controls.Add(this.checkLocationRemoved0x20);
            this.Controls.Add(this.checkLocationGrave0x10);
            this.Controls.Add(this.checkLocationSZone0x8);
            this.Controls.Add(this.checkLocationMZone0x4);
            this.Controls.Add(this.checkLocationHand0x2);
            this.Controls.Add(this.checkLocationDeck0x1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "位置设定";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkLocationDeck0x1;
        private System.Windows.Forms.CheckBox checkLocationHand0x2;
        private System.Windows.Forms.CheckBox checkLocationMZone0x4;
        private System.Windows.Forms.CheckBox checkLocationSZone0x8;
        private System.Windows.Forms.CheckBox checkLocationGrave0x10;
        private System.Windows.Forms.CheckBox checkLocationRemoved0x20;
        private System.Windows.Forms.CheckBox checkLocationExtra0x40;
        private System.Windows.Forms.CheckBox checkLocationOverlay0x80;
        private System.Windows.Forms.CheckBox checkMZoneAndSZone;
        private System.Windows.Forms.CheckBox checkLocationDeckbot0x10000;
        private System.Windows.Forms.CheckBox checkLocationDeckShf0x20000;
        private System.Windows.Forms.CheckBox checkLocationFZone0x100;
        private System.Windows.Forms.CheckBox checkLocationPendulum0x200;
    }
}