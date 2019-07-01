namespace CSVFileMakerBlockChain
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
            this.Blk_Range_Txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Gnrt_Blocks_Transactions = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Block_List = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataGridView_block = new System.Windows.Forms.DataGridView();
            this.DataGridView_tx = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_block)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_tx)).BeginInit();
            this.SuspendLayout();
            // 
            // Blk_Range_Txtbox
            // 
            this.Blk_Range_Txtbox.Location = new System.Drawing.Point(126, 31);
            this.Blk_Range_Txtbox.Name = "Blk_Range_Txtbox";
            this.Blk_Range_Txtbox.Size = new System.Drawing.Size(147, 20);
            this.Blk_Range_Txtbox.TabIndex = 4;
            this.Blk_Range_Txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Blk_Range_Txtbox_KeyDown);
            this.Blk_Range_Txtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Blk_Range_Txtbox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Block Height Range";
            // 
            // Gnrt_Blocks_Transactions
            // 
            this.Gnrt_Blocks_Transactions.Location = new System.Drawing.Point(34, 80);
            this.Gnrt_Blocks_Transactions.Name = "Gnrt_Blocks_Transactions";
            this.Gnrt_Blocks_Transactions.Size = new System.Drawing.Size(239, 28);
            this.Gnrt_Blocks_Transactions.TabIndex = 7;
            this.Gnrt_Blocks_Transactions.Text = "Generate Blocks and Transactions";
            this.Gnrt_Blocks_Transactions.UseVisualStyleBackColor = true;
            this.Gnrt_Blocks_Transactions.Click += new System.EventHandler(this.Gnrt_Blocks_Transactions_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Blocks";
            // 
            // Block_List
            // 
            this.Block_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Block_List.FormattingEnabled = true;
            this.Block_List.Location = new System.Drawing.Point(296, 34);
            this.Block_List.Name = "Block_List";
            this.Block_List.Size = new System.Drawing.Size(120, 576);
            this.Block_List.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(442, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(645, 576);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataGridView_block);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(637, 550);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Block Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DataGridView_tx);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(637, 550);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transactions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataGridView_block
            // 
            this.DataGridView_block.AllowUserToAddRows = false;
            this.DataGridView_block.AllowUserToDeleteRows = false;
            this.DataGridView_block.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_block.Location = new System.Drawing.Point(3, 3);
            this.DataGridView_block.Name = "DataGridView_block";
            this.DataGridView_block.ReadOnly = true;
            this.DataGridView_block.Size = new System.Drawing.Size(631, 544);
            this.DataGridView_block.TabIndex = 0;
            // 
            // DataGridView_tx
            // 
            this.DataGridView_tx.AllowUserToAddRows = false;
            this.DataGridView_tx.AllowUserToDeleteRows = false;
            this.DataGridView_tx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_tx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_tx.Location = new System.Drawing.Point(3, 3);
            this.DataGridView_tx.Name = "DataGridView_tx";
            this.DataGridView_tx.ReadOnly = true;
            this.DataGridView_tx.Size = new System.Drawing.Size(631, 544);
            this.DataGridView_tx.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 648);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Block_List);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Gnrt_Blocks_Transactions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Blk_Range_Txtbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_block)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_tx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Blk_Range_Txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Gnrt_Blocks_Transactions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Block_List;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DataGridView_block;
        private System.Windows.Forms.DataGridView DataGridView_tx;
    }
}

