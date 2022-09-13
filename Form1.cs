namespace ProjectTADS;
public partial class Form1 : Form
{
    PictureBox LDLogo = new PictureBox();
    Button exit = new Button();
    TextBox username = new TextBox();
    TextBox password = new TextBox();
    Label usernameLabel = new Label();
    Label passwordLabel = new Label();
    Label LoginLabel = new Label();
    Button LoginButton = new Button();
    public Form1()
    {
        Font font = new Font("Open Sans", 12);
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        this.Size = new Size(700, 650); 
        this.Controls.Add(exit);
        this.BackColor = Color.Lavender;
        exit.Location = new Point(660,0);
        exit.Size = new Size(38, 38);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        exit.Click += new EventHandler(exit_Click);
        exit.Paint += new PaintEventHandler(exit_Paint);
        this.Paint += new PaintEventHandler(Form1_Paint);
        LDLogo.Image = Image.FromFile("LDLogo.png");
        LDLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        LDLogo.Size = new Size(485, 360);
        LDLogo.Location = new Point(90, 50);
        this.Controls.Add(LDLogo);
        usernameLabel.Text = "Username";
        usernameLabel.Font = font;
        usernameLabel.Location = new Point(130, 480);
        usernameLabel.Size = new Size(110, 30);
        this.Controls.Add(usernameLabel);
        passwordLabel.Text = "Password";
        passwordLabel.Font = font;
        passwordLabel.Location = new Point(130, 530);
        passwordLabel.Size = new Size(110, 30);
        passwordLabel.BackColor = Color.Transparent;
        this.Controls.Add(passwordLabel);
        username.Location = new Point(250, 480);
        username.Size = new Size(265, 20);
        this.Controls.Add(username);
        password.Location = new Point(250, 530);
        password.Size = new Size(265, 20);
        this.Controls.Add(password);
        this.CenterToScreen();
        LoginLabel.Text = "Welcome, please Login";
        LoginLabel.Font = new Font("Open Sans", 15);
        LoginLabel.Location = new Point(215, 400);
        LoginLabel.Size = new Size(300, 60);
        this.Controls.Add(LoginLabel);
        LoginButton.Text = "Login";
        LoginButton.Font = font;    
        LoginButton.Location = new Point(325, 560);
        LoginButton.Size = new Size(100, 50);
        LoginButton.Click += new EventHandler(LoginButton_Click);
        LoginButton.FlatStyle = FlatStyle.Flat;
        LoginButton.FlatAppearance.BorderSize = 0;
        this.Controls.Add(LoginButton);
    }
    
    private void LoginButton_Click(object sender, EventArgs e)
    {
        if (username.Text == "admin" && password.Text == "admin")
        {
            Registering register = new Registering();
            register.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Login Failed");
        }
    }
    private void exit_Paint(object sender, PaintEventArgs e)
    {
        Pen blackpen = new Pen(Color.Black, 2);
        e.Graphics.DrawLine(blackpen, 9,9, 29, 29);
        e.Graphics.DrawLine(blackpen, 9, 29, 29, 9);
    }
    
    private void exit_Click(object sender, EventArgs e)
    {
        MiMBox exitmbox = new MiMBox();
        exitmbox.Show();
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
        this.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
        Graphics g = e.Graphics;
        Pen p = new Pen(Color.Black, 2);
        g.DrawLine(p, 0, 40, this.Width, 40);
    }
}
class NativeMethods
{
    [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    public static extern System.IntPtr CreateRoundRectRgn
    (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
    );
    [System.Runtime.InteropServices.DllImport("gdi32.dll",EntryPoint="DeleteObject")]
    public static extern bool DeleteObject(System.IntPtr hObject);
    [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();
    [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
    public static extern bool SendMessage(System.IntPtr hWnd, int Msg, int wParam, int lParam);
}
public class MiMBox : Form
{   
    Label exitlabel = new Label();
    Label warning = new Label();
    public Panel cuerpo = new Panel();
    Button yes = new Button();
    Button no = new Button();
    public MiMBox()
    {
        Font f = new Font("Open Sans", 12);
        this.Size = new Size(404, 204);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Paint += new PaintEventHandler(MiMBox_Paint);
        this.BackColor = Color.Black;
        cuerpo.Size = new Size(400, 200);
        cuerpo.Location = new Point(2,2);
        cuerpo.BackColor = Color.LightYellow;
        this.Controls.Add(cuerpo);
        cuerpo.Paint += new PaintEventHandler(cuerpo_Paint);
        warning.Text = "Are you sure you want to exit?";
        warning.Font = f;
        warning.Size = new Size(300, 50);
        warning.Location = new Point(60,70);
        cuerpo.Controls.Add(warning);
        yes.Size = new Size(100, 50);
        yes.Location = new Point(55, 120);
        yes.Text = "Yes";
        yes.FlatStyle = FlatStyle.Flat;
        yes.FlatAppearance.BorderSize = 0;
        no.Size = new Size(100, 50);
        no.Location = new Point(255, 120);
        no.Text = "No";
        no.FlatStyle = FlatStyle.Flat;
        no.FlatAppearance.BorderSize = 0;
        cuerpo.Controls.Add(yes);
        cuerpo.Controls.Add(no);
        yes.Click += new EventHandler(yes_Click);
        no.Click += new EventHandler(no_Click);
        this.CenterToScreen();
        exitlabel.Text = "Exit?";
        exitlabel.Font = f;
        exitlabel.Size = new Size(100, 30);
        exitlabel.Location = new Point(170, 8);
        cuerpo.Controls.Add(exitlabel);
    }
    private void yes_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    private void no_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private void cuerpo_Paint(object sender, PaintEventArgs e)
    {
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, cuerpo.Width, cuerpo.Height, 20, 20);
        cuerpo.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
        Pen blackpen = new Pen(Color.Black, 2);
        e.Graphics.DrawLine(blackpen, 0, 40, 400, 40);
    }
    private void MiMBox_Paint(object sender, PaintEventArgs e)
    {
        Pen blackpen = new Pen(Color.Black, 2);
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
        this.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
    }
}
public class Registering:Form
{
    Label instructions = new Label();
    Button exit = new Button();
    PictureBox owl = new PictureBox();
    Label name = new Label();
    Label name2 = new Label();
    Label email = new Label();
    Label phone = new Label();
    Label address = new Label();
    Label pcode = new Label();
    Label city = new Label();
    Label notes = new Label();
    TextBox namebox = new TextBox();
    TextBox name2box = new TextBox();
    TextBox emailbox = new TextBox();
    TextBox phonebox = new TextBox();
    TextBox addressbox = new TextBox();
    TextBox pcodebox = new TextBox();
    TextBox citybox = new TextBox();
    TextBox notesbox = new TextBox();

    Button register = new Button();
    public Registering()
    {
        Font dafont = new Font("Open Sans", 20);
        this.Size = new Size(1200, 850);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Paint += new PaintEventHandler(Registering_Paint);
        this.BackColor = Color.DarkSeaGreen;
        this.CenterToScreen();
        exit.Size = new Size(38,38);
        exit.Location = new Point(1160, 0);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        exit.BackColor = Color.DarkSeaGreen;
        exit.Paint += new PaintEventHandler(exit_Paint);
        exit.Click += new EventHandler(exit_Click);
        this.Controls.Add(exit);
        instructions.Text = "Please enter your information below";
        instructions.Size = new Size(604, 100);
        instructions.Font = new Font("Open Sans", 20);
        instructions.Parent = owl;
        instructions.BackColor = Color.Transparent;
        this.Controls.Add(instructions);
        owl.Size = new Size(150, 175);
        instructions.Location = new Point(225, 160);
        owl.Location = new Point(795, 55);
        owl.Image = Image.FromFile("owl.png");
        owl.SizeMode = PictureBoxSizeMode.StretchImage;
        owl.BackColor = Color.Transparent;
        this.Controls.Add(owl);
        owl.SendToBack();
        name.Text = "First Name";
        name.Size = new Size(200, 50);
        name.Location = new Point(100, 300);
        name.Font = dafont;
        this.Controls.Add(name);
        namebox.Size = new Size(400, 50);
        namebox.Location = new Point(100, 350);
        namebox.Font = new Font("Open Sans", 12);
        this.Controls.Add(namebox);
        name2.Text = "Last Name";
        name2.Size = new Size(200, 50);
        name2.Location = new Point(100, 400);
        name2.Font = dafont;
        this.Controls.Add(name2);
        name2box.Size = new Size(400, 50);
        name2box.Location = new Point(100, 450);
        name2box.Font = new Font("Open Sans", 12);
        this.Controls.Add(name2box);
        email.Text = "Email";
        email.Size = new Size(200, 50);
        email.Location = new Point(100, 500);
        email.Font = dafont;
        this.Controls.Add(email);
        emailbox.Size = new Size(400, 50);
        emailbox.Location = new Point(100, 550);
        emailbox.Font = new Font("Open Sans", 12);
        this.Controls.Add(emailbox);
        phone.Text = "Phone";
        phone.Size = new Size(200, 50);
        phone.Location = new Point(100, 600);
        phone.Font = dafont;
        this.Controls.Add(phone);
        phonebox.Size = new Size(400, 50);
        phonebox.Location = new Point(100, 650);
        phonebox.Font = new Font("Open Sans", 12);
        this.Controls.Add(phonebox);
        address.Text = "Address";
        address.Size = new Size(200, 50);
        address.Location = new Point(650, 300);
        address.Font = dafont;
        this.Controls.Add(address);
        addressbox.Size = new Size(400, 50);
        addressbox.Location = new Point(650, 350);
        addressbox.Font = new Font("Open Sans", 12);
        this.Controls.Add(addressbox);
        pcode.Text = "Postal Code";
        pcode.Size = new Size(200, 50);
        pcode.Location = new Point(650, 400);
        pcode.Font =dafont;
        this.Controls.Add(pcode);
        pcodebox.Size = new Size(400, 50);
        pcodebox.Location = new Point(650, 450);
        pcodebox.Font = new Font("Open Sans", 12);
        this.Controls.Add(pcodebox);
        city.Text = "City";
        city.Size = new Size(200, 50);
        city.Location = new Point(650, 500);
        city.Font = dafont;
        this.Controls.Add(city);
        citybox.Size = new Size(400, 50);
        citybox.Location = new Point(650, 550);
        citybox.Font = new Font("Open Sans", 12);
        this.Controls.Add(citybox);
        notes.Text = "Notes";
        notes.Size = new Size(200, 50);
        notes.Location = new Point(650, 600);
        notes.Font = dafont;
        this.Controls.Add(notes);
        notesbox.Size = new Size(400, 50);
        notesbox.Location = new Point(650, 650);
        notesbox.Font = new Font("Open Sans", 12);
        this.Controls.Add(notesbox);
        register.Size = new Size(200, 70);
        register.Location = new Point(475, 720);
        register.Text = "Register";
        register.Font = dafont;
        register.FlatStyle = FlatStyle.Flat;
        register.FlatAppearance.BorderSize = 0;
        this.Controls.Add(register);
        register.Click += new EventHandler(register_Click);
    }
    private void register_Click(object sender, EventArgs e)
    {
        Calendar calendar = new Calendar();
        calendar.Show();
        this.Hide();
    }
    private void exit_Click(object sender, EventArgs e)
    {
        MiMBox exitmbox = new MiMBox();
        exitmbox.Show();
    }
    private void exit_Paint(object sender, PaintEventArgs e)
    {
        Pen blackpen = new Pen(Color.Black, 2);
        e.Graphics.DrawLine(blackpen, 9, 9, 29, 29);
        e.Graphics.DrawLine(blackpen, 9, 29, 29, 9);
    }
    private void Registering_Paint(object sender, PaintEventArgs e)
    {
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
        this.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
        Pen blackpen = new Pen(Color.Black, 2);
        Pen boldpen = new Pen(Color.Black, 10);
        e.Graphics.DrawLine(blackpen, 0, 40, 1200, 40);
        e.Graphics.DrawLine(boldpen, 195, 212, 875,212);
    }
}
public class Calendar : Form
{
    MonthCalendar calendario = new MonthCalendar();
    Button exit = new Button();
    DataGridView schedulegrid = new DataGridView();
    Panel schedule = new Panel();
    public Calendar()
    {
        this.Size = new Size(1600, 900);
        this.CenterToScreen();
        this.FormBorderStyle = FormBorderStyle.None;
        this.BackColor = Color.White;
        this.Paint += new PaintEventHandler(Calendar_Paint);
        calendario.Size = new Size(300, 300);
        calendario.Location = new Point(10,42);
        calendario.Paint += new PaintEventHandler(calendario_Paint);
        this.Controls.Add(calendario);
        exit.Size = new Size(38, 38);
        exit.Location = new Point(1540, 0);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        exit.BackColor = Color.White;
        this.Controls.Add(exit);
        exit.Paint += new PaintEventHandler(exit_Paint);
        exit.Click += new EventHandler(exit_Click);
        schedule.Size = new Size(1290, 780);
        schedule.Location = new Point(280, 50);
        schedule.BackColor = Color.White;
        schedule.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        this.Controls.Add(schedule);
        schedulegrid.Size = new Size(1290, 780);
        schedulegrid.ColumnCount = 2;
        schedulegrid.Columns[0].Name = "Time";
        schedulegrid.Columns[1].Name = "Dates";
        schedulegrid.Rows.Add("8:00", "", "", "");
        schedulegrid.Rows.Add("9:00", "", "", "");
        schedulegrid.Rows.Add("10:00", "", "", "");
        schedulegrid.Rows.Add("11:00", "", "", "");
        schedulegrid.Rows.Add("12:00", "", "", "");
        schedulegrid.Rows.Add("13:00", "", "", "");
        schedulegrid.Rows.Add("14:00", "", "", "");
        schedulegrid.Rows.Add("15:00", "", "", "");
        schedulegrid.Rows.Add("16:00", "", "", "");
        schedulegrid.Rows.Add("17:00", "", "", "");
        schedulegrid.Rows.Add("18:00", "", "", "");
        schedulegrid.Rows.Add("19:00", "", "", "");
        schedulegrid.Rows.Add("20:00", "", "", "");
        schedulegrid.Rows.Add("21:00", "", "", "");
        for (int i = 0; i < 14; i++)
        {
            schedulegrid.Rows[i].Height = 50;
        }
        schedulegrid.Columns[1].Width = 1100;
        schedule.Controls.Add(schedulegrid);
        
    }
    private void exit_Click(object sender, EventArgs e)
    {
        MiMBox exit = new MiMBox();
        exit.Show();
    }
    private void exit_Paint(object sender, PaintEventArgs e)
    {
        Pen blackpen = new Pen(Color.Black, 2);
        e.Graphics.DrawLine(blackpen, 9, 9, 29, 29);
        e.Graphics.DrawLine(blackpen, 9, 29, 29, 9);
    }
    private void calendario_Paint(object sender, PaintEventArgs e)
    {
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
        this.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
    }
    private void Calendar_Paint(object sender, PaintEventArgs e)
    {
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
        this.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
        Pen blackpen = new Pen(Color.Black, 2);
        e.Graphics.DrawLine(blackpen, 0, 40, this.Width, 40);

    }
}

