
namespace Курсовая_по_аисд
{
    partial class ChangeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Что хотите сделать?";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(12, 41);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(124, 35);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить бронь";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(154, 41);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(147, 35);
            this.ChangeButton.TabIndex = 2;
            this.ChangeButton.Text = "Изменить бронь";
            this.ChangeButton.UseVisualStyleBackColor = true;
            // 
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 98);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ChangeForm";
            this.Text = "Редактирование брони";
            this.Load += new System.EventHandler(this.ChangeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ChangeButton;
    }
}