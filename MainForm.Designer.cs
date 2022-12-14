
namespace Мебель
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label clientIdLabel;
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label oddMoneyLabel;
            System.Windows.Forms.Label paymentIdLabel;
            System.Windows.Forms.Label sumLabel;
            System.Windows.Forms.Label userIdLabel;
            System.Windows.Forms.Label furnitureIdLabel;
            System.Windows.Forms.Label quantityLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.clientErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.учетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выхдныеДокументыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.покупкиЗаПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыРаботыСотрудникаЗаПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.insertChequeBTN = new System.Windows.Forms.Button();
            this.deleteChequeBTN = new System.Windows.Forms.Button();
            this.clearChequeBTN = new System.Windows.Forms.Button();
            this.printChequeBTN = new System.Windows.Forms.Button();
            this.gropDX = new System.Windows.Forms.GroupBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.issueCheckBox = new System.Windows.Forms.CheckBox();
            this.userNameTB = new System.Windows.Forms.TextBox();
            this.allSumTB = new System.Windows.Forms.TextBox();
            this.sumChequeNUD = new System.Windows.Forms.NumericUpDown();
            this.oddMoneyTextBox = new System.Windows.Forms.TextBox();
            this.assemblyChequeCheckBox = new System.Windows.Forms.CheckBox();
            this.clientChequeCB = new System.Windows.Forms.ComboBox();
            this.dateIssueChequeDTP = new System.Windows.Forms.DateTimePicker();
            this.deliveryChequeCheckBox = new System.Windows.Forms.CheckBox();
            this.paymentChequeCB = new System.Windows.Forms.ComboBox();
            this.chequeDGV = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.insertShopListBTN = new System.Windows.Forms.Button();
            this.updateShopListBTN = new System.Windows.Forms.Button();
            this.clearShopListBTN = new System.Windows.Forms.Button();
            this.deleteShopListBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.furnitureShopListCB = new System.Windows.Forms.ComboBox();
            this.quantityShopListNUD = new System.Windows.Forms.NumericUpDown();
            this.shopListDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequePrintChequeBTN = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.chequeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clientIdLabel = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            oddMoneyLabel = new System.Windows.Forms.Label();
            paymentIdLabel = new System.Windows.Forms.Label();
            sumLabel = new System.Windows.Forms.Label();
            userIdLabel = new System.Windows.Forms.Label();
            furnitureIdLabel = new System.Windows.Forms.Label();
            quantityLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientErrorProvider)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gropDX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sumChequeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDGV)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityShopListNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopListDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientIdLabel
            // 
            clientIdLabel.AutoSize = true;
            clientIdLabel.Location = new System.Drawing.Point(49, 100);
            clientIdLabel.Name = "clientIdLabel";
            clientIdLabel.Size = new System.Drawing.Size(46, 13);
            clientIdLabel.TabIndex = 2;
            clientIdLabel.Text = "Клиент:";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(19, 49);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(76, 13);
            dateLabel.TabIndex = 4;
            dateLabel.Text = "Дата выдачи:";
            // 
            // oddMoneyLabel
            // 
            oddMoneyLabel.AutoSize = true;
            oddMoneyLabel.Location = new System.Drawing.Point(55, 178);
            oddMoneyLabel.Name = "oddMoneyLabel";
            oddMoneyLabel.Size = new System.Drawing.Size(40, 13);
            oddMoneyLabel.TabIndex = 8;
            oddMoneyLabel.Text = "Сдача:";
            // 
            // paymentIdLabel
            // 
            paymentIdLabel.AutoSize = true;
            paymentIdLabel.Location = new System.Drawing.Point(8, 127);
            paymentIdLabel.Name = "paymentIdLabel";
            paymentIdLabel.Size = new System.Drawing.Size(87, 13);
            paymentIdLabel.TabIndex = 10;
            paymentIdLabel.Text = "Способ оплаты:";
            // 
            // sumLabel
            // 
            sumLabel.AutoSize = true;
            sumLabel.Location = new System.Drawing.Point(51, 153);
            sumLabel.Name = "sumLabel";
            sumLabel.Size = new System.Drawing.Size(44, 13);
            sumLabel.TabIndex = 14;
            sumLabel.Text = "Сумма:";
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Location = new System.Drawing.Point(32, 74);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new System.Drawing.Size(63, 13);
            userIdLabel.TabIndex = 16;
            userIdLabel.Text = "Сотрудник:";
            // 
            // furnitureIdLabel
            // 
            furnitureIdLabel.AutoSize = true;
            furnitureIdLabel.Location = new System.Drawing.Point(3, 22);
            furnitureIdLabel.Name = "furnitureIdLabel";
            furnitureIdLabel.Size = new System.Drawing.Size(52, 13);
            furnitureIdLabel.TabIndex = 0;
            furnitureIdLabel.Text = "Продукт:";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new System.Drawing.Point(333, 22);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new System.Drawing.Size(69, 13);
            quantityLabel.TabIndex = 2;
            quantityLabel.Text = "Количество:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(55, 205);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 13);
            label1.TabIndex = 20;
            label1.Text = "Итого:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 13);
            label2.TabIndex = 24;
            label2.Text = "Дата операции:";
            // 
            // clientErrorProvider
            // 
            this.clientErrorProvider.ContainerControl = this;
            this.clientErrorProvider.DataSource = this.clientBindingSource;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учетToolStripMenuItem,
            this.выхдныеДокументыToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1133, 24);
            this.mainMenuStrip.TabIndex = 26;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // учетToolStripMenuItem
            // 
            this.учетToolStripMenuItem.Name = "учетToolStripMenuItem";
            this.учетToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.учетToolStripMenuItem.Text = "Учет";
            this.учетToolStripMenuItem.Click += new System.EventHandler(this.учетToolStripMenuItem_Click);
            // 
            // выхдныеДокументыToolStripMenuItem
            // 
            this.выхдныеДокументыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.покупкиЗаПериодToolStripMenuItem,
            this.результатыРаботыСотрудникаЗаПериодToolStripMenuItem});
            this.выхдныеДокументыToolStripMenuItem.Name = "выхдныеДокументыToolStripMenuItem";
            this.выхдныеДокументыToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.выхдныеДокументыToolStripMenuItem.Text = "Выходные документы";
            // 
            // покупкиЗаПериодToolStripMenuItem
            // 
            this.покупкиЗаПериодToolStripMenuItem.Name = "покупкиЗаПериодToolStripMenuItem";
            this.покупкиЗаПериодToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.покупкиЗаПериодToolStripMenuItem.Text = "Выручка за период";
            this.покупкиЗаПериодToolStripMenuItem.Click += new System.EventHandler(this.покупкиЗаПериодToolStripMenuItem_Click);
            // 
            // результатыРаботыСотрудникаЗаПериодToolStripMenuItem
            // 
            this.результатыРаботыСотрудникаЗаПериодToolStripMenuItem.Name = "результатыРаботыСотрудникаЗаПериодToolStripMenuItem";
            this.результатыРаботыСотрудникаЗаПериодToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.результатыРаботыСотрудникаЗаПериодToolStripMenuItem.Text = "Проданные товары за период";
            this.результатыРаботыСотрудникаЗаПериодToolStripMenuItem.Click += new System.EventHandler(this.результатыРаботыСотрудникаЗаПериодToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.insertChequeBTN, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.deleteChequeBTN, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.clearChequeBTN, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.printChequeBTN, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.gropDX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chequeDGV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chequePrintChequeBTN, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.35032F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64968F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 452);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // insertChequeBTN
            // 
            this.insertChequeBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insertChequeBTN.Location = new System.Drawing.Point(229, 414);
            this.insertChequeBTN.Name = "insertChequeBTN";
            this.insertChequeBTN.Size = new System.Drawing.Size(220, 35);
            this.insertChequeBTN.TabIndex = 0;
            this.insertChequeBTN.Text = "Добавить";
            this.insertChequeBTN.UseVisualStyleBackColor = true;
            this.insertChequeBTN.Click += new System.EventHandler(this.insertChequeBTN_Click);
            // 
            // deleteChequeBTN
            // 
            this.deleteChequeBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteChequeBTN.Location = new System.Drawing.Point(455, 414);
            this.deleteChequeBTN.Name = "deleteChequeBTN";
            this.deleteChequeBTN.Size = new System.Drawing.Size(220, 35);
            this.deleteChequeBTN.TabIndex = 2;
            this.deleteChequeBTN.Text = "Удалить";
            this.deleteChequeBTN.UseVisualStyleBackColor = true;
            this.deleteChequeBTN.Click += new System.EventHandler(this.delelteChequeBTN_Click);
            // 
            // clearChequeBTN
            // 
            this.clearChequeBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearChequeBTN.Location = new System.Drawing.Point(681, 414);
            this.clearChequeBTN.Name = "clearChequeBTN";
            this.clearChequeBTN.Size = new System.Drawing.Size(220, 35);
            this.clearChequeBTN.TabIndex = 3;
            this.clearChequeBTN.Text = "Очистить";
            this.clearChequeBTN.UseVisualStyleBackColor = true;
            this.clearChequeBTN.Click += new System.EventHandler(this.clearChequeBTN_Click);
            // 
            // printChequeBTN
            // 
            this.printChequeBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printChequeBTN.Location = new System.Drawing.Point(907, 414);
            this.printChequeBTN.Name = "printChequeBTN";
            this.printChequeBTN.Size = new System.Drawing.Size(223, 35);
            this.printChequeBTN.TabIndex = 4;
            this.printChequeBTN.Text = "Печать";
            this.printChequeBTN.UseVisualStyleBackColor = true;
            this.printChequeBTN.Click += new System.EventHandler(this.printChequeBTN_Click);
            // 
            // gropDX
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gropDX, 2);
            this.gropDX.Controls.Add(this.dateTextBox);
            this.gropDX.Controls.Add(label2);
            this.gropDX.Controls.Add(this.issueCheckBox);
            this.gropDX.Controls.Add(this.userNameTB);
            this.gropDX.Controls.Add(this.allSumTB);
            this.gropDX.Controls.Add(label1);
            this.gropDX.Controls.Add(this.sumChequeNUD);
            this.gropDX.Controls.Add(this.oddMoneyTextBox);
            this.gropDX.Controls.Add(this.assemblyChequeCheckBox);
            this.gropDX.Controls.Add(clientIdLabel);
            this.gropDX.Controls.Add(this.clientChequeCB);
            this.gropDX.Controls.Add(dateLabel);
            this.gropDX.Controls.Add(this.dateIssueChequeDTP);
            this.gropDX.Controls.Add(this.deliveryChequeCheckBox);
            this.gropDX.Controls.Add(oddMoneyLabel);
            this.gropDX.Controls.Add(paymentIdLabel);
            this.gropDX.Controls.Add(this.paymentChequeCB);
            this.gropDX.Controls.Add(sumLabel);
            this.gropDX.Controls.Add(userIdLabel);
            this.gropDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gropDX.Location = new System.Drawing.Point(3, 181);
            this.gropDX.Name = "gropDX";
            this.gropDX.Size = new System.Drawing.Size(446, 227);
            this.gropDX.TabIndex = 5;
            this.gropDX.TabStop = false;
            this.gropDX.Text = "Чек";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Enabled = false;
            this.dateTextBox.Location = new System.Drawing.Point(101, 19);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(209, 20);
            this.dateTextBox.TabIndex = 25;
            // 
            // issueCheckBox
            // 
            this.issueCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.chequeBindingSource, "Delivery", true));
            this.issueCheckBox.Location = new System.Drawing.Point(316, 46);
            this.issueCheckBox.Name = "issueCheckBox";
            this.issueCheckBox.Size = new System.Drawing.Size(94, 24);
            this.issueCheckBox.TabIndex = 23;
            this.issueCheckBox.Text = "Заказ";
            this.issueCheckBox.UseVisualStyleBackColor = true;
            this.issueCheckBox.CheckedChanged += new System.EventHandler(this.issueCheckBox_CheckedChanged);
            // 
            // userNameTB
            // 
            this.userNameTB.Enabled = false;
            this.userNameTB.Location = new System.Drawing.Point(101, 71);
            this.userNameTB.Name = "userNameTB";
            this.userNameTB.Size = new System.Drawing.Size(209, 20);
            this.userNameTB.TabIndex = 22;
            // 
            // allSumTB
            // 
            this.allSumTB.Enabled = false;
            this.allSumTB.Location = new System.Drawing.Point(101, 202);
            this.allSumTB.Name = "allSumTB";
            this.allSumTB.Size = new System.Drawing.Size(209, 20);
            this.allSumTB.TabIndex = 21;
            this.allSumTB.Text = "0";
            // 
            // sumChequeNUD
            // 
            this.sumChequeNUD.DecimalPlaces = 2;
            this.sumChequeNUD.Location = new System.Drawing.Point(101, 150);
            this.sumChequeNUD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.sumChequeNUD.Name = "sumChequeNUD";
            this.sumChequeNUD.Size = new System.Drawing.Size(209, 20);
            this.sumChequeNUD.TabIndex = 19;
            this.sumChequeNUD.ValueChanged += new System.EventHandler(this.sumChequeNUD_ValueChanged);
            // 
            // oddMoneyTextBox
            // 
            this.oddMoneyTextBox.Enabled = false;
            this.oddMoneyTextBox.Location = new System.Drawing.Point(101, 176);
            this.oddMoneyTextBox.Name = "oddMoneyTextBox";
            this.oddMoneyTextBox.Size = new System.Drawing.Size(209, 20);
            this.oddMoneyTextBox.TabIndex = 18;
            this.oddMoneyTextBox.Text = "0";
            // 
            // assemblyChequeCheckBox
            // 
            this.assemblyChequeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.chequeBindingSource, "Assembly", true));
            this.assemblyChequeCheckBox.Location = new System.Drawing.Point(316, 100);
            this.assemblyChequeCheckBox.Name = "assemblyChequeCheckBox";
            this.assemblyChequeCheckBox.Size = new System.Drawing.Size(100, 24);
            this.assemblyChequeCheckBox.TabIndex = 1;
            this.assemblyChequeCheckBox.Text = "Сброка";
            this.assemblyChequeCheckBox.UseVisualStyleBackColor = true;
            // 
            // clientChequeCB
            // 
            this.clientChequeCB.FormattingEnabled = true;
            this.clientChequeCB.Location = new System.Drawing.Point(101, 97);
            this.clientChequeCB.Name = "clientChequeCB";
            this.clientChequeCB.Size = new System.Drawing.Size(209, 21);
            this.clientChequeCB.TabIndex = 3;
            // 
            // dateIssueChequeDTP
            // 
            this.dateIssueChequeDTP.Enabled = false;
            this.dateIssueChequeDTP.Location = new System.Drawing.Point(101, 45);
            this.dateIssueChequeDTP.Name = "dateIssueChequeDTP";
            this.dateIssueChequeDTP.Size = new System.Drawing.Size(209, 20);
            this.dateIssueChequeDTP.TabIndex = 5;
            this.dateIssueChequeDTP.Validating += new System.ComponentModel.CancelEventHandler(this.dateIssueChequeDTP_Validating);
            // 
            // deliveryChequeCheckBox
            // 
            this.deliveryChequeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.chequeBindingSource, "Delivery", true));
            this.deliveryChequeCheckBox.Location = new System.Drawing.Point(316, 74);
            this.deliveryChequeCheckBox.Name = "deliveryChequeCheckBox";
            this.deliveryChequeCheckBox.Size = new System.Drawing.Size(94, 24);
            this.deliveryChequeCheckBox.TabIndex = 7;
            this.deliveryChequeCheckBox.Text = "Доставка";
            this.deliveryChequeCheckBox.UseVisualStyleBackColor = true;
            // 
            // paymentChequeCB
            // 
            this.paymentChequeCB.FormattingEnabled = true;
            this.paymentChequeCB.Location = new System.Drawing.Point(101, 124);
            this.paymentChequeCB.Name = "paymentChequeCB";
            this.paymentChequeCB.Size = new System.Drawing.Size(209, 21);
            this.paymentChequeCB.TabIndex = 11;
            // 
            // chequeDGV
            // 
            this.chequeDGV.AllowUserToAddRows = false;
            this.chequeDGV.AllowUserToDeleteRows = false;
            this.chequeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chequeDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column14});
            this.tableLayoutPanel1.SetColumnSpan(this.chequeDGV, 5);
            this.chequeDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chequeDGV.Location = new System.Drawing.Point(3, 3);
            this.chequeDGV.Name = "chequeDGV";
            this.chequeDGV.ReadOnly = true;
            this.chequeDGV.Size = new System.Drawing.Size(1127, 172);
            this.chequeDGV.TabIndex = 6;
            this.chequeDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.chequeDGV_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.insertShopListBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.updateShopListBTN, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.clearShopListBTN, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.deleteShopListBTN, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.shopListDGV, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(455, 181);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.67416F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.32584F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(675, 227);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // insertShopListBTN
            // 
            this.insertShopListBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insertShopListBTN.Location = new System.Drawing.Point(3, 195);
            this.insertShopListBTN.Name = "insertShopListBTN";
            this.insertShopListBTN.Size = new System.Drawing.Size(162, 29);
            this.insertShopListBTN.TabIndex = 0;
            this.insertShopListBTN.Text = "Добавить";
            this.insertShopListBTN.UseVisualStyleBackColor = true;
            this.insertShopListBTN.Click += new System.EventHandler(this.insertShopListBTN_Click);
            // 
            // updateShopListBTN
            // 
            this.updateShopListBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateShopListBTN.Location = new System.Drawing.Point(171, 195);
            this.updateShopListBTN.Name = "updateShopListBTN";
            this.updateShopListBTN.Size = new System.Drawing.Size(162, 29);
            this.updateShopListBTN.TabIndex = 1;
            this.updateShopListBTN.Text = "Изменить";
            this.updateShopListBTN.UseVisualStyleBackColor = true;
            this.updateShopListBTN.Click += new System.EventHandler(this.updateShopListBTN_Click);
            // 
            // clearShopListBTN
            // 
            this.clearShopListBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearShopListBTN.Location = new System.Drawing.Point(507, 195);
            this.clearShopListBTN.Name = "clearShopListBTN";
            this.clearShopListBTN.Size = new System.Drawing.Size(165, 29);
            this.clearShopListBTN.TabIndex = 2;
            this.clearShopListBTN.Text = "Очистить";
            this.clearShopListBTN.UseVisualStyleBackColor = true;
            this.clearShopListBTN.Click += new System.EventHandler(this.clearShopListBTN_Click);
            // 
            // deleteShopListBTN
            // 
            this.deleteShopListBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteShopListBTN.Location = new System.Drawing.Point(339, 195);
            this.deleteShopListBTN.Name = "deleteShopListBTN";
            this.deleteShopListBTN.Size = new System.Drawing.Size(162, 29);
            this.deleteShopListBTN.TabIndex = 3;
            this.deleteShopListBTN.Text = "Удалить";
            this.deleteShopListBTN.UseVisualStyleBackColor = true;
            this.deleteShopListBTN.Click += new System.EventHandler(this.deleteShopListBTN_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(furnitureIdLabel);
            this.groupBox1.Controls.Add(this.furnitureShopListCB);
            this.groupBox1.Controls.Add(quantityLabel);
            this.groupBox1.Controls.Add(this.quantityShopListNUD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 48);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Мебель";
            // 
            // furnitureShopListCB
            // 
            this.furnitureShopListCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shopListBindingSource, "FurnitureId", true));
            this.furnitureShopListCB.FormattingEnabled = true;
            this.furnitureShopListCB.Location = new System.Drawing.Point(61, 19);
            this.furnitureShopListCB.Name = "furnitureShopListCB";
            this.furnitureShopListCB.Size = new System.Drawing.Size(266, 21);
            this.furnitureShopListCB.TabIndex = 1;
            // 
            // quantityShopListNUD
            // 
            this.quantityShopListNUD.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.shopListBindingSource, "Quantity", true));
            this.quantityShopListNUD.Location = new System.Drawing.Point(408, 20);
            this.quantityShopListNUD.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.quantityShopListNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityShopListNUD.Name = "quantityShopListNUD";
            this.quantityShopListNUD.Size = new System.Drawing.Size(255, 20);
            this.quantityShopListNUD.TabIndex = 3;
            this.quantityShopListNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shopListDGV
            // 
            this.shopListDGV.AllowUserToAddRows = false;
            this.shopListDGV.AllowUserToDeleteRows = false;
            this.shopListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shopListDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.tableLayoutPanel2.SetColumnSpan(this.shopListDGV, 4);
            this.shopListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shopListDGV.Location = new System.Drawing.Point(3, 3);
            this.shopListDGV.Name = "shopListDGV";
            this.shopListDGV.ReadOnly = true;
            this.shopListDGV.Size = new System.Drawing.Size(669, 132);
            this.shopListDGV.TabIndex = 5;
            this.shopListDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shopListDGV_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Продукт";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Количество";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 91;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Сумма";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 66;
            // 
            // chequePrintChequeBTN
            // 
            this.chequePrintChequeBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chequePrintChequeBTN.Location = new System.Drawing.Point(3, 414);
            this.chequePrintChequeBTN.Name = "chequePrintChequeBTN";
            this.chequePrintChequeBTN.Size = new System.Drawing.Size(220, 35);
            this.chequePrintChequeBTN.TabIndex = 8;
            this.chequePrintChequeBTN.Text = "Чек";
            this.chequePrintChequeBTN.UseVisualStyleBackColor = true;
            this.chequePrintChequeBTN.Click += new System.EventHandler(this.chequePrintChequeBTN_Click);
            // 
            // chequeBindingSource
            // 
            this.chequeBindingSource.DataSource = typeof(Мебель.Cheque);
            // 
            // shopListBindingSource
            // 
            this.shopListBindingSource.DataSource = typeof(Мебель.ShopList);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(Мебель.Client);
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "№";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 43;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Дата операции";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Сотрудник";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Клиент";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "Сборка";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 69;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.HeaderText = "Доставка";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Width = 82;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column11.HeaderText = "Способ оплаты";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column12.HeaderText = "Сумма";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 66;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column14.HeaderText = "Дата выдачи";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 90;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Учет обслуживания на прелприятии \"Мебель ФМ\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientErrorProvider)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gropDX.ResumeLayout(false);
            this.gropDX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sumChequeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeDGV)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityShopListNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopListDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.ErrorProvider clientErrorProvider;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem учетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выхдныеДокументыToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button insertChequeBTN;
        private System.Windows.Forms.Button deleteChequeBTN;
        private System.Windows.Forms.Button clearChequeBTN;
        private System.Windows.Forms.Button printChequeBTN;
        private System.Windows.Forms.GroupBox gropDX;
        private System.Windows.Forms.DataGridView chequeDGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button insertShopListBTN;
        private System.Windows.Forms.Button updateShopListBTN;
        private System.Windows.Forms.Button clearShopListBTN;
        private System.Windows.Forms.Button deleteShopListBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView shopListDGV;
        private System.Windows.Forms.TextBox oddMoneyTextBox;
        private System.Windows.Forms.CheckBox assemblyChequeCheckBox;
        private System.Windows.Forms.BindingSource chequeBindingSource;
        private System.Windows.Forms.ComboBox clientChequeCB;
        private System.Windows.Forms.DateTimePicker dateIssueChequeDTP;
        private System.Windows.Forms.CheckBox deliveryChequeCheckBox;
        private System.Windows.Forms.ComboBox paymentChequeCB;
        private System.Windows.Forms.ComboBox furnitureShopListCB;
        private System.Windows.Forms.BindingSource shopListBindingSource;
        private System.Windows.Forms.NumericUpDown quantityShopListNUD;
        private System.Windows.Forms.TextBox allSumTB;
        private System.Windows.Forms.NumericUpDown sumChequeNUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox userNameTB;
        private System.Windows.Forms.ToolStripMenuItem покупкиЗаПериодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem результатыРаботыСотрудникаЗаПериодToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button chequePrintChequeBTN;
        private System.Windows.Forms.CheckBox issueCheckBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}

