﻿namespace Parcial2_RafaelAbreu
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaturaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.estudi9an9te7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrosToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignaturaToolStripMenuItem,
            this.estudiantesToolStripMenuItem,
            this.inscripcionToolStripMenuItem});
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.registrosToolStripMenuItem.Text = "Registros";
            // 
            // asignaturaToolStripMenuItem
            // 
            this.asignaturaToolStripMenuItem.Name = "asignaturaToolStripMenuItem";
            this.asignaturaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.asignaturaToolStripMenuItem.Text = "Asignatura";
            this.asignaturaToolStripMenuItem.Click += new System.EventHandler(this.AsignaturaToolStripMenuItem_Click);
            // 
            // estudiantesToolStripMenuItem
            // 
            this.estudiantesToolStripMenuItem.Name = "estudiantesToolStripMenuItem";
            this.estudiantesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.estudiantesToolStripMenuItem.Text = "Estudiantes";
            this.estudiantesToolStripMenuItem.Click += new System.EventHandler(this.EstudiantesToolStripMenuItem_Click);
            // 
            // inscripcionToolStripMenuItem
            // 
            this.inscripcionToolStripMenuItem.Name = "inscripcionToolStripMenuItem";
            this.inscripcionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.inscripcionToolStripMenuItem.Text = "Inscripcion";
            this.inscripcionToolStripMenuItem.Click += new System.EventHandler(this.InscripcionToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignaturaToolStripMenuItem1,
            this.estudi9an9te7ToolStripMenuItem,
            this.inscripcionToolStripMenuItem1});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // asignaturaToolStripMenuItem1
            // 
            this.asignaturaToolStripMenuItem1.Name = "asignaturaToolStripMenuItem1";
            this.asignaturaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.asignaturaToolStripMenuItem1.Text = "Asignatura";
            this.asignaturaToolStripMenuItem1.Click += new System.EventHandler(this.AsignaturaToolStripMenuItem1_Click);
            // 
            // estudi9an9te7ToolStripMenuItem
            // 
            this.estudi9an9te7ToolStripMenuItem.Name = "estudi9an9te7ToolStripMenuItem";
            this.estudi9an9te7ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.estudi9an9te7ToolStripMenuItem.Text = "Estudiantes";
            this.estudi9an9te7ToolStripMenuItem.Click += new System.EventHandler(this.Estudi9an9te7ToolStripMenuItem_Click);
            // 
            // inscripcionToolStripMenuItem1
            // 
            this.inscripcionToolStripMenuItem1.Name = "inscripcionToolStripMenuItem1";
            this.inscripcionToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.inscripcionToolStripMenuItem1.Text = "Inscripcion";
            this.inscripcionToolStripMenuItem1.Click += new System.EventHandler(this.InscripcionToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estudiantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaturaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem estudi9an9te7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionToolStripMenuItem1;
    }
}

