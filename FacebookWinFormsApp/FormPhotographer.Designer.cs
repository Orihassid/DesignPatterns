
namespace BasicFacebookFeatures
{
    partial class FormPhotographer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label createdTimeLabel;
            System.Windows.Forms.Label linkLabel;
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.buttonBigger = new System.Windows.Forms.Button();
            this.buttonSmaller = new System.Windows.Forms.Button();
            this.buttonDoubleSize = new System.Windows.Forms.Button();
            this.buttonHalfSize = new System.Windows.Forms.Button();
            this.buttonDisappearingPicture = new System.Windows.Forms.Button();
            this.buttonBlinkingPicture = new System.Windows.Forms.Button();
            this.photoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.createdTimeLabelValue = new System.Windows.Forms.Label();
            this.linkTextBox = new System.Windows.Forms.TextBox();
            this.textBoxDataBindingBackground = new System.Windows.Forms.TextBox();
            this.labelPhotoDate = new System.Windows.Forms.Label();
            this.labelPhotoLink = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            createdTimeLabel = new System.Windows.Forms.Label();
            linkLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.photoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // createdTimeLabel
            // 
            createdTimeLabel.AutoSize = true;
            createdTimeLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            createdTimeLabel.Location = new System.Drawing.Point(4, 221);
            createdTimeLabel.Name = "createdTimeLabel";
            createdTimeLabel.Size = new System.Drawing.Size(73, 13);
            createdTimeLabel.TabIndex = 8;
            createdTimeLabel.Text = "Created Time:";
            createdTimeLabel.Visible = false;
            // 
            // linkLabel
            // 
            linkLabel.AutoSize = true;
            linkLabel.Location = new System.Drawing.Point(6, 250);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new System.Drawing.Size(30, 13);
            linkLabel.TabIndex = 10;
            linkLabel.Text = "Link:";
            linkLabel.Visible = false;
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Location = new System.Drawing.Point(2, 11);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPhoto.TabIndex = 0;
            this.buttonAddPhoto.Text = "Add Photo";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // buttonBigger
            // 
            this.buttonBigger.Location = new System.Drawing.Point(2, 40);
            this.buttonBigger.Name = "buttonBigger";
            this.buttonBigger.Size = new System.Drawing.Size(119, 23);
            this.buttonBigger.TabIndex = 1;
            this.buttonBigger.Text = "Bigger Image";
            this.buttonBigger.UseVisualStyleBackColor = true;
            this.buttonBigger.Click += new System.EventHandler(this.buttonBigger_Click);
            // 
            // buttonSmaller
            // 
            this.buttonSmaller.Location = new System.Drawing.Point(2, 69);
            this.buttonSmaller.Name = "buttonSmaller";
            this.buttonSmaller.Size = new System.Drawing.Size(119, 23);
            this.buttonSmaller.TabIndex = 2;
            this.buttonSmaller.Text = "Smaller Image";
            this.buttonSmaller.UseVisualStyleBackColor = true;
            this.buttonSmaller.Click += new System.EventHandler(this.buttonSmaller_Click);
            // 
            // buttonDoubleSize
            // 
            this.buttonDoubleSize.Location = new System.Drawing.Point(2, 98);
            this.buttonDoubleSize.Name = "buttonDoubleSize";
            this.buttonDoubleSize.Size = new System.Drawing.Size(144, 23);
            this.buttonDoubleSize.TabIndex = 3;
            this.buttonDoubleSize.Text = " Add Double Size Photo";
            this.buttonDoubleSize.UseVisualStyleBackColor = true;
            this.buttonDoubleSize.Click += new System.EventHandler(this.buttonDoubleSize_Click);
            // 
            // buttonHalfSize
            // 
            this.buttonHalfSize.Location = new System.Drawing.Point(2, 127);
            this.buttonHalfSize.Name = "buttonHalfSize";
            this.buttonHalfSize.Size = new System.Drawing.Size(144, 23);
            this.buttonHalfSize.TabIndex = 4;
            this.buttonHalfSize.Text = "Add Half Size Photo";
            this.buttonHalfSize.UseVisualStyleBackColor = true;
            this.buttonHalfSize.Click += new System.EventHandler(this.buttonHalfSize_Click);
            // 
            // buttonDisappearingPicture
            // 
            this.buttonDisappearingPicture.Location = new System.Drawing.Point(2, 156);
            this.buttonDisappearingPicture.Name = "buttonDisappearingPicture";
            this.buttonDisappearingPicture.Size = new System.Drawing.Size(144, 23);
            this.buttonDisappearingPicture.TabIndex = 5;
            this.buttonDisappearingPicture.Text = "Add Disappearing Picture";
            this.buttonDisappearingPicture.UseVisualStyleBackColor = true;
            this.buttonDisappearingPicture.Click += new System.EventHandler(this.buttonDisappearingPicture_Click);
            // 
            // buttonBlinkingPicture
            // 
            this.buttonBlinkingPicture.Location = new System.Drawing.Point(2, 185);
            this.buttonBlinkingPicture.Name = "buttonBlinkingPicture";
            this.buttonBlinkingPicture.Size = new System.Drawing.Size(144, 23);
            this.buttonBlinkingPicture.TabIndex = 6;
            this.buttonBlinkingPicture.Text = "Add Blinking Picture";
            this.buttonBlinkingPicture.UseVisualStyleBackColor = true;
            this.buttonBlinkingPicture.Click += new System.EventHandler(this.buttonBlinkingPicture_Click);
            // 
            // photoBindingSource
            // 
            this.photoBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Photo);
            // 
            // createdTimeLabelValue
            // 
            this.createdTimeLabelValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "CreatedTime", true));
            this.createdTimeLabelValue.Location = new System.Drawing.Point(6, 217);
            this.createdTimeLabelValue.Name = "createdTimeLabelValue";
            this.createdTimeLabelValue.Size = new System.Drawing.Size(69, 23);
            this.createdTimeLabelValue.TabIndex = 9;
            // 
            // linkTextBox
            // 
            this.linkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "Link", true));
            this.linkTextBox.Location = new System.Drawing.Point(7, 250);
            this.linkTextBox.Name = "linkTextBox";
            this.linkTextBox.Size = new System.Drawing.Size(236, 20);
            this.linkTextBox.TabIndex = 11;
            // 
            // textBoxDataBindingBackground
            // 
            this.textBoxDataBindingBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBoxDataBindingBackground.Enabled = false;
            this.textBoxDataBindingBackground.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxDataBindingBackground.Location = new System.Drawing.Point(2, 214);
            this.textBoxDataBindingBackground.Multiline = true;
            this.textBoxDataBindingBackground.Name = "textBoxDataBindingBackground";
            this.textBoxDataBindingBackground.Size = new System.Drawing.Size(268, 83);
            this.textBoxDataBindingBackground.TabIndex = 12;
            // 
            // labelPhotoDate
            // 
            this.labelPhotoDate.AutoSize = true;
            this.labelPhotoDate.Location = new System.Drawing.Point(81, 221);
            this.labelPhotoDate.Name = "labelPhotoDate";
            this.labelPhotoDate.Size = new System.Drawing.Size(173, 13);
            this.labelPhotoDate.TabIndex = 13;
            this.labelPhotoDate.Text = "is the date the photo was uploaded";
            // 
            // labelPhotoLink
            // 
            this.labelPhotoLink.AutoSize = true;
            this.labelPhotoLink.Location = new System.Drawing.Point(9, 277);
            this.labelPhotoLink.Name = "labelPhotoLink";
            this.labelPhotoLink.Size = new System.Drawing.Size(147, 13);
            this.labelPhotoLink.TabIndex = 14;
            this.labelPhotoLink.Text = "Here is a link to the last photo";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(7, 304);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(7, 334);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 16;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(7, 364);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 17;
            this.buttonReset.Text = "First Picture";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FormPhotographer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelPhotoLink);
            this.Controls.Add(this.labelPhotoDate);
            this.Controls.Add(this.linkTextBox);
            this.Controls.Add(linkLabel);
            this.Controls.Add(this.createdTimeLabelValue);
            this.Controls.Add(createdTimeLabel);
            this.Controls.Add(this.textBoxDataBindingBackground);
            this.Controls.Add(this.buttonBlinkingPicture);
            this.Controls.Add(this.buttonDisappearingPicture);
            this.Controls.Add(this.buttonHalfSize);
            this.Controls.Add(this.buttonDoubleSize);
            this.Controls.Add(this.buttonSmaller);
            this.Controls.Add(this.buttonBigger);
            this.Controls.Add(this.buttonAddPhoto);
            this.Name = "FormPhotographer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photographer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.photoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddPhoto;
        private System.Windows.Forms.Button buttonBigger;
        private System.Windows.Forms.Button buttonSmaller;
        private System.Windows.Forms.Button buttonDoubleSize;
        private System.Windows.Forms.Button buttonHalfSize;
        private System.Windows.Forms.Button buttonDisappearingPicture;
        private System.Windows.Forms.Button buttonBlinkingPicture;
        private System.Windows.Forms.BindingSource photoBindingSource;
        private System.Windows.Forms.Label createdTimeLabelValue;
        private System.Windows.Forms.TextBox linkTextBox;
        private System.Windows.Forms.TextBox textBoxDataBindingBackground;
        private System.Windows.Forms.Label labelPhotoDate;
        private System.Windows.Forms.Label labelPhotoLink;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonReset;
    }
}