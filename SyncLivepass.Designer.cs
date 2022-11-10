
namespace Sync_Livepass
{
    partial class SyncLivepass
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncLivepass));
            this.btn_Descargar = new System.Windows.Forms.Button();
            this.txt_url_Bajada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_evento = new System.Windows.Forms.Label();
            this.cbox_evento = new System.Windows.Forms.ComboBox();
            this.txt_validator_code = new System.Windows.Forms.TextBox();
            this.lbl_estado2 = new System.Windows.Forms.Label();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cantidad_bajada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cantidad_subida = new System.Windows.Forms.TextBox();
            this.btn_reportar = new System.Windows.Forms.Button();
            this.txt_url_subida = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Descargar
            // 
            this.btn_Descargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_Descargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_Descargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Descargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Descargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Descargar.ForeColor = System.Drawing.Color.White;
            this.btn_Descargar.Location = new System.Drawing.Point(483, 232);
            this.btn_Descargar.Name = "btn_Descargar";
            this.btn_Descargar.Size = new System.Drawing.Size(166, 32);
            this.btn_Descargar.TabIndex = 48;
            this.btn_Descargar.Text = "Descargar";
            this.btn_Descargar.UseVisualStyleBackColor = false;
            this.btn_Descargar.Click += new System.EventHandler(this.btn_Descargar_Click);
            // 
            // txt_url_Bajada
            // 
            this.txt_url_Bajada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_url_Bajada.Location = new System.Drawing.Point(17, 143);
            this.txt_url_Bajada.Name = "txt_url_Bajada";
            this.txt_url_Bajada.Size = new System.Drawing.Size(633, 22);
            this.txt_url_Bajada.TabIndex = 47;
            this.txt_url_Bajada.Text = "https://livepass.com.ar/api/v1/validation/validator_codes/validator_code/codes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(17, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "URL Bajada";
            // 
            // lbl_evento
            // 
            this.lbl_evento.AutoSize = true;
            this.lbl_evento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_evento.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_evento.Location = new System.Drawing.Point(14, 72);
            this.lbl_evento.Name = "lbl_evento";
            this.lbl_evento.Size = new System.Drawing.Size(50, 16);
            this.lbl_evento.TabIndex = 45;
            this.lbl_evento.Text = "Evento";
            // 
            // cbox_evento
            // 
            this.cbox_evento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_evento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_evento.FormattingEnabled = true;
            this.cbox_evento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbox_evento.Location = new System.Drawing.Point(17, 91);
            this.cbox_evento.Name = "cbox_evento";
            this.cbox_evento.Size = new System.Drawing.Size(633, 24);
            this.cbox_evento.TabIndex = 44;
            this.cbox_evento.SelectedIndexChanged += new System.EventHandler(this.cbox_evento_SelectedIndexChanged);
            // 
            // txt_validator_code
            // 
            this.txt_validator_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_validator_code.Location = new System.Drawing.Point(16, 242);
            this.txt_validator_code.Name = "txt_validator_code";
            this.txt_validator_code.Size = new System.Drawing.Size(192, 22);
            this.txt_validator_code.TabIndex = 50;
            // 
            // lbl_estado2
            // 
            this.lbl_estado2.AutoSize = true;
            this.lbl_estado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_estado2.Location = new System.Drawing.Point(12, 431);
            this.lbl_estado2.Name = "lbl_estado2";
            this.lbl_estado2.Size = new System.Drawing.Size(58, 16);
            this.lbl_estado2.TabIndex = 49;
            this.lbl_estado2.Text = "Estado2";
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_estado.Location = new System.Drawing.Point(13, 411);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(51, 16);
            this.lbl_estado.TabIndex = 52;
            this.lbl_estado.Text = "Estado";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.progressBar1.Location = new System.Drawing.Point(16, 335);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(630, 73);
            this.progressBar1.TabIndex = 51;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(13, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "Validator Code";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sync_Livepass.Properties.Resources.logo_blanco;
            this.pictureBox1.Location = new System.Drawing.Point(331, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(246, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Cantidad de Tickets Bajada";
            // 
            // txt_cantidad_bajada
            // 
            this.txt_cantidad_bajada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantidad_bajada.Location = new System.Drawing.Point(249, 242);
            this.txt_cantidad_bajada.Name = "txt_cantidad_bajada";
            this.txt_cantidad_bajada.Size = new System.Drawing.Size(195, 22);
            this.txt_cantidad_bajada.TabIndex = 55;
            this.txt_cantidad_bajada.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(246, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 16);
            this.label4.TabIndex = 58;
            this.label4.Text = "Cantidad de Tickets  a Reportar";
            // 
            // txt_cantidad_subida
            // 
            this.txt_cantidad_subida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantidad_subida.Location = new System.Drawing.Point(249, 294);
            this.txt_cantidad_subida.Name = "txt_cantidad_subida";
            this.txt_cantidad_subida.Size = new System.Drawing.Size(195, 22);
            this.txt_cantidad_subida.TabIndex = 57;
            this.txt_cantidad_subida.Text = "20";
            // 
            // btn_reportar
            // 
            this.btn_reportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btn_reportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_reportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_reportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reportar.ForeColor = System.Drawing.Color.White;
            this.btn_reportar.Location = new System.Drawing.Point(483, 284);
            this.btn_reportar.Name = "btn_reportar";
            this.btn_reportar.Size = new System.Drawing.Size(166, 32);
            this.btn_reportar.TabIndex = 59;
            this.btn_reportar.Text = "Reportar";
            this.btn_reportar.UseVisualStyleBackColor = false;
            this.btn_reportar.Click += new System.EventHandler(this.btn_reportar_Click);
            // 
            // txt_url_subida
            // 
            this.txt_url_subida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_url_subida.Location = new System.Drawing.Point(16, 190);
            this.txt_url_subida.Name = "txt_url_subida";
            this.txt_url_subida.Size = new System.Drawing.Size(633, 22);
            this.txt_url_subida.TabIndex = 61;
            this.txt_url_subida.Text = "https://livepass.com.ar/api/v1/validation/validator_codes/validator_code/validate" +
    "_codes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(16, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 60;
            this.label5.Text = "URL Subida";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // SyncLivepass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(674, 467);
            this.Controls.Add(this.txt_url_subida);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_reportar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cantidad_subida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cantidad_bajada);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_estado);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txt_validator_code);
            this.Controls.Add(this.lbl_estado2);
            this.Controls.Add(this.btn_Descargar);
            this.Controls.Add(this.txt_url_Bajada);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_evento);
            this.Controls.Add(this.cbox_evento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SyncLivepass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sync Livepass V1.0.0";
            this.Load += new System.EventHandler(this.SyncLivepass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Descargar;
        private System.Windows.Forms.TextBox txt_url_Bajada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_evento;
        private System.Windows.Forms.ComboBox cbox_evento;
        private System.Windows.Forms.TextBox txt_validator_code;
        private System.Windows.Forms.Label lbl_estado2;
        private System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_cantidad_bajada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cantidad_subida;
        private System.Windows.Forms.Button btn_reportar;
        private System.Windows.Forms.TextBox txt_url_subida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer2;
    }
}

