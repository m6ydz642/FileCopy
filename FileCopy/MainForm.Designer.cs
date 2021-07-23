
namespace FileCopy
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.targetdir = new System.Windows.Forms.TextBox();
            this.sourcedirtextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일복사수동ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourcelabel = new System.Windows.Forms.Label();
            this.targetlabel = new System.Windows.Forms.Label();
            this.updatebutton = new System.Windows.Forms.Button();
            this.sourcefilelistlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sourcefllelistBox = new System.Windows.Forms.ListBox();
            this.targetfilelistBox = new System.Windows.Forms.ListBox();
            this.sourcedirectorybutton = new System.Windows.Forms.Button();
            this.targetdirectorybutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetdir
            // 
            this.targetdir.Location = new System.Drawing.Point(14, 99);
            this.targetdir.Name = "targetdir";
            this.targetdir.Size = new System.Drawing.Size(786, 21);
            this.targetdir.TabIndex = 0;
            // 
            // sourcedirtextBox
            // 
            this.sourcedirtextBox.Location = new System.Drawing.Point(14, 51);
            this.sourcedirtextBox.Name = "sourcedirtextBox";
            this.sourcedirtextBox.Size = new System.Drawing.Size(786, 21);
            this.sourcedirtextBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.targetdirectorybutton);
            this.panel1.Controls.Add(this.sourcedirectorybutton);
            this.panel1.Controls.Add(this.targetfilelistBox);
            this.panel1.Controls.Add(this.sourcefllelistBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sourcefilelistlabel);
            this.panel1.Controls.Add(this.updatebutton);
            this.panel1.Controls.Add(this.targetlabel);
            this.panel1.Controls.Add(this.sourcelabel);
            this.panel1.Controls.Add(this.sourcedirtextBox);
            this.panel1.Controls.Add(this.targetdir);
            this.panel1.Location = new System.Drawing.Point(-2, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 531);
            this.panel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1106, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일복사수동ToolStripMenuItem});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // 파일복사수동ToolStripMenuItem
            // 
            this.파일복사수동ToolStripMenuItem.Name = "파일복사수동ToolStripMenuItem";
            this.파일복사수동ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.파일복사수동ToolStripMenuItem.Text = "파일 복사 (수동)";
            // 
            // sourcelabel
            // 
            this.sourcelabel.AutoSize = true;
            this.sourcelabel.Location = new System.Drawing.Point(12, 32);
            this.sourcelabel.Name = "sourcelabel";
            this.sourcelabel.Size = new System.Drawing.Size(57, 12);
            this.sourcelabel.TabIndex = 2;
            this.sourcelabel.Text = "원본 경로";
            // 
            // targetlabel
            // 
            this.targetlabel.AutoSize = true;
            this.targetlabel.Location = new System.Drawing.Point(12, 81);
            this.targetlabel.Name = "targetlabel";
            this.targetlabel.Size = new System.Drawing.Size(57, 12);
            this.targetlabel.TabIndex = 3;
            this.targetlabel.Text = "타겟 경로";
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(806, 46);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(80, 74);
            this.updatebutton.TabIndex = 4;
            this.updatebutton.Text = "업데이트";
            this.updatebutton.UseVisualStyleBackColor = true;
            // 
            // sourcefilelistlabel
            // 
            this.sourcefilelistlabel.AutoSize = true;
            this.sourcefilelistlabel.Location = new System.Drawing.Point(14, 183);
            this.sourcefilelistlabel.Name = "sourcefilelistlabel";
            this.sourcefilelistlabel.Size = new System.Drawing.Size(125, 12);
            this.sourcefilelistlabel.TabIndex = 5;
            this.sourcefilelistlabel.Text = "원본 경로 파일 리스트";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "타겟 경로 파일 리스트";
            // 
            // sourcefllelistBox
            // 
            this.sourcefllelistBox.FormattingEnabled = true;
            this.sourcefllelistBox.ItemHeight = 12;
            this.sourcefllelistBox.Location = new System.Drawing.Point(14, 208);
            this.sourcefllelistBox.Name = "sourcefllelistBox";
            this.sourcefllelistBox.Size = new System.Drawing.Size(529, 292);
            this.sourcefllelistBox.TabIndex = 7;
            // 
            // targetfilelistBox
            // 
            this.targetfilelistBox.FormattingEnabled = true;
            this.targetfilelistBox.ItemHeight = 12;
            this.targetfilelistBox.Location = new System.Drawing.Point(567, 208);
            this.targetfilelistBox.Name = "targetfilelistBox";
            this.targetfilelistBox.Size = new System.Drawing.Size(529, 292);
            this.targetfilelistBox.TabIndex = 8;
            // 
            // sourcedirectorybutton
            // 
            this.sourcedirectorybutton.Location = new System.Drawing.Point(75, 27);
            this.sourcedirectorybutton.Name = "sourcedirectorybutton";
            this.sourcedirectorybutton.Size = new System.Drawing.Size(70, 23);
            this.sourcedirectorybutton.TabIndex = 9;
            this.sourcedirectorybutton.Text = "경로설정";
            this.sourcedirectorybutton.UseVisualStyleBackColor = true;
            // 
            // targetdirectorybutton
            // 
            this.targetdirectorybutton.Location = new System.Drawing.Point(75, 74);
            this.targetdirectorybutton.Name = "targetdirectorybutton";
            this.targetdirectorybutton.Size = new System.Drawing.Size(70, 23);
            this.targetdirectorybutton.TabIndex = 10;
            this.targetdirectorybutton.Text = "경로설정";
            this.targetdirectorybutton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FileCopyProgram";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox targetdir;
        private System.Windows.Forms.TextBox sourcedirtextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox targetfilelistBox;
        private System.Windows.Forms.ListBox sourcefllelistBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sourcefilelistlabel;
        private System.Windows.Forms.Button updatebutton;
        private System.Windows.Forms.Label targetlabel;
        private System.Windows.Forms.Label sourcelabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일복사수동ToolStripMenuItem;
        private System.Windows.Forms.Button targetdirectorybutton;
        private System.Windows.Forms.Button sourcedirectorybutton;
    }
}

