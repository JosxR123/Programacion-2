
using System;
using System.Windows.Forms;

namespace AppComunidad
{
    public partial class Form1 : Form
    {
        private ComboBox comboType;
        private TextBox txtName;
        private TextBox txtExtra;
        private Button btnAdd;
        private Button btnClear;
        private ListBox listMembers;
        private Label lblType;
        private Label lblName;
        private Label lblExtra;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.comboType = new ComboBox();
            this.txtName = new TextBox();
            this.txtExtra = new TextBox();
            this.btnAdd = new Button();
            this.btnClear = new Button();
            this.listMembers = new ListBox();
            this.lblType = new Label();
            this.lblName = new Label();
            this.lblExtra = new Label();
            this.SuspendLayout();
            this.lblType.Text = "Type";
            this.lblType.Location = new System.Drawing.Point(25, 20);
            this.comboType.Items.AddRange(new object[] { "Student", "ExStudent", "Administrative", "Teacher", "Administrator", "Master" });
            this.comboType.Location = new System.Drawing.Point(25, 40);
            this.comboType.Size = new System.Drawing.Size(180, 21);
            this.lblName.Text = "Name";
            this.lblName.Location = new System.Drawing.Point(25, 70);
            this.txtName.Location = new System.Drawing.Point(25, 90);
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.lblExtra.Text = "Extra Data";
            this.lblExtra.Location = new System.Drawing.Point(25, 120);
            this.txtExtra.Location = new System.Drawing.Point(25, 140);
            this.txtExtra.Size = new System.Drawing.Size(180, 20);
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(25, 180);
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(115, 180);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.listMembers.Location = new System.Drawing.Point(230, 40);
            this.listMembers.Size = new System.Drawing.Size(320, 160);
            this.ClientSize = new System.Drawing.Size(580, 250);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.txtExtra);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listMembers);
            this.Text = "Community App";
            this.ResumeLayout(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string extra = txtExtra.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)) return;
            CommunityMember m;
            string type = comboType.SelectedItem.ToString();
            if (type == "Student") m = new Student { Name = name, Career = extra };
            else if (type == "ExStudent") m = new ExStudent { Name = name, GraduationYear = extra };
            else if (type == "Administrative") m = new Administrative { Name = name, Position = extra };
            else if (type == "Teacher") m = new Teacher { Name = name, Subject = extra };
            else if (type == "Administrator") m = new Administrator { Name = name, Area = extra };
            else m = new Master { Name = name, Grade = extra };
            listMembers.Items.Add(m.Describe());
            txtName.Clear();
            txtExtra.Clear();
            txtName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listMembers.Items.Clear();
        }
    }

    public abstract class CommunityMember
    {
        public string Name { get; set; }
        public virtual string Describe()
        {
            return GetType().Name + ": " + Name;
        }
    }

    public class Employee : CommunityMember
    {
        public string Area { get; set; }
        public override string Describe()
        {
            return GetType().Name + ": " + Name + " - " + Area;
        }
    }

    public class Student : CommunityMember
    {
        public string Career { get; set; }
        public override string Describe()
        {
            return GetType().Name + ": " + Name + " - " + Career;
        }
    }

    public class ExStudent : CommunityMember
    {
        public string GraduationYear { get; set; }
        public override string Describe()
        {
            return GetType().Name + ": " + Name + " - " + GraduationYear;
        }
    }

    public class Teacher : Employee
    {
        public string Subject { get; set; }
        public override string Describe()
        {
            return GetType().Name + ": " + Name + " - " + Subject;
        }
    }

    public class Administrative : Employee
    {
        public string Position { get; set; }
        public override string Describe()
        {
            return GetType().Name + ": " + Name + " - " + Position;
        }
    }

    public class Administrator : Teacher
    {
        public string Area { get; set; }
        public override string Describe()
        {
            return GetType().Name + ": " + Name + " - " + Area;
        }
    }

    public class Master : Teacher
    {
        public string Grade { get; set; }
        public override string Describe()
        {
            return GetType().Name + ": " + Name + " - " + Grade;
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
