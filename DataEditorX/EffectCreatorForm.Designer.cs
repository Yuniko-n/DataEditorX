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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.listEffectCode = new System.Windows.Forms.CheckedListBox();
            this.gbSpecialOptions = new System.Windows.Forms.GroupBox();
            this.checkRegisterToPlayer = new System.Windows.Forms.CheckBox();
            this.checkEnableReviveLimit = new System.Windows.Forms.CheckBox();
            this.gbEffectType = new System.Windows.Forms.GroupBox();
            this.radioEffectTypeField = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeSingle = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearchEffectCode = new System.Windows.Forms.TextBox();
            this.gbEffectType2 = new System.Windows.Forms.GroupBox();
            this.radio_EffectTypeNone = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeTarget = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeGrant = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeXMaterial = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeContinuous = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeQuick_F = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeQuick_O = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeTrigger_F = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeTrigger_O = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeIgnition = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeFlip = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeActivate = new System.Windows.Forms.RadioButton();
            this.radioEffectTypeEquip = new System.Windows.Forms.RadioButton();
            this.相关函数 = new System.Windows.Forms.GroupBox();
            this.checkOperation = new System.Windows.Forms.CheckBox();
            this.checkCost = new System.Windows.Forms.CheckBox();
            this.checkTarget = new System.Windows.Forms.CheckBox();
            this.checkCondition = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkTargetRange = new System.Windows.Forms.CheckBox();
            this.checkRange = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkHintTiming = new System.Windows.Forms.CheckBox();
            this.checkReset = new System.Windows.Forms.CheckBox();
            this.checkCountLimit = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSearchEffectCategory = new System.Windows.Forms.TextBox();
            this.listEffectCategory = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numCardCode = new System.Windows.Forms.NumericUpDown();
            this.numDescription = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numEffectNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtSearchProperty = new System.Windows.Forms.TextBox();
            this.listEffectProperty = new System.Windows.Forms.CheckedListBox();
            this.numFunctionNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gbSpecialOptions.SuspendLayout();
            this.gbEffectType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbEffectType2.SuspendLayout();
            this.相关函数.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCardCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEffectNum)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFunctionNum)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(721, 238);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(280, 260);
            this.txtOutput.TabIndex = 0;
            // 
            // listEffectCode
            // 
            this.listEffectCode.CheckOnClick = true;
            this.listEffectCode.FormattingEnabled = true;
            this.listEffectCode.Location = new System.Drawing.Point(6, 52);
            this.listEffectCode.Name = "listEffectCode";
            this.listEffectCode.Size = new System.Drawing.Size(268, 116);
            this.listEffectCode.TabIndex = 1;
            this.listEffectCode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listEffectCode_ItemCheck);
            // 
            // gbSpecialOptions
            // 
            this.gbSpecialOptions.Controls.Add(this.checkRegisterToPlayer);
            this.gbSpecialOptions.Controls.Add(this.checkEnableReviveLimit);
            this.gbSpecialOptions.Location = new System.Drawing.Point(12, 56);
            this.gbSpecialOptions.Name = "gbSpecialOptions";
            this.gbSpecialOptions.Size = new System.Drawing.Size(150, 68);
            this.gbSpecialOptions.TabIndex = 2;
            this.gbSpecialOptions.TabStop = false;
            this.gbSpecialOptions.Text = "特殊选项";
            // 
            // checkRegisterToPlayer
            // 
            this.checkRegisterToPlayer.AutoSize = true;
            this.checkRegisterToPlayer.Location = new System.Drawing.Point(7, 43);
            this.checkRegisterToPlayer.Name = "checkRegisterToPlayer";
            this.checkRegisterToPlayer.Size = new System.Drawing.Size(132, 16);
            this.checkRegisterToPlayer.TabIndex = 1;
            this.checkRegisterToPlayer.Text = "注册给玩家而非卡片";
            this.checkRegisterToPlayer.UseVisualStyleBackColor = true;
            // 
            // checkEnableReviveLimit
            // 
            this.checkEnableReviveLimit.AutoSize = true;
            this.checkEnableReviveLimit.Location = new System.Drawing.Point(7, 21);
            this.checkEnableReviveLimit.Name = "checkEnableReviveLimit";
            this.checkEnableReviveLimit.Size = new System.Drawing.Size(132, 16);
            this.checkEnableReviveLimit.TabIndex = 0;
            this.checkEnableReviveLimit.Text = "这张卡不能通常召唤";
            this.checkEnableReviveLimit.UseVisualStyleBackColor = true;
            // 
            // gbEffectType
            // 
            this.gbEffectType.Controls.Add(this.radioEffectTypeField);
            this.gbEffectType.Controls.Add(this.radioEffectTypeSingle);
            this.gbEffectType.Location = new System.Drawing.Point(164, 56);
            this.gbEffectType.Name = "gbEffectType";
            this.gbEffectType.Size = new System.Drawing.Size(261, 68);
            this.gbEffectType.TabIndex = 3;
            this.gbEffectType.TabStop = false;
            this.gbEffectType.Text = "作用范围";
            // 
            // radioEffectTypeField
            // 
            this.radioEffectTypeField.AutoSize = true;
            this.radioEffectTypeField.Location = new System.Drawing.Point(6, 43);
            this.radioEffectTypeField.Name = "radioEffectTypeField";
            this.radioEffectTypeField.Size = new System.Drawing.Size(251, 16);
            this.radioEffectTypeField.TabIndex = 1;
            this.radioEffectTypeField.Text = "对其他卡也有效，或任何卡发生事件都触发";
            this.radioEffectTypeField.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeSingle
            // 
            this.radioEffectTypeSingle.AutoSize = true;
            this.radioEffectTypeSingle.Checked = true;
            this.radioEffectTypeSingle.Location = new System.Drawing.Point(6, 21);
            this.radioEffectTypeSingle.Name = "radioEffectTypeSingle";
            this.radioEffectTypeSingle.Size = new System.Drawing.Size(251, 16);
            this.radioEffectTypeSingle.TabIndex = 0;
            this.radioEffectTypeSingle.TabStop = true;
            this.radioEffectTypeSingle.Text = "只对自己有效，或只有自身状态变化时触发";
            this.radioEffectTypeSingle.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearchEffectCode);
            this.groupBox1.Controls.Add(this.listEffectCode);
            this.groupBox1.Location = new System.Drawing.Point(435, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 174);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "效果类型或触发时机";
            // 
            // txtSearchEffectCode
            // 
            this.txtSearchEffectCode.Location = new System.Drawing.Point(6, 20);
            this.txtSearchEffectCode.Name = "txtSearchEffectCode";
            this.txtSearchEffectCode.Size = new System.Drawing.Size(268, 21);
            this.txtSearchEffectCode.TabIndex = 2;
            this.txtSearchEffectCode.TextChanged += new System.EventHandler(this.txtSearchEffectCode_TextChanged);
            // 
            // gbEffectType2
            // 
            this.gbEffectType2.Controls.Add(this.radio_EffectTypeNone);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeTarget);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeGrant);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeXMaterial);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeContinuous);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeQuick_F);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeQuick_O);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeTrigger_F);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeTrigger_O);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeIgnition);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeFlip);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeActivate);
            this.gbEffectType2.Controls.Add(this.radioEffectTypeEquip);
            this.gbEffectType2.Location = new System.Drawing.Point(12, 130);
            this.gbEffectType2.Name = "gbEffectType2";
            this.gbEffectType2.Size = new System.Drawing.Size(413, 157);
            this.gbEffectType2.TabIndex = 4;
            this.gbEffectType2.TabStop = false;
            this.gbEffectType2.Text = "效果分类";
            // 
            // radio_EffectTypeNone
            // 
            this.radio_EffectTypeNone.AutoSize = true;
            this.radio_EffectTypeNone.Checked = true;
            this.radio_EffectTypeNone.Location = new System.Drawing.Point(336, 94);
            this.radio_EffectTypeNone.Name = "radio_EffectTypeNone";
            this.radio_EffectTypeNone.Size = new System.Drawing.Size(71, 16);
            this.radio_EffectTypeNone.TabIndex = 12;
            this.radio_EffectTypeNone.TabStop = true;
            this.radio_EffectTypeNone.Text = "永续效果";
            this.radio_EffectTypeNone.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeTarget
            // 
            this.radioEffectTypeTarget.AutoSize = true;
            this.radioEffectTypeTarget.Location = new System.Drawing.Point(7, 130);
            this.radioEffectTypeTarget.Name = "radioEffectTypeTarget";
            this.radioEffectTypeTarget.Size = new System.Drawing.Size(167, 16);
            this.radioEffectTypeTarget.TabIndex = 11;
            this.radioEffectTypeTarget.Text = "持续取对象的卡获得的效果";
            this.radioEffectTypeTarget.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeGrant
            // 
            this.radioEffectTypeGrant.AutoSize = true;
            this.radioEffectTypeGrant.Location = new System.Drawing.Point(184, 130);
            this.radioEffectTypeGrant.Name = "radioEffectTypeGrant";
            this.radioEffectTypeGrant.Size = new System.Drawing.Size(155, 16);
            this.radioEffectTypeGrant.TabIndex = 10;
            this.radioEffectTypeGrant.Text = "让其他卡获得效果的效果";
            this.radioEffectTypeGrant.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeXMaterial
            // 
            this.radioEffectTypeXMaterial.AutoSize = true;
            this.radioEffectTypeXMaterial.Location = new System.Drawing.Point(6, 108);
            this.radioEffectTypeXMaterial.Name = "radioEffectTypeXMaterial";
            this.radioEffectTypeXMaterial.Size = new System.Drawing.Size(233, 16);
            this.radioEffectTypeXMaterial.TabIndex = 9;
            this.radioEffectTypeXMaterial.Text = "作为素材使用的场合，XYZ怪兽获得效果";
            this.radioEffectTypeXMaterial.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeContinuous
            // 
            this.radioEffectTypeContinuous.AutoSize = true;
            this.radioEffectTypeContinuous.Location = new System.Drawing.Point(143, 42);
            this.radioEffectTypeContinuous.Name = "radioEffectTypeContinuous";
            this.radioEffectTypeContinuous.Size = new System.Drawing.Size(155, 16);
            this.radioEffectTypeContinuous.TabIndex = 8;
            this.radioEffectTypeContinuous.Text = "不入连锁的事件触发效果";
            this.radioEffectTypeContinuous.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeQuick_F
            // 
            this.radioEffectTypeQuick_F.AutoSize = true;
            this.radioEffectTypeQuick_F.Location = new System.Drawing.Point(6, 86);
            this.radioEffectTypeQuick_F.Name = "radioEffectTypeQuick_F";
            this.radioEffectTypeQuick_F.Size = new System.Drawing.Size(149, 16);
            this.radioEffectTypeQuick_F.TabIndex = 7;
            this.radioEffectTypeQuick_F.Text = "诱发即时必发效果(2速)";
            this.radioEffectTypeQuick_F.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeQuick_O
            // 
            this.radioEffectTypeQuick_O.AutoSize = true;
            this.radioEffectTypeQuick_O.Location = new System.Drawing.Point(158, 86);
            this.radioEffectTypeQuick_O.Name = "radioEffectTypeQuick_O";
            this.radioEffectTypeQuick_O.Size = new System.Drawing.Size(149, 16);
            this.radioEffectTypeQuick_O.TabIndex = 6;
            this.radioEffectTypeQuick_O.Text = "诱发即时选发效果(2速)";
            this.radioEffectTypeQuick_O.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeTrigger_F
            // 
            this.radioEffectTypeTrigger_F.AutoSize = true;
            this.radioEffectTypeTrigger_F.Location = new System.Drawing.Point(6, 64);
            this.radioEffectTypeTrigger_F.Name = "radioEffectTypeTrigger_F";
            this.radioEffectTypeTrigger_F.Size = new System.Drawing.Size(125, 16);
            this.radioEffectTypeTrigger_F.TabIndex = 5;
            this.radioEffectTypeTrigger_F.Text = "诱发必发效果(1速)";
            this.radioEffectTypeTrigger_F.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeTrigger_O
            // 
            this.radioEffectTypeTrigger_O.AutoSize = true;
            this.radioEffectTypeTrigger_O.Location = new System.Drawing.Point(137, 64);
            this.radioEffectTypeTrigger_O.Name = "radioEffectTypeTrigger_O";
            this.radioEffectTypeTrigger_O.Size = new System.Drawing.Size(125, 16);
            this.radioEffectTypeTrigger_O.TabIndex = 4;
            this.radioEffectTypeTrigger_O.Text = "诱发选发效果(1速)";
            this.radioEffectTypeTrigger_O.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeIgnition
            // 
            this.radioEffectTypeIgnition.AutoSize = true;
            this.radioEffectTypeIgnition.Location = new System.Drawing.Point(336, 64);
            this.radioEffectTypeIgnition.Name = "radioEffectTypeIgnition";
            this.radioEffectTypeIgnition.Size = new System.Drawing.Size(71, 16);
            this.radioEffectTypeIgnition.TabIndex = 3;
            this.radioEffectTypeIgnition.Text = "起动效果";
            this.radioEffectTypeIgnition.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeFlip
            // 
            this.radioEffectTypeFlip.AutoSize = true;
            this.radioEffectTypeFlip.Location = new System.Drawing.Point(6, 42);
            this.radioEffectTypeFlip.Name = "radioEffectTypeFlip";
            this.radioEffectTypeFlip.Size = new System.Drawing.Size(131, 16);
            this.radioEffectTypeFlip.TabIndex = 2;
            this.radioEffectTypeFlip.Text = "反转怪兽的反转效果";
            this.radioEffectTypeFlip.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeActivate
            // 
            this.radioEffectTypeActivate.AutoSize = true;
            this.radioEffectTypeActivate.Location = new System.Drawing.Point(167, 20);
            this.radioEffectTypeActivate.Name = "radioEffectTypeActivate";
            this.radioEffectTypeActivate.Size = new System.Drawing.Size(215, 16);
            this.radioEffectTypeActivate.TabIndex = 1;
            this.radioEffectTypeActivate.Text = "魔法陷阱卡从手卡往场上放置并发动";
            this.radioEffectTypeActivate.UseVisualStyleBackColor = true;
            // 
            // radioEffectTypeEquip
            // 
            this.radioEffectTypeEquip.AutoSize = true;
            this.radioEffectTypeEquip.Location = new System.Drawing.Point(6, 20);
            this.radioEffectTypeEquip.Name = "radioEffectTypeEquip";
            this.radioEffectTypeEquip.Size = new System.Drawing.Size(155, 16);
            this.radioEffectTypeEquip.TabIndex = 0;
            this.radioEffectTypeEquip.Text = "装备给其他卡时产生效果";
            this.radioEffectTypeEquip.UseVisualStyleBackColor = true;
            // 
            // 相关函数
            // 
            this.相关函数.Controls.Add(this.checkOperation);
            this.相关函数.Controls.Add(this.checkCost);
            this.相关函数.Controls.Add(this.checkTarget);
            this.相关函数.Controls.Add(this.checkCondition);
            this.相关函数.Location = new System.Drawing.Point(12, 387);
            this.相关函数.Name = "相关函数";
            this.相关函数.Size = new System.Drawing.Size(413, 111);
            this.相关函数.TabIndex = 5;
            this.相关函数.TabStop = false;
            this.相关函数.Text = "效果处理相关2";
            // 
            // checkOperation
            // 
            this.checkOperation.AutoSize = true;
            this.checkOperation.Location = new System.Drawing.Point(6, 86);
            this.checkOperation.Name = "checkOperation";
            this.checkOperation.Size = new System.Drawing.Size(186, 16);
            this.checkOperation.TabIndex = 3;
            this.checkOperation.Text = "有Operation(发动后具体动作)";
            this.checkOperation.UseVisualStyleBackColor = true;
            // 
            // checkCost
            // 
            this.checkCost.AutoSize = true;
            this.checkCost.Location = new System.Drawing.Point(6, 42);
            this.checkCost.Name = "checkCost";
            this.checkCost.Size = new System.Drawing.Size(216, 16);
            this.checkCost.TabIndex = 2;
            this.checkCost.Text = "有Cost(发动条件，被复制后不检查)";
            this.checkCost.UseVisualStyleBackColor = true;
            // 
            // checkTarget
            // 
            this.checkTarget.AutoSize = true;
            this.checkTarget.Location = new System.Drawing.Point(6, 64);
            this.checkTarget.Name = "checkTarget";
            this.checkTarget.Size = new System.Drawing.Size(240, 16);
            this.checkTarget.TabIndex = 1;
            this.checkTarget.Text = "有Target(防止空发，被复制后也要检查)";
            this.checkTarget.UseVisualStyleBackColor = true;
            // 
            // checkCondition
            // 
            this.checkCondition.AutoSize = true;
            this.checkCondition.Location = new System.Drawing.Point(6, 20);
            this.checkCondition.Name = "checkCondition";
            this.checkCondition.Size = new System.Drawing.Size(246, 16);
            this.checkCondition.TabIndex = 0;
            this.checkCondition.Text = "有Condition(发动前提，被复制后不检查)";
            this.checkCondition.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.checkTargetRange);
            this.groupBox3.Controls.Add(this.checkRange);
            this.groupBox3.Location = new System.Drawing.Point(435, 387);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 111);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "效果处理相关3";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 64);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(186, 16);
            this.checkBox6.TabIndex = 3;
            this.checkBox6.Text = "有Operation(发动后具体动作)";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkTargetRange
            // 
            this.checkTargetRange.AutoSize = true;
            this.checkTargetRange.Location = new System.Drawing.Point(6, 42);
            this.checkTargetRange.Name = "checkTargetRange";
            this.checkTargetRange.Size = new System.Drawing.Size(162, 16);
            this.checkTargetRange.TabIndex = 2;
            this.checkTargetRange.Text = "有TargetRange(影响范围)";
            this.checkTargetRange.UseVisualStyleBackColor = true;
            // 
            // checkRange
            // 
            this.checkRange.AutoSize = true;
            this.checkRange.Location = new System.Drawing.Point(6, 20);
            this.checkRange.Name = "checkRange";
            this.checkRange.Size = new System.Drawing.Size(198, 16);
            this.checkRange.TabIndex = 0;
            this.checkRange.Text = "有Range(位于某些位置才能发动)";
            this.checkRange.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkHintTiming);
            this.groupBox4.Controls.Add(this.checkReset);
            this.groupBox4.Controls.Add(this.checkCountLimit);
            this.groupBox4.Location = new System.Drawing.Point(12, 293);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(413, 88);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "效果处理相关1";
            // 
            // checkHintTiming
            // 
            this.checkHintTiming.AutoSize = true;
            this.checkHintTiming.Location = new System.Drawing.Point(10, 64);
            this.checkHintTiming.Name = "checkHintTiming";
            this.checkHintTiming.Size = new System.Drawing.Size(276, 16);
            this.checkHintTiming.TabIndex = 3;
            this.checkHintTiming.Text = "某些额外时点要询问玩家是否发动(HintTiming)";
            this.checkHintTiming.UseVisualStyleBackColor = true;
            // 
            // checkReset
            // 
            this.checkReset.AutoSize = true;
            this.checkReset.Location = new System.Drawing.Point(10, 42);
            this.checkReset.Name = "checkReset";
            this.checkReset.Size = new System.Drawing.Size(246, 16);
            this.checkReset.TabIndex = 2;
            this.checkReset.Text = "这个效果在满足某种条件后会消失(Reset)";
            this.checkReset.UseVisualStyleBackColor = true;
            this.checkReset.CheckedChanged += new System.EventHandler(this.checkReset_CheckedChanged);
            // 
            // checkCountLimit
            // 
            this.checkCountLimit.AutoSize = true;
            this.checkCountLimit.Location = new System.Drawing.Point(10, 20);
            this.checkCountLimit.Name = "checkCountLimit";
            this.checkCountLimit.Size = new System.Drawing.Size(198, 16);
            this.checkCountLimit.TabIndex = 1;
            this.checkCountLimit.Text = "每回合最多使用X次(CountLimit)";
            this.checkCountLimit.UseVisualStyleBackColor = true;
            this.checkCountLimit.CheckedChanged += new System.EventHandler(this.checkCountLimit_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSearchEffectCategory);
            this.groupBox5.Controls.Add(this.listEffectCategory);
            this.groupBox5.Location = new System.Drawing.Point(721, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 174);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "效果分类";
            // 
            // txtSearchEffectCategory
            // 
            this.txtSearchEffectCategory.Location = new System.Drawing.Point(6, 20);
            this.txtSearchEffectCategory.Name = "txtSearchEffectCategory";
            this.txtSearchEffectCategory.Size = new System.Drawing.Size(268, 21);
            this.txtSearchEffectCategory.TabIndex = 2;
            this.txtSearchEffectCategory.TextChanged += new System.EventHandler(this.txtSearchEffectCategory_TextChanged);
            // 
            // listEffectCategory
            // 
            this.listEffectCategory.CheckOnClick = true;
            this.listEffectCategory.FormattingEnabled = true;
            this.listEffectCategory.Location = new System.Drawing.Point(6, 52);
            this.listEffectCategory.Name = "listEffectCategory";
            this.listEffectCategory.Size = new System.Drawing.Size(268, 116);
            this.listEffectCategory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "卡片代码";
            // 
            // numCardCode
            // 
            this.numCardCode.Location = new System.Drawing.Point(12, 29);
            this.numCardCode.Maximum = new decimal(new int[] {
            268435455,
            0,
            0,
            0});
            this.numCardCode.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCardCode.Name = "numCardCode";
            this.numCardCode.Size = new System.Drawing.Size(98, 21);
            this.numCardCode.TabIndex = 10;
            this.numCardCode.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numDescription
            // 
            this.numDescription.Location = new System.Drawing.Point(116, 29);
            this.numDescription.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numDescription.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numDescription.Name = "numDescription";
            this.numDescription.Size = new System.Drawing.Size(70, 21);
            this.numDescription.TabIndex = 12;
            this.numDescription.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "描述(-1禁用)";
            // 
            // numEffectNum
            // 
            this.numEffectNum.Location = new System.Drawing.Point(192, 29);
            this.numEffectNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEffectNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEffectNum.Name = "numEffectNum";
            this.numEffectNum.Size = new System.Drawing.Size(63, 21);
            this.numEffectNum.TabIndex = 14;
            this.numEffectNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "效果识别码";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(721, 196);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(277, 36);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "生成效果";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtSearchProperty);
            this.groupBox6.Controls.Add(this.listEffectProperty);
            this.groupBox6.Location = new System.Drawing.Point(435, 199);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(280, 182);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "额外选项";
            // 
            // txtSearchProperty
            // 
            this.txtSearchProperty.Location = new System.Drawing.Point(6, 20);
            this.txtSearchProperty.Name = "txtSearchProperty";
            this.txtSearchProperty.Size = new System.Drawing.Size(268, 21);
            this.txtSearchProperty.TabIndex = 2;
            this.txtSearchProperty.TextChanged += new System.EventHandler(this.txtSearchProperty_TextChanged);
            // 
            // listEffectProperty
            // 
            this.listEffectProperty.CheckOnClick = true;
            this.listEffectProperty.FormattingEnabled = true;
            this.listEffectProperty.Location = new System.Drawing.Point(6, 52);
            this.listEffectProperty.Name = "listEffectProperty";
            this.listEffectProperty.Size = new System.Drawing.Size(268, 116);
            this.listEffectProperty.TabIndex = 1;
            // 
            // numFunctionNum
            // 
            this.numFunctionNum.Location = new System.Drawing.Point(261, 29);
            this.numFunctionNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFunctionNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numFunctionNum.Name = "numFunctionNum";
            this.numFunctionNum.Size = new System.Drawing.Size(63, 21);
            this.numFunctionNum.TabIndex = 18;
            this.numFunctionNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "函数识别码(-1禁用)";
            // 
            // EffectCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 510);
            this.Controls.Add(this.numFunctionNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numEffectNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numCardCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.相关函数);
            this.Controls.Add(this.gbEffectType2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbEffectType);
            this.Controls.Add(this.gbSpecialOptions);
            this.Controls.Add(this.txtOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EffectCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "效果生成器";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EffectCreatorForm_Load);
            this.gbSpecialOptions.ResumeLayout(false);
            this.gbSpecialOptions.PerformLayout();
            this.gbEffectType.ResumeLayout(false);
            this.gbEffectType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbEffectType2.ResumeLayout(false);
            this.gbEffectType2.PerformLayout();
            this.相关函数.ResumeLayout(false);
            this.相关函数.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCardCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEffectNum)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFunctionNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckedListBox listEffectCode;
        private System.Windows.Forms.GroupBox gbSpecialOptions;
        private System.Windows.Forms.CheckBox checkEnableReviveLimit;
        private System.Windows.Forms.GroupBox gbEffectType;
        private System.Windows.Forms.CheckBox checkRegisterToPlayer;
        private System.Windows.Forms.RadioButton radioEffectTypeField;
        private System.Windows.Forms.RadioButton radioEffectTypeSingle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearchEffectCode;
        private System.Windows.Forms.GroupBox gbEffectType2;
        private System.Windows.Forms.RadioButton radioEffectTypeTarget;
        private System.Windows.Forms.RadioButton radioEffectTypeGrant;
        private System.Windows.Forms.RadioButton radioEffectTypeXMaterial;
        private System.Windows.Forms.RadioButton radioEffectTypeContinuous;
        private System.Windows.Forms.RadioButton radioEffectTypeQuick_F;
        private System.Windows.Forms.RadioButton radioEffectTypeQuick_O;
        private System.Windows.Forms.RadioButton radioEffectTypeTrigger_F;
        private System.Windows.Forms.RadioButton radioEffectTypeTrigger_O;
        private System.Windows.Forms.RadioButton radioEffectTypeIgnition;
        private System.Windows.Forms.RadioButton radioEffectTypeFlip;
        private System.Windows.Forms.RadioButton radioEffectTypeActivate;
        private System.Windows.Forms.RadioButton radioEffectTypeEquip;
        private System.Windows.Forms.GroupBox 相关函数;
        private System.Windows.Forms.CheckBox checkOperation;
        private System.Windows.Forms.CheckBox checkCost;
        private System.Windows.Forms.CheckBox checkTarget;
        private System.Windows.Forms.CheckBox checkCondition;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkTargetRange;
        private System.Windows.Forms.CheckBox checkRange;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkReset;
        private System.Windows.Forms.CheckBox checkCountLimit;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtSearchEffectCategory;
        private System.Windows.Forms.CheckedListBox listEffectCategory;
        private System.Windows.Forms.CheckBox checkHintTiming;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCardCode;
        private System.Windows.Forms.NumericUpDown numDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numEffectNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton radio_EffectTypeNone;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtSearchProperty;
        private System.Windows.Forms.CheckedListBox listEffectProperty;
        private System.Windows.Forms.NumericUpDown numFunctionNum;
        private System.Windows.Forms.Label label4;
    }
}