namespace Lab1SGBD
{
    partial class Form1
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
            this.gridViewParent = new System.Windows.Forms.DataGridView();
            this.showParent = new System.Windows.Forms.Button();
            this.gridViewChild = new System.Windows.Forms.DataGridView();
            this.deleteChild = new System.Windows.Forms.Button();
            this.updateChild = new System.Windows.Forms.Button();
            this.addChild = new System.Windows.Forms.Button();
            this.labelChild = new System.Windows.Forms.Label();
            this.labelParent = new System.Windows.Forms.Label();
            this.panelChild = new System.Windows.Forms.Panel();
            this.connectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChild)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewParent
            // 
            this.gridViewParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewParent.Location = new System.Drawing.Point(12, 40);
            this.gridViewParent.MultiSelect = false;
            this.gridViewParent.Name = "gridViewParent";
            this.gridViewParent.ReadOnly = true;
            this.gridViewParent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewParent.Size = new System.Drawing.Size(450, 292);
            this.gridViewParent.TabIndex = 0;
            this.gridViewParent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // showParent
            // 
            this.showParent.Location = new System.Drawing.Point(12, 351);
            this.showParent.Name = "showParent";
            this.showParent.Size = new System.Drawing.Size(113, 38);
            this.showParent.TabIndex = 1;
            this.showParent.Text = "Afisare";
            this.showParent.UseVisualStyleBackColor = true;
            this.showParent.Visible = false;
            this.showParent.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridViewChild
            // 
            this.gridViewChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewChild.Location = new System.Drawing.Point(517, 40);
            this.gridViewChild.MultiSelect = false;
            this.gridViewChild.Name = "gridViewChild";
            this.gridViewChild.ReadOnly = true;
            this.gridViewChild.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewChild.Size = new System.Drawing.Size(513, 245);
            this.gridViewChild.TabIndex = 12;
            this.gridViewChild.Visible = false;
            this.gridViewChild.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            // 
            // deleteChild
            // 
            this.deleteChild.Location = new System.Drawing.Point(903, 309);
            this.deleteChild.Name = "deleteChild";
            this.deleteChild.Size = new System.Drawing.Size(75, 23);
            this.deleteChild.TabIndex = 15;
            this.deleteChild.Text = "Delete";
            this.deleteChild.UseVisualStyleBackColor = true;
            this.deleteChild.Visible = false;
            this.deleteChild.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // updateChild
            // 
            this.updateChild.Location = new System.Drawing.Point(903, 359);
            this.updateChild.Name = "updateChild";
            this.updateChild.Size = new System.Drawing.Size(75, 23);
            this.updateChild.TabIndex = 16;
            this.updateChild.Text = "Update";
            this.updateChild.UseVisualStyleBackColor = true;
            this.updateChild.Visible = false;
            this.updateChild.Click += new System.EventHandler(this.button2_Click);
            // 
            // addChild
            // 
            this.addChild.Location = new System.Drawing.Point(903, 406);
            this.addChild.Name = "addChild";
            this.addChild.Size = new System.Drawing.Size(75, 23);
            this.addChild.TabIndex = 26;
            this.addChild.Text = "Add";
            this.addChild.UseVisualStyleBackColor = true;
            this.addChild.Visible = false;
            this.addChild.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // labelChild
            // 
            this.labelChild.AutoSize = true;
            this.labelChild.Location = new System.Drawing.Point(514, 9);
            this.labelChild.Name = "labelChild";
            this.labelChild.Size = new System.Drawing.Size(0, 13);
            this.labelChild.TabIndex = 28;
            // 
            // labelParent
            // 
            this.labelParent.AutoSize = true;
            this.labelParent.Location = new System.Drawing.Point(9, 9);
            this.labelParent.Name = "labelParent";
            this.labelParent.Size = new System.Drawing.Size(0, 13);
            this.labelParent.TabIndex = 29;
            this.labelParent.Visible = false;
            // 
            // panelChild
            // 
            this.panelChild.Location = new System.Drawing.Point(618, 295);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(229, 239);
            this.panelChild.TabIndex = 30;
            this.panelChild.Visible = false;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(15, 462);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(113, 52);
            this.connectBtn.TabIndex = 31;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 546);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.labelParent);
            this.Controls.Add(this.labelChild);
            this.Controls.Add(this.addChild);
            this.Controls.Add(this.updateChild);
            this.Controls.Add(this.deleteChild);
            this.Controls.Add(this.gridViewChild);
            this.Controls.Add(this.showParent);
            this.Controls.Add(this.gridViewParent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewParent;
        private System.Windows.Forms.Button showParent;
        private System.Windows.Forms.DataGridView gridViewChild;
        private System.Windows.Forms.Button deleteChild;
        private System.Windows.Forms.Button updateChild;
        private System.Windows.Forms.Button addChild;
        private System.Windows.Forms.Label labelChild;
        private System.Windows.Forms.Label labelParent;
        private System.Windows.Forms.Panel panelChild;
        private System.Windows.Forms.Button connectBtn;
    }
}

