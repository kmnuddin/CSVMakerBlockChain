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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Block_List = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Blk_Range_Txtbox
            // 
            this.Blk_Range_Txtbox.Location = new System.Drawing.Point(126, 31);
            this.Blk_Range_Txtbox.Name = "Blk_Range_Txtbox";
            this.Blk_Range_Txtbox.Size = new System.Drawing.Size(147, 20);
            this.Blk_Range_Txtbox.TabIndex = 4;
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
            this.Gnrt_Blocks_Transactions.Location = new System.Drawing.Point(34, 70);
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
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(438, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(661, 582);
            this.dataGridView.TabIndex = 12;
            // 
            // Block_List
            // 
            this.Block_List.FormattingEnabled = true;
            this.Block_List.Location = new System.Drawing.Point(296, 34);
            this.Block_List.Name = "Block_List";
            this.Block_List.Size = new System.Drawing.Size(120, 576);
            this.Block_List.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 648);
            this.Controls.Add(this.Block_List);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Gnrt_Blocks_Transactions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Blk_Range_Txtbox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Blk_Range_Txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Gnrt_Blocks_Transactions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ListBox Block_List;
    }
}

