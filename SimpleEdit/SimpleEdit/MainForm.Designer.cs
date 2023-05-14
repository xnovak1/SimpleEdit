using System.Runtime.CompilerServices;

namespace SimpleEdit
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsBox = new System.Windows.Forms.GroupBox();
            this.nukeButton = new System.Windows.Forms.RadioButton();
            this.bigBlurButton = new System.Windows.Forms.RadioButton();
            this.smallBlurButton = new System.Windows.Forms.RadioButton();
            this.flipImageButton = new System.Windows.Forms.RadioButton();
            this.invertColorsButton = new System.Windows.Forms.RadioButton();
            this.grayscaleButton = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.optionsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadButton,
            this.saveButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1182, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadButton
            // 
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(56, 24);
            this.loadButton.Text = "Load";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(54, 24);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // optionsBox
            // 
            this.optionsBox.Controls.Add(this.nukeButton);
            this.optionsBox.Controls.Add(this.bigBlurButton);
            this.optionsBox.Controls.Add(this.smallBlurButton);
            this.optionsBox.Controls.Add(this.flipImageButton);
            this.optionsBox.Controls.Add(this.invertColorsButton);
            this.optionsBox.Controls.Add(this.grayscaleButton);
            this.optionsBox.Location = new System.Drawing.Point(42, 65);
            this.optionsBox.Name = "optionsBox";
            this.optionsBox.Size = new System.Drawing.Size(250, 359);
            this.optionsBox.TabIndex = 1;
            this.optionsBox.TabStop = false;
            this.optionsBox.Text = "Choose an edit:";
            // 
            // nukeButton
            // 
            this.nukeButton.AutoSize = true;
            this.nukeButton.Location = new System.Drawing.Point(6, 196);
            this.nukeButton.Name = "nukeButton";
            this.nukeButton.Size = new System.Drawing.Size(64, 24);
            this.nukeButton.TabIndex = 5;
            this.nukeButton.TabStop = true;
            this.nukeButton.Text = "Nuke";
            this.nukeButton.UseVisualStyleBackColor = true;
            // 
            // bigBlurButton
            // 
            this.bigBlurButton.AutoSize = true;
            this.bigBlurButton.Location = new System.Drawing.Point(6, 165);
            this.bigBlurButton.Name = "bigBlurButton";
            this.bigBlurButton.Size = new System.Drawing.Size(135, 24);
            this.bigBlurButton.TabIndex = 4;
            this.bigBlurButton.TabStop = true;
            this.bigBlurButton.Text = "Big blur (SLOW)";
            this.bigBlurButton.UseVisualStyleBackColor = true;
            // 
            // smallBlurButton
            // 
            this.smallBlurButton.AutoSize = true;
            this.smallBlurButton.Location = new System.Drawing.Point(6, 136);
            this.smallBlurButton.Name = "smallBlurButton";
            this.smallBlurButton.Size = new System.Drawing.Size(97, 24);
            this.smallBlurButton.TabIndex = 3;
            this.smallBlurButton.TabStop = true;
            this.smallBlurButton.Text = "Small blur";
            this.smallBlurButton.UseVisualStyleBackColor = true;
            // 
            // flipImageButton
            // 
            this.flipImageButton.AutoSize = true;
            this.flipImageButton.Location = new System.Drawing.Point(6, 107);
            this.flipImageButton.Name = "flipImageButton";
            this.flipImageButton.Size = new System.Drawing.Size(100, 24);
            this.flipImageButton.TabIndex = 2;
            this.flipImageButton.TabStop = true;
            this.flipImageButton.Text = "Flip image";
            this.flipImageButton.UseVisualStyleBackColor = true;
            // 
            // invertColorsButton
            // 
            this.invertColorsButton.AutoSize = true;
            this.invertColorsButton.Location = new System.Drawing.Point(6, 76);
            this.invertColorsButton.Name = "invertColorsButton";
            this.invertColorsButton.Size = new System.Drawing.Size(111, 24);
            this.invertColorsButton.TabIndex = 1;
            this.invertColorsButton.TabStop = true;
            this.invertColorsButton.Text = "Invert colors";
            this.invertColorsButton.UseVisualStyleBackColor = true;
            // 
            // grayscaleButton
            // 
            this.grayscaleButton.AutoSize = true;
            this.grayscaleButton.Location = new System.Drawing.Point(6, 45);
            this.grayscaleButton.Name = "grayscaleButton";
            this.grayscaleButton.Size = new System.Drawing.Size(93, 24);
            this.grayscaleButton.TabIndex = 0;
            this.grayscaleButton.TabStop = true;
            this.grayscaleButton.Text = "Grayscale";
            this.grayscaleButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(350, 31);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(787, 693);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(110, 451);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(114, 49);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(110, 523);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(114, 49);
            this.undoButton.TabIndex = 4;
            this.undoButton.Text = "Undo changes";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.optionsBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleEdit";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.optionsBox.ResumeLayout(false);
            this.optionsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadButton;
        private ToolStripMenuItem saveButton;
        private GroupBox optionsBox;
        private RadioButton smallBlurButton;
        private RadioButton flipImageButton;
        private RadioButton invertColorsButton;
        private RadioButton grayscaleButton;
        private RadioButton bigBlurButton;
        private PictureBox pictureBox;
        private Button confirmButton;
        private RadioButton nukeButton;
        private Button undoButton;
    }
}