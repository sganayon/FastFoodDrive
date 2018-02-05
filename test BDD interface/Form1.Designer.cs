namespace test_BDD_interface
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.archi = new System.Windows.Forms.Label();
            this.cmdtps = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherLesMenusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burgersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saladesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dessertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajtProduitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envoyerMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherLesAbonnesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objcmd = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.basemacdoDataSet = new test_BDD_interface.basemacdoDataSet();
            this.bURGERSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bURGERSTableAdapter = new test_BDD_interface.basemacdoDataSetTableAdapters.BURGERSTableAdapter();
            this.tableAdapterManager = new test_BDD_interface.basemacdoDataSetTableAdapters.TableAdapterManager();
            this.dESSERTSTableAdapter = new test_BDD_interface.basemacdoDataSetTableAdapters.DESSERTSTableAdapter();
            this.sALADESTableAdapter = new test_BDD_interface.basemacdoDataSetTableAdapters.SALADESTableAdapter();
            this.dESSERTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sALADESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basemacdoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bURGERSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESSERTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALADESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 200);
            this.button1.TabIndex = 0;
            this.button1.Text = "Burgers";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.TextChanged += new System.EventHandler(this.button1_TextChanged);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(272, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 200);
            this.button2.TabIndex = 1;
            this.button2.Text = "Salades";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGray;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(12, 349);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 200);
            this.button3.TabIndex = 2;
            this.button3.Text = "Desserts";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(306, 405);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "Retour";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(306, 349);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "Valider";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(306, 461);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 50);
            this.button6.TabIndex = 5;
            this.button6.Text = "Annuler";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // archi
            // 
            this.archi.AutoSize = true;
            this.archi.Location = new System.Drawing.Point(303, 233);
            this.archi.Name = "archi";
            this.archi.Size = new System.Drawing.Size(63, 13);
            this.archi.TabIndex = 6;
            this.archi.Text = "architecture";
            this.archi.Visible = false;
            this.archi.TextChanged += new System.EventHandler(this.archi_TextChanged);
            this.archi.Click += new System.EventHandler(this.archi_Click);
            // 
            // cmdtps
            // 
            this.cmdtps.AutoSize = true;
            this.cmdtps.Location = new System.Drawing.Point(303, 277);
            this.cmdtps.Name = "cmdtps";
            this.cmdtps.Size = new System.Drawing.Size(30, 13);
            this.cmdtps.TabIndex = 7;
            this.cmdtps.Text = "drive";
            this.cmdtps.Visible = false;
            this.cmdtps.Click += new System.EventHandler(this.cmdtps_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menusToolStripMenuItem,
            this.ajtProduitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menusToolStripMenuItem
            // 
            this.menusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afficherLesMenusToolStripMenuItem});
            this.menusToolStripMenuItem.Name = "menusToolStripMenuItem";
            this.menusToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.menusToolStripMenuItem.Text = "Menus";
            this.menusToolStripMenuItem.Click += new System.EventHandler(this.menusToolStripMenuItem_Click);
            // 
            // afficherLesMenusToolStripMenuItem
            // 
            this.afficherLesMenusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.burgersToolStripMenuItem,
            this.saladesToolStripMenuItem,
            this.dessertsToolStripMenuItem});
            this.afficherLesMenusToolStripMenuItem.Name = "afficherLesMenusToolStripMenuItem";
            this.afficherLesMenusToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.afficherLesMenusToolStripMenuItem.Text = "Afficher les menus";
            this.afficherLesMenusToolStripMenuItem.Click += new System.EventHandler(this.afficherLesMenusToolStripMenuItem_Click);
            // 
            // burgersToolStripMenuItem
            // 
            this.burgersToolStripMenuItem.Name = "burgersToolStripMenuItem";
            this.burgersToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.burgersToolStripMenuItem.Text = "Burgers";
            this.burgersToolStripMenuItem.Click += new System.EventHandler(this.burgersToolStripMenuItem_Click);
            // 
            // saladesToolStripMenuItem
            // 
            this.saladesToolStripMenuItem.Name = "saladesToolStripMenuItem";
            this.saladesToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.saladesToolStripMenuItem.Text = "Salades";
            this.saladesToolStripMenuItem.Click += new System.EventHandler(this.saladesToolStripMenuItem_Click);
            // 
            // dessertsToolStripMenuItem
            // 
            this.dessertsToolStripMenuItem.Name = "dessertsToolStripMenuItem";
            this.dessertsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.dessertsToolStripMenuItem.Text = "Desserts";
            this.dessertsToolStripMenuItem.Click += new System.EventHandler(this.dessertsToolStripMenuItem_Click);
            // 
            // ajtProduitToolStripMenuItem
            // 
            this.ajtProduitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.suprimerToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.envoyerMailToolStripMenuItem,
            this.afficherLesAbonnesToolStripMenuItem});
            this.ajtProduitToolStripMenuItem.Name = "ajtProduitToolStripMenuItem";
            this.ajtProduitToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.ajtProduitToolStripMenuItem.Text = "Gestion produit";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // suprimerToolStripMenuItem
            // 
            this.suprimerToolStripMenuItem.Name = "suprimerToolStripMenuItem";
            this.suprimerToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.suprimerToolStripMenuItem.Text = "Supprimer";
            this.suprimerToolStripMenuItem.Click += new System.EventHandler(this.suprimerToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // envoyerMailToolStripMenuItem
            // 
            this.envoyerMailToolStripMenuItem.Name = "envoyerMailToolStripMenuItem";
            this.envoyerMailToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.envoyerMailToolStripMenuItem.Text = "Envoyer mail";
            this.envoyerMailToolStripMenuItem.Click += new System.EventHandler(this.envoyerMailToolStripMenuItem_Click);
            // 
            // afficherLesAbonnesToolStripMenuItem
            // 
            this.afficherLesAbonnesToolStripMenuItem.Name = "afficherLesAbonnesToolStripMenuItem";
            this.afficherLesAbonnesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.afficherLesAbonnesToolStripMenuItem.Text = "Afficher les abonnes";
            this.afficherLesAbonnesToolStripMenuItem.Click += new System.EventHandler(this.afficherLesAbonnesToolStripMenuItem_Click);
            // 
            // objcmd
            // 
            this.objcmd.AutoSize = true;
            this.objcmd.Location = new System.Drawing.Point(303, 255);
            this.objcmd.Name = "objcmd";
            this.objcmd.Size = new System.Drawing.Size(41, 13);
            this.objcmd.TabIndex = 9;
            this.objcmd.Text = "objcmd";
            this.objcmd.Visible = false;
            this.objcmd.Click += new System.EventHandler(this.objcmd_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(306, 517);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "commande entiere";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "0";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(54, 233);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 100);
            this.button7.TabIndex = 12;
            this.button7.Text = "Nouveautes";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // basemacdoDataSet
            // 
            this.basemacdoDataSet.DataSetName = "basemacdoDataSet";
            this.basemacdoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bURGERSBindingSource
            // 
            this.bURGERSBindingSource.DataMember = "BURGERS";
            this.bURGERSBindingSource.DataSource = this.basemacdoDataSet;
            // 
            // bURGERSTableAdapter
            // 
            this.bURGERSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ADRESSESTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BURGERSTableAdapter = this.bURGERSTableAdapter;
            this.tableAdapterManager.DESSERTSTableAdapter = this.dESSERTSTableAdapter;
            this.tableAdapterManager.SALADESTableAdapter = this.sALADESTableAdapter;
            this.tableAdapterManager.UpdateOrder = test_BDD_interface.basemacdoDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dESSERTSTableAdapter
            // 
            this.dESSERTSTableAdapter.ClearBeforeFill = true;
            // 
            // sALADESTableAdapter
            // 
            this.sALADESTableAdapter.ClearBeforeFill = true;
            // 
            // dESSERTSBindingSource
            // 
            this.dESSERTSBindingSource.DataMember = "DESSERTS";
            this.dESSERTSBindingSource.DataSource = this.basemacdoDataSet;
            // 
            // sALADESBindingSource
            // 
            this.sALADESBindingSource.DataMember = "SALADES";
            this.sALADESBindingSource.DataSource = this.basemacdoDataSet;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.objcmd);
            this.Controls.Add(this.cmdtps);
            this.Controls.Add(this.archi);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Mac Ventre DRIVE";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basemacdoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bURGERSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESSERTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALADESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label cmdtps;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherLesMenusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burgersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saladesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dessertsToolStripMenuItem;
        private basemacdoDataSet basemacdoDataSet;
        private System.Windows.Forms.BindingSource bURGERSBindingSource;
        private basemacdoDataSetTableAdapters.BURGERSTableAdapter bURGERSTableAdapter;
        private basemacdoDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private basemacdoDataSetTableAdapters.DESSERTSTableAdapter dESSERTSTableAdapter;
        private System.Windows.Forms.BindingSource dESSERTSBindingSource;
        private basemacdoDataSetTableAdapters.SALADESTableAdapter sALADESTableAdapter;
        private System.Windows.Forms.BindingSource sALADESBindingSource;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ajtProduitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripMenuItem envoyerMailToolStripMenuItem;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Label objcmd;
        public System.Windows.Forms.Label archi;
        private System.Windows.Forms.ToolStripMenuItem afficherLesAbonnesToolStripMenuItem;
    }
}

