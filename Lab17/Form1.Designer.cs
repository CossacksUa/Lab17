namespace Lab17
{
    partial class Form1
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
            messagesListBox = new ListBox();
            inputTextBox = new TextBox();
            sendButton = new Button();
            userNameTextBox = new TextBox();
            connectButton = new Button();
            SuspendLayout();
            // 
            // messagesListBox
            // 
            messagesListBox.FormattingEnabled = true;
            messagesListBox.ItemHeight = 15;
            messagesListBox.Location = new Point(10, 11);
            messagesListBox.Name = "messagesListBox";
            messagesListBox.Size = new Size(322, 244);
            messagesListBox.TabIndex = 0;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(360, 204);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(251, 23);
            inputTextBox.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(617, 203);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(66, 22);
            sendButton.TabIndex = 2;
            sendButton.Text = "Відправити";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(360, 23);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(251, 23);
            userNameTextBox.TabIndex = 3;
            userNameTextBox.Text = "Користувач";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(616, 23);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(66, 22);
            connectButton.TabIndex = 4;
            connectButton.Text = "Підключитись";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 322);
            Controls.Add(connectButton);
            Controls.Add(userNameTextBox);
            Controls.Add(sendButton);
            Controls.Add(inputTextBox);
            Controls.Add(messagesListBox);
            Name = "Form1";
            Text = "Чат";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox messagesListBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Button connectButton;
    }
}
