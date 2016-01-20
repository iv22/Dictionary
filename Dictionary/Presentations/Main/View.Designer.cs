namespace Dictionary
{
    partial class View
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabStart = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDictWordsCount = new System.Windows.Forms.Label();
            this.txtDictWordsCount = new System.Windows.Forms.TextBox();
            this.linkDelDictionary = new System.Windows.Forms.LinkLabel();
            this.linkAddDictionary = new System.Windows.Forms.LinkLabel();
            this.linkEditDictionary = new System.Windows.Forms.LinkLabel();
            this.cbDictionary = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkDelUser = new System.Windows.Forms.LinkLabel();
            this.linkAddUser = new System.Windows.Forms.LinkLabel();
            this.linkEditUser = new System.Windows.Forms.LinkLabel();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.gboxTestSets = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gboxTestPrioritySet = new System.Windows.Forms.GroupBox();
            this.radiobtnSeldom = new System.Windows.Forms.RadioButton();
            this.radiobtnBalanced = new System.Windows.Forms.RadioButton();
            this.radiobtnWrong = new System.Windows.Forms.RadioButton();
            this.radiobtnNew = new System.Windows.Forms.RadioButton();
            this.gboxTestWordsCount = new System.Windows.Forms.GroupBox();
            this.updownTest = new System.Windows.Forms.NumericUpDown();
            this.gboxTestTimeSet = new System.Windows.Forms.GroupBox();
            this.radiobtnShort = new System.Windows.Forms.RadioButton();
            this.radiobtnMiddle = new System.Windows.Forms.RadioButton();
            this.radiobtnLong = new System.Windows.Forms.RadioButton();
            this.chboxTestPreview = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabDictionary = new System.Windows.Forms.TabPage();
            this.panelDictionary = new System.Windows.Forms.Panel();
            this.gBoxWord = new System.Windows.Forms.GroupBox();
            this.chBoxKnowing = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imgListEditors = new System.Windows.Forms.ImageList(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTranslate = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.gridDictionary = new System.Windows.Forms.DataGridView();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Translate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Test_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attempts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Per_hit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_knowing = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cntMenuDictionary = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.gboxChartDict = new System.Windows.Forms.GroupBox();
            this.tabMain.SuspendLayout();
            this.tabStart.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxTestSets.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gboxTestPrioritySet.SuspendLayout();
            this.gboxTestWordsCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownTest)).BeginInit();
            this.gboxTestTimeSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDictionary.SuspendLayout();
            this.panelDictionary.SuspendLayout();
            this.gBoxWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDictionary)).BeginInit();
            this.cntMenuDictionary.SuspendLayout();
            this.tabStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabStart);
            this.tabMain.Controls.Add(this.tabDictionary);
            this.tabMain.Controls.Add(this.tabStatistics);
            this.tabMain.Location = new System.Drawing.Point(1, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(964, 501);
            this.tabMain.TabIndex = 5;
            // 
            // tabStart
            // 
            this.tabStart.Controls.Add(this.tableLayoutPanel1);
            this.tabStart.Location = new System.Drawing.Point(4, 22);
            this.tabStart.Name = "tabStart";
            this.tabStart.Padding = new System.Windows.Forms.Padding(3);
            this.tabStart.Size = new System.Drawing.Size(956, 475);
            this.tabStart.TabIndex = 0;
            this.tabStart.Text = "Текущие настройки";
            this.tabStart.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTest, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gboxTestSets, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 469);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblDictWordsCount);
            this.groupBox2.Controls.Add(this.txtDictWordsCount);
            this.groupBox2.Controls.Add(this.linkDelDictionary);
            this.groupBox2.Controls.Add(this.linkAddDictionary);
            this.groupBox2.Controls.Add(this.linkEditDictionary);
            this.groupBox2.Controls.Add(this.cbDictionary);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(288, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 104);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Словари";
            // 
            // lblDictWordsCount
            // 
            this.lblDictWordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDictWordsCount.AutoSize = true;
            this.lblDictWordsCount.Location = new System.Drawing.Point(35, 82);
            this.lblDictWordsCount.Name = "lblDictWordsCount";
            this.lblDictWordsCount.Size = new System.Drawing.Size(121, 13);
            this.lblDictWordsCount.TabIndex = 18;
            this.lblDictWordsCount.Text = "Всего слов в словаре:";
            // 
            // txtDictWordsCount
            // 
            this.txtDictWordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDictWordsCount.Enabled = false;
            this.txtDictWordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDictWordsCount.Location = new System.Drawing.Point(162, 75);
            this.txtDictWordsCount.Name = "txtDictWordsCount";
            this.txtDictWordsCount.Size = new System.Drawing.Size(100, 20);
            this.txtDictWordsCount.TabIndex = 17;
            // 
            // linkDelDictionary
            // 
            this.linkDelDictionary.AutoSize = true;
            this.linkDelDictionary.Location = new System.Drawing.Point(215, 43);
            this.linkDelDictionary.Name = "linkDelDictionary";
            this.linkDelDictionary.Size = new System.Drawing.Size(47, 13);
            this.linkDelDictionary.TabIndex = 16;
            this.linkDelDictionary.TabStop = true;
            this.linkDelDictionary.Text = "удалить";
            this.linkDelDictionary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDelDictionary_LinkClicked);
            // 
            // linkAddDictionary
            // 
            this.linkAddDictionary.AutoSize = true;
            this.linkAddDictionary.Location = new System.Drawing.Point(95, 43);
            this.linkAddDictionary.Name = "linkAddDictionary";
            this.linkAddDictionary.Size = new System.Drawing.Size(48, 13);
            this.linkAddDictionary.TabIndex = 15;
            this.linkAddDictionary.TabStop = true;
            this.linkAddDictionary.Text = "создать";
            this.linkAddDictionary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddDictionary_LinkClicked);
            // 
            // linkEditDictionary
            // 
            this.linkEditDictionary.AutoSize = true;
            this.linkEditDictionary.Location = new System.Drawing.Point(6, 43);
            this.linkEditDictionary.Name = "linkEditDictionary";
            this.linkEditDictionary.Size = new System.Drawing.Size(83, 13);
            this.linkEditDictionary.TabIndex = 14;
            this.linkEditDictionary.TabStop = true;
            this.linkEditDictionary.Text = "редактировать";
            this.linkEditDictionary.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkEditDictionary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditDictionary_LinkClicked);
            // 
            // cbDictionary
            // 
            this.cbDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDictionary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDictionary.Location = new System.Drawing.Point(6, 19);
            this.cbDictionary.Name = "cbDictionary";
            this.cbDictionary.Size = new System.Drawing.Size(256, 21);
            this.cbDictionary.TabIndex = 13;
            this.cbDictionary.SelectedValueChanged += new System.EventHandler(this.cbDictionary_SelectedValueChanged);
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(3, 343);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(152, 23);
            this.btnTest.TabIndex = 19;
            this.btnTest.Text = "Пройти тест";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkDelUser);
            this.groupBox1.Controls.Add(this.linkAddUser);
            this.groupBox1.Controls.Add(this.linkEditUser);
            this.groupBox1.Controls.Add(this.cbUsers);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользователи";
            // 
            // linkDelUser
            // 
            this.linkDelUser.AutoSize = true;
            this.linkDelUser.Location = new System.Drawing.Point(215, 43);
            this.linkDelUser.Name = "linkDelUser";
            this.linkDelUser.Size = new System.Drawing.Size(47, 13);
            this.linkDelUser.TabIndex = 12;
            this.linkDelUser.TabStop = true;
            this.linkDelUser.Text = "удалить";
            this.linkDelUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDelUser_LinkClicked);
            // 
            // linkAddUser
            // 
            this.linkAddUser.AutoSize = true;
            this.linkAddUser.Location = new System.Drawing.Point(95, 43);
            this.linkAddUser.Name = "linkAddUser";
            this.linkAddUser.Size = new System.Drawing.Size(48, 13);
            this.linkAddUser.TabIndex = 11;
            this.linkAddUser.TabStop = true;
            this.linkAddUser.Text = "создать";
            this.linkAddUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddUser_LinkClicked);
            // 
            // linkEditUser
            // 
            this.linkEditUser.AutoSize = true;
            this.linkEditUser.Location = new System.Drawing.Point(6, 43);
            this.linkEditUser.Name = "linkEditUser";
            this.linkEditUser.Size = new System.Drawing.Size(83, 13);
            this.linkEditUser.TabIndex = 10;
            this.linkEditUser.TabStop = true;
            this.linkEditUser.Text = "редактировать";
            this.linkEditUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkEditUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditUser_LinkClicked);
            // 
            // cbUsers
            // 
            this.cbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(6, 19);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(256, 21);
            this.cbUsers.TabIndex = 9;
            this.cbUsers.SelectedValueChanged += new System.EventHandler(this.cbUsers_SelectedValueChanged);
            // 
            // gboxTestSets
            // 
            this.gboxTestSets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.gboxTestSets, 2);
            this.gboxTestSets.Controls.Add(this.tableLayoutPanel2);
            this.gboxTestSets.Enabled = false;
            this.gboxTestSets.Location = new System.Drawing.Point(3, 123);
            this.gboxTestSets.Name = "gboxTestSets";
            this.gboxTestSets.Size = new System.Drawing.Size(564, 214);
            this.gboxTestSets.TabIndex = 15;
            this.gboxTestSets.TabStop = false;
            this.gboxTestSets.Text = "Настройки теста";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gboxTestPrioritySet, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.gboxTestWordsCount, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gboxTestTimeSet, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chboxTestPreview, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(552, 189);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // gboxTestPrioritySet
            // 
            this.gboxTestPrioritySet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTestPrioritySet.Controls.Add(this.radiobtnSeldom);
            this.gboxTestPrioritySet.Controls.Add(this.radiobtnBalanced);
            this.gboxTestPrioritySet.Controls.Add(this.radiobtnWrong);
            this.gboxTestPrioritySet.Controls.Add(this.radiobtnNew);
            this.gboxTestPrioritySet.Location = new System.Drawing.Point(279, 69);
            this.gboxTestPrioritySet.Name = "gboxTestPrioritySet";
            this.gboxTestPrioritySet.Size = new System.Drawing.Size(270, 117);
            this.gboxTestPrioritySet.TabIndex = 22;
            this.gboxTestPrioritySet.TabStop = false;
            this.gboxTestPrioritySet.Text = "Выборка слов";
            // 
            // radiobtnSeldom
            // 
            this.radiobtnSeldom.AutoSize = true;
            this.radiobtnSeldom.Location = new System.Drawing.Point(6, 88);
            this.radiobtnSeldom.Name = "radiobtnSeldom";
            this.radiobtnSeldom.Size = new System.Drawing.Size(240, 17);
            this.radiobtnSeldom.TabIndex = 3;
            this.radiobtnSeldom.TabStop = true;
            this.radiobtnSeldom.Text = "Слова с наименьшим количеством тестов";
            this.radiobtnSeldom.UseVisualStyleBackColor = true;
            // 
            // radiobtnBalanced
            // 
            this.radiobtnBalanced.AutoSize = true;
            this.radiobtnBalanced.Checked = true;
            this.radiobtnBalanced.Location = new System.Drawing.Point(6, 65);
            this.radiobtnBalanced.Name = "radiobtnBalanced";
            this.radiobtnBalanced.Size = new System.Drawing.Size(141, 17);
            this.radiobtnBalanced.TabIndex = 2;
            this.radiobtnBalanced.TabStop = true;
            this.radiobtnBalanced.Text = "Оптимальная выборка";
            this.radiobtnBalanced.UseVisualStyleBackColor = true;
            // 
            // radiobtnWrong
            // 
            this.radiobtnWrong.AutoSize = true;
            this.radiobtnWrong.Location = new System.Drawing.Point(6, 42);
            this.radiobtnWrong.Name = "radiobtnWrong";
            this.radiobtnWrong.Size = new System.Drawing.Size(237, 17);
            this.radiobtnWrong.TabIndex = 1;
            this.radiobtnWrong.Text = "Приоритет труднозапоминаемым словам";
            this.radiobtnWrong.UseVisualStyleBackColor = true;
            // 
            // radiobtnNew
            // 
            this.radiobtnNew.AutoSize = true;
            this.radiobtnNew.Location = new System.Drawing.Point(6, 19);
            this.radiobtnNew.Name = "radiobtnNew";
            this.radiobtnNew.Size = new System.Drawing.Size(157, 17);
            this.radiobtnNew.TabIndex = 0;
            this.radiobtnNew.Text = "Приоритет новым словам";
            this.radiobtnNew.UseVisualStyleBackColor = true;
            // 
            // gboxTestWordsCount
            // 
            this.gboxTestWordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTestWordsCount.Controls.Add(this.updownTest);
            this.gboxTestWordsCount.Location = new System.Drawing.Point(3, 3);
            this.gboxTestWordsCount.Name = "gboxTestWordsCount";
            this.gboxTestWordsCount.Size = new System.Drawing.Size(270, 46);
            this.gboxTestWordsCount.TabIndex = 17;
            this.gboxTestWordsCount.TabStop = false;
            this.gboxTestWordsCount.Text = "Число изучаемых слов";
            // 
            // updownTest
            // 
            this.updownTest.Location = new System.Drawing.Point(6, 19);
            this.updownTest.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.updownTest.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updownTest.Name = "updownTest";
            this.updownTest.Size = new System.Drawing.Size(120, 20);
            this.updownTest.TabIndex = 14;
            this.updownTest.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // gboxTestTimeSet
            // 
            this.gboxTestTimeSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxTestTimeSet.Controls.Add(this.radiobtnShort);
            this.gboxTestTimeSet.Controls.Add(this.radiobtnMiddle);
            this.gboxTestTimeSet.Controls.Add(this.radiobtnLong);
            this.gboxTestTimeSet.Location = new System.Drawing.Point(3, 69);
            this.gboxTestTimeSet.Name = "gboxTestTimeSet";
            this.gboxTestTimeSet.Size = new System.Drawing.Size(270, 117);
            this.gboxTestTimeSet.TabIndex = 21;
            this.gboxTestTimeSet.TabStop = false;
            this.gboxTestTimeSet.Text = "Контроль времени";
            // 
            // radiobtnShort
            // 
            this.radiobtnShort.AutoSize = true;
            this.radiobtnShort.Location = new System.Drawing.Point(6, 65);
            this.radiobtnShort.Name = "radiobtnShort";
            this.radiobtnShort.Size = new System.Drawing.Size(139, 17);
            this.radiobtnShort.TabIndex = 2;
            this.radiobtnShort.Text = "Быстрое прохождение";
            this.radiobtnShort.UseVisualStyleBackColor = true;
            // 
            // radiobtnMiddle
            // 
            this.radiobtnMiddle.AutoSize = true;
            this.radiobtnMiddle.Checked = true;
            this.radiobtnMiddle.Location = new System.Drawing.Point(6, 42);
            this.radiobtnMiddle.Name = "radiobtnMiddle";
            this.radiobtnMiddle.Size = new System.Drawing.Size(59, 17);
            this.radiobtnMiddle.TabIndex = 1;
            this.radiobtnMiddle.TabStop = true;
            this.radiobtnMiddle.Text = "Норма";
            this.radiobtnMiddle.UseVisualStyleBackColor = true;
            // 
            // radiobtnLong
            // 
            this.radiobtnLong.AutoSize = true;
            this.radiobtnLong.Location = new System.Drawing.Point(6, 19);
            this.radiobtnLong.Name = "radiobtnLong";
            this.radiobtnLong.Size = new System.Drawing.Size(104, 17);
            this.radiobtnLong.TabIndex = 0;
            this.radiobtnLong.Text = "Много времени";
            this.radiobtnLong.UseVisualStyleBackColor = true;
            // 
            // chboxTestPreview
            // 
            this.chboxTestPreview.AutoSize = true;
            this.chboxTestPreview.Checked = true;
            this.chboxTestPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxTestPreview.Location = new System.Drawing.Point(279, 3);
            this.chboxTestPreview.Name = "chboxTestPreview";
            this.chboxTestPreview.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.chboxTestPreview.Size = new System.Drawing.Size(181, 27);
            this.chboxTestPreview.TabIndex = 19;
            this.chboxTestPreview.Text = "Предварительный просмотр";
            this.chboxTestPreview.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Dictionary.Properties.Resources.twitter_follow_me1;
            this.pictureBox1.Location = new System.Drawing.Point(573, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(374, 334);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // tabDictionary
            // 
            this.tabDictionary.Controls.Add(this.panelDictionary);
            this.tabDictionary.Location = new System.Drawing.Point(4, 22);
            this.tabDictionary.Name = "tabDictionary";
            this.tabDictionary.Padding = new System.Windows.Forms.Padding(3);
            this.tabDictionary.Size = new System.Drawing.Size(956, 475);
            this.tabDictionary.TabIndex = 1;
            this.tabDictionary.Text = "Словарь";
            this.tabDictionary.UseVisualStyleBackColor = true;
            this.tabDictionary.Enter += new System.EventHandler(this.tabDictionary_Enter);
            // 
            // panelDictionary
            // 
            this.panelDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDictionary.Controls.Add(this.gBoxWord);
            this.panelDictionary.Controls.Add(this.gridDictionary);
            this.panelDictionary.Location = new System.Drawing.Point(6, 6);
            this.panelDictionary.Name = "panelDictionary";
            this.panelDictionary.Size = new System.Drawing.Size(944, 463);
            this.panelDictionary.TabIndex = 0;
            // 
            // gBoxWord
            // 
            this.gBoxWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxWord.Controls.Add(this.chBoxKnowing);
            this.gBoxWord.Controls.Add(this.btnCancel);
            this.gBoxWord.Controls.Add(this.btnEdit);
            this.gBoxWord.Controls.Add(this.btnDel);
            this.gBoxWord.Controls.Add(this.btnUpd);
            this.gBoxWord.Controls.Add(this.btnAdd);
            this.gBoxWord.Controls.Add(this.label2);
            this.gBoxWord.Controls.Add(this.label1);
            this.gBoxWord.Controls.Add(this.txtTranslate);
            this.gBoxWord.Controls.Add(this.txtSource);
            this.gBoxWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gBoxWord.Location = new System.Drawing.Point(3, 3);
            this.gBoxWord.Name = "gBoxWord";
            this.gBoxWord.Size = new System.Drawing.Size(938, 99);
            this.gBoxWord.TabIndex = 17;
            this.gBoxWord.TabStop = false;
            this.gBoxWord.Text = "Поиск";
            // 
            // chBoxKnowing
            // 
            this.chBoxKnowing.AutoSize = true;
            this.chBoxKnowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chBoxKnowing.Location = new System.Drawing.Point(11, 71);
            this.chBoxKnowing.Name = "chBoxKnowing";
            this.chBoxKnowing.Size = new System.Drawing.Size(66, 17);
            this.chBoxKnowing.TabIndex = 25;
            this.chBoxKnowing.Text = "изучено";
            this.chBoxKnowing.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageIndex = 4;
            this.btnCancel.ImageList = this.imgListEditors;
            this.btnCancel.Location = new System.Drawing.Point(430, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imgListEditors
            // 
            this.imgListEditors.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListEditors.ImageStream")));
            this.imgListEditors.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListEditors.Images.SetKeyName(0, "document_letter_add.png");
            this.imgListEditors.Images.SetKeyName(1, "document_letter_okay.png");
            this.imgListEditors.Images.SetKeyName(2, "document_letter_remove.png");
            this.imgListEditors.Images.SetKeyName(3, "Edit16.png");
            this.imgListEditors.Images.SetKeyName(4, "Undo Red16.png");
            this.imgListEditors.Images.SetKeyName(5, "Cancel16.png");
            this.imgListEditors.Images.SetKeyName(6, "database_add.png");
            this.imgListEditors.Images.SetKeyName(7, "database_accept.png");
            this.imgListEditors.Images.SetKeyName(8, "database_remove.png");
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.ImageIndex = 3;
            this.btnEdit.ImageList = this.imgListEditors;
            this.btnEdit.Location = new System.Drawing.Point(316, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 23);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.ImageIndex = 2;
            this.btnDel.ImageList = this.imgListEditors;
            this.btnDel.Location = new System.Drawing.Point(671, 71);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(152, 23);
            this.btnDel.TabIndex = 22;
            this.btnDel.Text = "Удалить из словаря";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpd.ImageIndex = 1;
            this.btnUpd.ImageList = this.imgListEditors;
            this.btnUpd.Location = new System.Drawing.Point(671, 45);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(152, 23);
            this.btnUpd.TabIndex = 21;
            this.btnUpd.Text = "Сохранить изменения";
            this.btnUpd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ImageList = this.imgListEditors;
            this.btnAdd.Location = new System.Drawing.Point(671, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Добавить в словарь";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Перевод";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Исходное слово";
            // 
            // txtTranslate
            // 
            this.txtTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTranslate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTranslate.Location = new System.Drawing.Point(106, 47);
            this.txtTranslate.Multiline = true;
            this.txtTranslate.Name = "txtTranslate";
            this.txtTranslate.ReadOnly = true;
            this.txtTranslate.Size = new System.Drawing.Size(556, 47);
            this.txtTranslate.TabIndex = 17;
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSource.Location = new System.Drawing.Point(106, 19);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(204, 21);
            this.txtSource.TabIndex = 16;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // gridDictionary
            // 
            this.gridDictionary.AllowUserToAddRows = false;
            this.gridDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDictionary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Translate,
            this.Test_count,
            this.Attempts,
            this.Per_hit,
            this.Is_knowing});
            this.gridDictionary.ContextMenuStrip = this.cntMenuDictionary;
            this.gridDictionary.Location = new System.Drawing.Point(3, 103);
            this.gridDictionary.Name = "gridDictionary";
            this.gridDictionary.ReadOnly = true;
            this.gridDictionary.Size = new System.Drawing.Size(938, 352);
            this.gridDictionary.TabIndex = 16;
            this.gridDictionary.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDictionary_CellMouseDoubleClick);
            // 
            // Source
            // 
            this.Source.HeaderText = "Исходное слово";
            this.Source.MinimumWidth = 100;
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Width = 150;
            // 
            // Translate
            // 
            this.Translate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Translate.HeaderText = "Перевод";
            this.Translate.MinimumWidth = 500;
            this.Translate.Name = "Translate";
            this.Translate.ReadOnly = true;
            this.Translate.Width = 500;
            // 
            // Test_count
            // 
            this.Test_count.HeaderText = "Число тестов";
            this.Test_count.Name = "Test_count";
            this.Test_count.ReadOnly = true;
            this.Test_count.Width = 65;
            // 
            // Attempts
            // 
            this.Attempts.HeaderText = "Затрачено попыток";
            this.Attempts.Name = "Attempts";
            this.Attempts.ReadOnly = true;
            this.Attempts.Width = 65;
            // 
            // Per_hit
            // 
            this.Per_hit.HeaderText = "Коэф-т ответов";
            this.Per_hit.Name = "Per_hit";
            this.Per_hit.ReadOnly = true;
            this.Per_hit.Width = 60;
            // 
            // Is_knowing
            // 
            this.Is_knowing.HeaderText = "Изучено";
            this.Is_knowing.Name = "Is_knowing";
            this.Is_knowing.ReadOnly = true;
            // 
            // cntMenuDictionary
            // 
            this.cntMenuDictionary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.updMenuItem,
            this.delMenuItem});
            this.cntMenuDictionary.Name = "cntMenuDictionary";
            this.cntMenuDictionary.Size = new System.Drawing.Size(204, 70);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.addMenuItem.Size = new System.Drawing.Size(203, 22);
            this.addMenuItem.Text = "Добавить слово";
            // 
            // updMenuItem
            // 
            this.updMenuItem.Name = "updMenuItem";
            this.updMenuItem.Size = new System.Drawing.Size(203, 22);
            this.updMenuItem.Text = "Изменить слово";
            // 
            // delMenuItem
            // 
            this.delMenuItem.Name = "delMenuItem";
            this.delMenuItem.Size = new System.Drawing.Size(203, 22);
            this.delMenuItem.Text = "Удалить слово";
            // 
            // tabStatistics
            // 
            this.tabStatistics.Controls.Add(this.gboxChartDict);
            this.tabStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistics.Size = new System.Drawing.Size(956, 475);
            this.tabStatistics.TabIndex = 2;
            this.tabStatistics.Text = "Статистика";
            this.tabStatistics.UseVisualStyleBackColor = true;
            this.tabStatistics.Enter += new System.EventHandler(this.tabStatistics_Enter);
            // 
            // gboxChartDict
            // 
            this.gboxChartDict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxChartDict.BackColor = System.Drawing.SystemColors.Window;
            this.gboxChartDict.Location = new System.Drawing.Point(7, 6);
            this.gboxChartDict.Name = "gboxChartDict";
            this.gboxChartDict.Size = new System.Drawing.Size(942, 463);
            this.gboxChartDict.TabIndex = 0;
            this.gboxChartDict.TabStop = false;
            this.gboxChartDict.Text = "Статистика по текущему словарю";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 504);
            this.Controls.Add(this.tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "View";
            this.Text = "Приложение для изучения иностранных слов";
            this.tabMain.ResumeLayout(false);
            this.tabStart.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxTestSets.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gboxTestPrioritySet.ResumeLayout(false);
            this.gboxTestPrioritySet.PerformLayout();
            this.gboxTestWordsCount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updownTest)).EndInit();
            this.gboxTestTimeSet.ResumeLayout(false);
            this.gboxTestTimeSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabDictionary.ResumeLayout(false);
            this.panelDictionary.ResumeLayout(false);
            this.gBoxWord.ResumeLayout(false);
            this.gBoxWord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDictionary)).EndInit();
            this.cntMenuDictionary.ResumeLayout(false);
            this.tabStatistics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabStart;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.TabPage tabDictionary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkDelDictionary;
        private System.Windows.Forms.LinkLabel linkAddDictionary;
        private System.Windows.Forms.LinkLabel linkEditDictionary;
        private System.Windows.Forms.ComboBox cbDictionary;
        private System.Windows.Forms.GroupBox gboxTestSets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkDelUser;
        private System.Windows.Forms.LinkLabel linkAddUser;
        private System.Windows.Forms.LinkLabel linkEditUser;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cntMenuDictionary;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delMenuItem;
        private System.Windows.Forms.Panel panelDictionary;
        private System.Windows.Forms.DataGridView gridDictionary;
        private System.Windows.Forms.GroupBox gBoxWord;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTranslate;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ImageList imgListEditors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chboxTestPreview;
        private System.Windows.Forms.GroupBox gboxTestTimeSet;
        private System.Windows.Forms.RadioButton radiobtnShort;
        private System.Windows.Forms.RadioButton radiobtnMiddle;
        private System.Windows.Forms.RadioButton radiobtnLong;
        private System.Windows.Forms.GroupBox gboxTestWordsCount;
        private System.Windows.Forms.NumericUpDown updownTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox gboxTestPrioritySet;
        private System.Windows.Forms.RadioButton radiobtnBalanced;
        private System.Windows.Forms.RadioButton radiobtnWrong;
        private System.Windows.Forms.RadioButton radiobtnNew;
        private System.Windows.Forms.Label lblDictWordsCount;
        private System.Windows.Forms.TextBox txtDictWordsCount;
        private System.Windows.Forms.GroupBox gboxChartDict;
        private System.Windows.Forms.RadioButton radiobtnSeldom;
        private System.Windows.Forms.CheckBox chBoxKnowing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Translate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Test_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attempts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Per_hit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Is_knowing;
    }
}

