namespace miniGIS
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadLayer = new System.Windows.Forms.Button();
            this.loupePlus = new System.Windows.Forms.Button();
            this.loupeMinus = new System.Windows.Forms.Button();
            this.resetLayer = new System.Windows.Forms.Button();
            this.centralPanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.closeInfoPanel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.btnFocus = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.layersList = new System.Windows.Forms.CheckedListBox();
            this.layerUp = new System.Windows.Forms.Button();
            this.deleteLayer = new System.Windows.Forms.Button();
            this.layerDown = new System.Windows.Forms.Button();
            this.saveLayer = new System.Windows.Forms.Button();
            this.moveLayer = new System.Windows.Forms.Button();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.drawFrame = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maxColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.minColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.createGrid = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.centralPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loadLayer
            // 
            this.loadLayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loadLayer.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.loadLayer.FlatAppearance.BorderSize = 0;
            this.loadLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.loadLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.loadLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadLayer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadLayer.Location = new System.Drawing.Point(13, 27);
            this.loadLayer.Margin = new System.Windows.Forms.Padding(4);
            this.loadLayer.Name = "loadLayer";
            this.loadLayer.Size = new System.Drawing.Size(169, 28);
            this.loadLayer.TabIndex = 12;
            this.loadLayer.TabStop = false;
            this.loadLayer.Text = "Загрузить слой";
            this.loadLayer.UseVisualStyleBackColor = false;
            this.loadLayer.Click += new System.EventHandler(this.loadLayer_Click);
            // 
            // loupePlus
            // 
            this.loupePlus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loupePlus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.loupePlus.FlatAppearance.BorderSize = 0;
            this.loupePlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.loupePlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.loupePlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loupePlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loupePlus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loupePlus.Location = new System.Drawing.Point(13, 447);
            this.loupePlus.Margin = new System.Windows.Forms.Padding(4);
            this.loupePlus.Name = "loupePlus";
            this.loupePlus.Size = new System.Drawing.Size(77, 30);
            this.loupePlus.TabIndex = 17;
            this.loupePlus.TabStop = false;
            this.loupePlus.Text = "+";
            this.loupePlus.UseVisualStyleBackColor = false;
            this.loupePlus.Click += new System.EventHandler(this.loupePlus_Click);
            // 
            // loupeMinus
            // 
            this.loupeMinus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loupeMinus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.loupeMinus.FlatAppearance.BorderSize = 0;
            this.loupeMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.loupeMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.loupeMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loupeMinus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loupeMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loupeMinus.Location = new System.Drawing.Point(105, 447);
            this.loupeMinus.Margin = new System.Windows.Forms.Padding(4);
            this.loupeMinus.Name = "loupeMinus";
            this.loupeMinus.Size = new System.Drawing.Size(77, 30);
            this.loupeMinus.TabIndex = 18;
            this.loupeMinus.TabStop = false;
            this.loupeMinus.Text = "-";
            this.loupeMinus.UseVisualStyleBackColor = false;
            this.loupeMinus.Click += new System.EventHandler(this.loupeMinus_Click);
            // 
            // resetLayer
            // 
            this.resetLayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.resetLayer.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.resetLayer.FlatAppearance.BorderSize = 0;
            this.resetLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.resetLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.resetLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetLayer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetLayer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetLayer.Location = new System.Drawing.Point(13, 523);
            this.resetLayer.Margin = new System.Windows.Forms.Padding(4);
            this.resetLayer.Name = "resetLayer";
            this.resetLayer.Size = new System.Drawing.Size(169, 30);
            this.resetLayer.TabIndex = 19;
            this.resetLayer.TabStop = false;
            this.resetLayer.Text = "Сброс";
            this.resetLayer.UseVisualStyleBackColor = false;
            this.resetLayer.Visible = false;
            this.resetLayer.Click += new System.EventHandler(this.resetLayer_Click);
            // 
            // centralPanel
            // 
            this.centralPanel.BackColor = System.Drawing.Color.LightGray;
            this.centralPanel.Controls.Add(this.infoPanel);
            this.centralPanel.Controls.Add(this.btnFocus);
            this.centralPanel.Controls.Add(this.leftPanel);
            this.centralPanel.Controls.Add(this.rightPanel);
            this.centralPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centralPanel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centralPanel.Location = new System.Drawing.Point(0, 0);
            this.centralPanel.Margin = new System.Windows.Forms.Padding(4);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Size = new System.Drawing.Size(1297, 618);
            this.centralPanel.TabIndex = 16;
            this.centralPanel.Visible = false;
            this.centralPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.centralPanel_Paint);
            this.centralPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.centralPanel_MouseDoubleClick);
            this.centralPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.centralPanel_MouseDown);
            this.centralPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.centralPanel_MouseMove);
            this.centralPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.centralPanel_MouseUp);
            this.centralPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.centralPanel_MouseWheel);
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.infoPanel.BackColor = System.Drawing.Color.White;
            this.infoPanel.Controls.Add(this.closeInfoPanel);
            this.infoPanel.Controls.Add(this.label12);
            this.infoPanel.Controls.Add(this.textBox10);
            this.infoPanel.Location = new System.Drawing.Point(206, 431);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(885, 135);
            this.infoPanel.TabIndex = 47;
            this.infoPanel.Visible = false;
            // 
            // closeInfoPanel
            // 
            this.closeInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeInfoPanel.BackColor = System.Drawing.Color.White;
            this.closeInfoPanel.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.closeInfoPanel.FlatAppearance.BorderSize = 0;
            this.closeInfoPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.closeInfoPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.closeInfoPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeInfoPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeInfoPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeInfoPanel.Location = new System.Drawing.Point(791, 8);
            this.closeInfoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.closeInfoPanel.Name = "closeInfoPanel";
            this.closeInfoPanel.Size = new System.Drawing.Size(86, 25);
            this.closeInfoPanel.TabIndex = 53;
            this.closeInfoPanel.TabStop = false;
            this.closeInfoPanel.Text = "Закрыть";
            this.closeInfoPanel.UseVisualStyleBackColor = false;
            this.closeInfoPanel.Click += new System.EventHandler(this.closeInfoPanel_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(194, 16);
            this.label12.TabIndex = 52;
            this.label12.Text = "Значение геополя в точке:";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Location = new System.Drawing.Point(15, 44);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox10.Size = new System.Drawing.Size(855, 76);
            this.textBox10.TabIndex = 36;
            // 
            // btnFocus
            // 
            this.btnFocus.BackColor = System.Drawing.Color.White;
            this.btnFocus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFocus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnFocus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnFocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFocus.Location = new System.Drawing.Point(1100, 20);
            this.btnFocus.Margin = new System.Windows.Forms.Padding(4);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(0, 0);
            this.btnFocus.TabIndex = 28;
            this.btnFocus.TabStop = false;
            this.btnFocus.Text = "Увеличить";
            this.btnFocus.UseVisualStyleBackColor = false;
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPanel.BackColor = System.Drawing.Color.White;
            this.leftPanel.Controls.Add(this.layersList);
            this.leftPanel.Controls.Add(this.layerUp);
            this.leftPanel.Controls.Add(this.deleteLayer);
            this.leftPanel.Controls.Add(this.layerDown);
            this.leftPanel.Controls.Add(this.loadLayer);
            this.leftPanel.Controls.Add(this.saveLayer);
            this.leftPanel.Controls.Add(this.loupePlus);
            this.leftPanel.Controls.Add(this.loupeMinus);
            this.leftPanel.Controls.Add(this.moveLayer);
            this.leftPanel.Controls.Add(this.resetLayer);
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 618);
            this.leftPanel.TabIndex = 46;
            // 
            // layersList
            // 
            this.layersList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layersList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layersList.FormattingEnabled = true;
            this.layersList.HorizontalScrollbar = true;
            this.layersList.Location = new System.Drawing.Point(12, 242);
            this.layersList.Name = "layersList";
            this.layersList.Size = new System.Drawing.Size(169, 180);
            this.layersList.TabIndex = 33;
            this.layersList.TabStop = false;
            this.layersList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.layersList_ItemCheck);
            this.layersList.SelectedIndexChanged += new System.EventHandler(this.layersList_SelectedIndexChanged);
            // 
            // layerUp
            // 
            this.layerUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layerUp.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.layerUp.FlatAppearance.BorderSize = 0;
            this.layerUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.layerUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.layerUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerUp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.layerUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerUp.Location = new System.Drawing.Point(13, 159);
            this.layerUp.Margin = new System.Windows.Forms.Padding(4);
            this.layerUp.Name = "layerUp";
            this.layerUp.Size = new System.Drawing.Size(169, 28);
            this.layerUp.TabIndex = 30;
            this.layerUp.TabStop = false;
            this.layerUp.Text = "Слой вверх";
            this.layerUp.UseVisualStyleBackColor = false;
            this.layerUp.Click += new System.EventHandler(this.layerUp_Click);
            // 
            // deleteLayer
            // 
            this.deleteLayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteLayer.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteLayer.FlatAppearance.BorderSize = 0;
            this.deleteLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.deleteLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.deleteLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteLayer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteLayer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteLayer.Location = new System.Drawing.Point(13, 99);
            this.deleteLayer.Margin = new System.Windows.Forms.Padding(4);
            this.deleteLayer.Name = "deleteLayer";
            this.deleteLayer.Size = new System.Drawing.Size(169, 28);
            this.deleteLayer.TabIndex = 25;
            this.deleteLayer.TabStop = false;
            this.deleteLayer.Text = "Удалить слой";
            this.deleteLayer.UseVisualStyleBackColor = false;
            this.deleteLayer.Click += new System.EventHandler(this.deleteLayer_Click);
            // 
            // layerDown
            // 
            this.layerDown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layerDown.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.layerDown.FlatAppearance.BorderSize = 0;
            this.layerDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.layerDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.layerDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.layerDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.layerDown.Location = new System.Drawing.Point(13, 195);
            this.layerDown.Margin = new System.Windows.Forms.Padding(4);
            this.layerDown.Name = "layerDown";
            this.layerDown.Size = new System.Drawing.Size(169, 28);
            this.layerDown.TabIndex = 31;
            this.layerDown.TabStop = false;
            this.layerDown.Text = "Слой вниз";
            this.layerDown.UseVisualStyleBackColor = false;
            this.layerDown.Click += new System.EventHandler(this.layerDown_Click);
            // 
            // saveLayer
            // 
            this.saveLayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.saveLayer.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.saveLayer.FlatAppearance.BorderSize = 0;
            this.saveLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.saveLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.saveLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveLayer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveLayer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveLayer.Location = new System.Drawing.Point(13, 63);
            this.saveLayer.Margin = new System.Windows.Forms.Padding(4);
            this.saveLayer.Name = "saveLayer";
            this.saveLayer.Size = new System.Drawing.Size(169, 28);
            this.saveLayer.TabIndex = 27;
            this.saveLayer.TabStop = false;
            this.saveLayer.Text = "Сохранить слой";
            this.saveLayer.UseVisualStyleBackColor = false;
            this.saveLayer.Click += new System.EventHandler(this.saveLayer_Click);
            // 
            // moveLayer
            // 
            this.moveLayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.moveLayer.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.moveLayer.FlatAppearance.BorderSize = 0;
            this.moveLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.moveLayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.moveLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveLayer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moveLayer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.moveLayer.Location = new System.Drawing.Point(13, 485);
            this.moveLayer.Margin = new System.Windows.Forms.Padding(4);
            this.moveLayer.Name = "moveLayer";
            this.moveLayer.Size = new System.Drawing.Size(169, 30);
            this.moveLayer.TabIndex = 24;
            this.moveLayer.TabStop = false;
            this.moveLayer.Text = "Переместить";
            this.moveLayer.UseVisualStyleBackColor = false;
            this.moveLayer.Click += new System.EventHandler(this.moveLayer_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.textBox1);
            this.rightPanel.Controls.Add(this.drawFrame);
            this.rightPanel.Controls.Add(this.label9);
            this.rightPanel.Controls.Add(this.textBox9);
            this.rightPanel.Controls.Add(this.label8);
            this.rightPanel.Controls.Add(this.textBox8);
            this.rightPanel.Controls.Add(this.label11);
            this.rightPanel.Controls.Add(this.label7);
            this.rightPanel.Controls.Add(this.label6);
            this.rightPanel.Controls.Add(this.label10);
            this.rightPanel.Controls.Add(this.maxColor);
            this.rightPanel.Controls.Add(this.label5);
            this.rightPanel.Controls.Add(this.label4);
            this.rightPanel.Controls.Add(this.minColor);
            this.rightPanel.Controls.Add(this.label3);
            this.rightPanel.Controls.Add(this.label2);
            this.rightPanel.Controls.Add(this.label1);
            this.rightPanel.Controls.Add(this.textBox7);
            this.rightPanel.Controls.Add(this.textBox6);
            this.rightPanel.Controls.Add(this.textBox5);
            this.rightPanel.Controls.Add(this.textBox4);
            this.rightPanel.Controls.Add(this.textBox3);
            this.rightPanel.Controls.Add(this.textBox2);
            this.rightPanel.Controls.Add(this.createGrid);
            this.rightPanel.Location = new System.Drawing.Point(1097, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(200, 618);
            this.rightPanel.TabIndex = 47;
            this.rightPanel.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(18, 225);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 16);
            this.textBox1.TabIndex = 35;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // drawFrame
            // 
            this.drawFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawFrame.BackColor = System.Drawing.Color.WhiteSmoke;
            this.drawFrame.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.drawFrame.FlatAppearance.BorderSize = 0;
            this.drawFrame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.drawFrame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.drawFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawFrame.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawFrame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.drawFrame.Location = new System.Drawing.Point(18, 361);
            this.drawFrame.Margin = new System.Windows.Forms.Padding(4);
            this.drawFrame.Name = "drawFrame";
            this.drawFrame.Size = new System.Drawing.Size(169, 28);
            this.drawFrame.TabIndex = 34;
            this.drawFrame.TabStop = false;
            this.drawFrame.Text = "Выбрать область";
            this.drawFrame.UseVisualStyleBackColor = false;
            this.drawFrame.Click += new System.EventHandler(this.drawFrame_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 560);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 16);
            this.label9.TabIndex = 55;
            this.label9.Text = "Кол-во узлов по Y:";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Location = new System.Drawing.Point(18, 579);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(169, 16);
            this.textBox9.TabIndex = 54;
            this.textBox9.Leave += new System.EventHandler(this.textBox9_Leave);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 510);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 16);
            this.label8.TabIndex = 53;
            this.label8.Text = "Кол-во узлов по X:";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Location = new System.Drawing.Point(18, 529);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(169, 16);
            this.textBox8.TabIndex = 52;
            this.textBox8.Leave += new System.EventHandler(this.textBox8_Leave);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 16);
            this.label11.TabIndex = 51;
            this.label11.Text = "Макс. цвет:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "Степень влияния точки:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Кол-во ближ. точек:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 16);
            this.label10.TabIndex = 50;
            this.label10.Text = "Мин. цвет:";
            // 
            // maxColor
            // 
            this.maxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxColor.BackColor = System.Drawing.Color.Red;
            this.maxColor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.maxColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.maxColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.maxColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxColor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.maxColor.Location = new System.Drawing.Point(18, 169);
            this.maxColor.Margin = new System.Windows.Forms.Padding(4);
            this.maxColor.Name = "maxColor";
            this.maxColor.Size = new System.Drawing.Size(169, 20);
            this.maxColor.TabIndex = 49;
            this.maxColor.TabStop = false;
            this.maxColor.UseVisualStyleBackColor = false;
            this.maxColor.Click += new System.EventHandler(this.maxColor_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "Макс. X:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Макс. Y:";
            // 
            // minColor
            // 
            this.minColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minColor.BackColor = System.Drawing.Color.Blue;
            this.minColor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.minColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.minColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.minColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minColor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minColor.Location = new System.Drawing.Point(18, 119);
            this.minColor.Margin = new System.Windows.Forms.Padding(4);
            this.minColor.Name = "minColor";
            this.minColor.Size = new System.Drawing.Size(169, 20);
            this.minColor.TabIndex = 34;
            this.minColor.TabStop = false;
            this.minColor.UseVisualStyleBackColor = false;
            this.minColor.Click += new System.EventHandler(this.minColor_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "Мин. Y:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "Мин. X:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "Шаг сети:";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(18, 479);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(169, 16);
            this.textBox7.TabIndex = 41;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(18, 429);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(169, 16);
            this.textBox6.TabIndex = 40;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(113, 325);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(74, 16);
            this.textBox5.TabIndex = 39;
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(18, 325);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(74, 16);
            this.textBox4.TabIndex = 38;
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(113, 275);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 16);
            this.textBox3.TabIndex = 37;
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(18, 275);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 16);
            this.textBox2.TabIndex = 36;
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // createGrid
            // 
            this.createGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.createGrid.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.createGrid.FlatAppearance.BorderSize = 0;
            this.createGrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.createGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.createGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createGrid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createGrid.Location = new System.Drawing.Point(18, 27);
            this.createGrid.Margin = new System.Windows.Forms.Padding(4);
            this.createGrid.Name = "createGrid";
            this.createGrid.Size = new System.Drawing.Size(169, 50);
            this.createGrid.TabIndex = 34;
            this.createGrid.TabStop = false;
            this.createGrid.Text = "Построить регулярную сеть\r\n";
            this.createGrid.UseVisualStyleBackColor = false;
            this.createGrid.Click += new System.EventHandler(this.createGrid_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1297, 618);
            this.Controls.Add(this.centralPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini-GIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.centralPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadLayer;
        private System.Windows.Forms.Button loupePlus;
        private System.Windows.Forms.Button loupeMinus;
        private System.Windows.Forms.Button resetLayer;     
        private System.Windows.Forms.Button moveLayer;
        private System.Windows.Forms.Button deleteLayer;
        private System.Windows.Forms.Button saveLayer;
        private System.Windows.Forms.Panel centralPanel;
        private System.Windows.Forms.Button btnFocus;
        private System.Windows.Forms.Button layerDown;
        private System.Windows.Forms.Button layerUp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.CheckedListBox layersList;
        private System.Windows.Forms.Button createGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button maxColor;
        private System.Windows.Forms.Button minColor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button drawFrame;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button closeInfoPanel;
    }
}

