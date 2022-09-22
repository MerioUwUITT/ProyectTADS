using System.Data.SqlClient;
using System.Data;
namespace ProjectTADS;
public partial class Form1 : Form
{
    public Point mouseLocation;
    PictureBox LDLogo = new PictureBox();
    Button exit = new Button();
    TextBox username = new TextBox();
    TextBox password = new TextBox();
    Label usernameLabel = new Label();
    Label passwordLabel = new Label();
    Label LoginLabel = new Label();
    Button LoginButton = new Button();
    SqlConnection conn = new SqlConnection( "Data Source=ELMERIOUWU; Initial Catalog=AppointmentsDB; Integrated Security=True");//sql instance

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
        this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        this.MouseMove += new MouseEventHandler(Form1_MouseMove);
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        mouseLocation = new Point(-e.X, -e.Y);
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(mouseLocation.X, mouseLocation.Y);
            Location = mousePosition;
        }
    }
    
    private void LoginButton_Click(object sender, EventArgs e)
    {
        conn.Open();
        if(username.Text == "" || password.Text == "")
        {
            MessageBox.Show("Please enter a username and password");
        }
        else
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Master WHERE Username = @Username AND Passphrase = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", username.Text);
            cmd.Parameters.AddWithValue("@Password", password.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                Menu menu = new Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
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
        ExitScreen exitmbox = new ExitScreen();
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
public class ExitScreen : Form
{   
    public Point mouseLocation;
    Label exitlabel = new Label();
    Label warning = new Label();
    public Panel cuerpo = new Panel();
    Button yes = new Button();
    Button no = new Button();
    public ExitScreen()
    {
        Font f = new Font("Open Sans", 12);
        this.Size = new Size(404, 204);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Paint += new PaintEventHandler(ExitScreen_Paint);
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
        cuerpo.MouseDown += new MouseEventHandler(cuerpo_MouseDown);
        cuerpo.MouseMove += new MouseEventHandler(cuerpo_MouseMove);
    }
    private void cuerpo_MouseDown(object sender, MouseEventArgs e)
    {
        mouseLocation = new Point(-e.X, -e.Y);
    }
    private void cuerpo_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(mouseLocation.X, mouseLocation.Y);
            Location = mousePosition;
        }
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
    private void ExitScreen_Paint(object sender, PaintEventArgs e)
    {
        Pen blackpen = new Pen(Color.Black, 2);
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
        this.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
    }
}
public class Menu:Form
{
    public Point mouseLocation;
    Button exit = new Button();
    Button Register = new Button();
    Button MakeDate = new Button();
    Label emptylistwarning = new Label();
    SqlConnection conn = new SqlConnection( "Data Source=ELMERIOUWU; Initial Catalog=AppointmentsDB; Integrated Security=True");//sql instance
    public Menu()
    {
        this.Size = new Size(400, 400);
        this.FormBorderStyle = FormBorderStyle.None;
        this.CenterToScreen();
        this.BackColor = Color.Moccasin;
        this.Paint += new PaintEventHandler(Menu_Paint);
        this.MouseDown += new MouseEventHandler(Menu_MouseDown);
        this.MouseMove += new MouseEventHandler(Menu_MouseMove);
        exit.Size = new Size(38, 38);
        exit.Location = new Point(360,0);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        exit.Click += new EventHandler(exit_Click);
        exit.Paint += new PaintEventHandler(exit_Paint);
        this.Controls.Add(exit);
        Register.Size = new Size(200, 100);
        Register.Location = new Point(100, 100);
        Register.Text = "Register";
        Register.FlatStyle = FlatStyle.Flat;
        Register.FlatAppearance.BorderSize = 0;
        Register.Click += new EventHandler(Register_Click);
        this.Controls.Add(Register);
        MakeDate.Size = new Size(200, 100);
        MakeDate.Location = new Point(100, 200);
        MakeDate.Text = "Make Date";
        MakeDate.FlatStyle = FlatStyle.Flat;
        MakeDate.FlatAppearance.BorderSize = 0;
        MakeDate.Click += new EventHandler(MakeDate_Click);
        this.Controls.Add(MakeDate);
    }
    private void MakeDate_Click(object sender, EventArgs e)
    {
            this.Hide();
            Calendar c = new Calendar();
            c.Show();
    }
    private void Register_Click(object sender, EventArgs e)
    {
        this.Hide();
        RegisterScreen r = new RegisterScreen();
        r.Show();   
    }
    private void exit_Click(object sender, EventArgs e)
    {
        ExitScreen box = new ExitScreen();
        box.Show();
    }
    private void exit_Paint(object sender, PaintEventArgs e)
    {
        Pen blackpen = new Pen(Color.Black, 2);
        e.Graphics.DrawLine(blackpen, 9,9, 29, 29);
        e.Graphics.DrawLine(blackpen, 9, 29, 29, 9);
    }
    private void Menu_MouseDown(object sender, MouseEventArgs e)
    {
        mouseLocation = new Point(-e.X, -e.Y);
    }
    private void Menu_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(mouseLocation.X, mouseLocation.Y);
            Location = mousePosition;
        }
    }
    private void Menu_Paint(object sender, PaintEventArgs e)
    {
        IntPtr ptr = NativeMethods.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
        this.Region = System.Drawing.Region.FromHrgn(ptr);
        NativeMethods.DeleteObject(ptr);
        e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 40, 400, 40);
    }
}
public class MiMbox : Form
{
    public string Name { get; set; }
    public string Name2 { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Pcode { get; set; }
    public string Notes { get; set; }
    

}

public class RegisterScreen:Form
{
    public Point mouseLocation;
    Label instructions = new Label();
    Button exit = new Button();
    Button goback = new Button();
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
    SqlConnection conn = new SqlConnection( "Data Source=ELMERIOUWU; Initial Catalog=AppointmentsDB; Integrated Security=True");//sql instance

    Button register = new Button();
    public RegisterScreen()
    {
        Font dafont = new Font("Open Sans", 20);
        this.Size = new Size(1200, 850);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Paint += new PaintEventHandler(RegisterScreen_Paint);
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
        this.MouseDown += new MouseEventHandler(RegisterScreen_MouseDown);
        this.MouseMove += new MouseEventHandler(RegisterScreen_MouseMove);
        goback.Size = new Size(60, 38);
        goback.Location = new Point(0, 0);
        goback.FlatStyle = FlatStyle.Flat;
        goback.FlatAppearance.BorderSize = 0;
        goback.Click += new EventHandler(goback_Click);
        goback.Paint += new PaintEventHandler(goback_Paint);
        this.Controls.Add(goback);

    }
    private void goback_Click(object sender, EventArgs e)
    {
        this.Hide();
        Menu menu = new Menu();
        menu.Show();
    }
    private void goback_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(10, 20), new Point(28,10), new Point(28,30) });
        g.DrawLine(new Pen(Color.Black, 3), 15, 20, 50, 20);



    }
    private void RegisterScreen_MouseDown(object sender, MouseEventArgs e)
    {
        mouseLocation = new Point(-e.X, -e.Y);
    }
    private void RegisterScreen_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(mouseLocation.X, mouseLocation.Y);
            Location = mousePosition;
        }
    }

    private void register_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        string statement = "SELECT COUNT(*) FROM Client";
        int count = 0;
        using(cmd)

        {
           using(SqlCommand cmd2 = new SqlCommand(statement, conn))
           {
               count = (int)cmd2.ExecuteScalar();
           }
        }
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO Client (IDClient, NameClient, EmailClient, AddressClient, PostalCode, City, Notes, PhoneClient) VALUES (@ID, @NameClient, @EmailClient, @AddressClient, @PostalCode, @City, @Notes, @PhoneClient)";
        string name = namebox.Text + " " + name2box.Text;
        cmd.Parameters.AddWithValue("@ID", count + 1);
        cmd.Parameters.AddWithValue("@NameClient", name);
        cmd.Parameters.AddWithValue("@EmailClient", emailbox.Text);
        cmd.Parameters.AddWithValue("@AddressClient", addressbox.Text);
        cmd.Parameters.AddWithValue("@PostalCode", pcodebox.Text);
        cmd.Parameters.AddWithValue("@City", citybox.Text);
        cmd.Parameters.AddWithValue("@Notes", notesbox.Text);
        cmd.Parameters.AddWithValue("@PhoneClient", phonebox.Text);
        cmd.ExecuteNonQuery();
        System.Windows.Forms.MessageBox.Show("Registered");
    }
    private void exit_Click(object sender, EventArgs e)
    {
        ExitScreen exitmbox = new ExitScreen();
        exitmbox.Show();
    }
    private void exit_Paint(object sender, PaintEventArgs e)
    {
        Pen blackpen = new Pen(Color.Black, 2);
        e.Graphics.DrawLine(blackpen, 9, 9, 29, 29);
        e.Graphics.DrawLine(blackpen, 9, 29, 29, 9);
    }
    private void RegisterScreen_Paint(object sender, PaintEventArgs e)
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
    public Point mouseLocation;
    MonthCalendar calendario = new MonthCalendar();
    Button exit = new Button();
    Panel schedule = new Panel();
    ComboBox clientes = new ComboBox();
    ComboBox lawyers = new ComboBox();
    Button goback   = new Button();
    Button btn  = new Button();
    DataGridView grid = new DataGridView();
    DataGridViewCheckBoxColumn Selected = new DataGridViewCheckBoxColumn();
    DataGridViewTextBoxColumn Hour = new DataGridViewTextBoxColumn();
    DataGridViewTextBoxColumn Client = new DataGridViewTextBoxColumn();
    SqlConnection conn = new SqlConnection("Data Source=ELMERIOUWU;Initial Catalog=AppointmentsDB;Integrated Security=True");
    public Calendar()
    {
        this.Size = new Size(1520, 620);
        this.CenterToScreen();
        this.FormBorderStyle = FormBorderStyle.None;
        this.BackColor = Color.White;
        this.Paint += new PaintEventHandler(Calendar_Paint);
        calendario.Size = new Size(300, 300);
        calendario.Location = new Point(10,42);
        calendario.Paint += new PaintEventHandler(calendario_Paint);
        this.Controls.Add(calendario);
        exit.Size = new Size(38, 38);
        exit.Location = new Point(1460, 0);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        exit.BackColor = Color.White;
        this.Controls.Add(exit);
        exit.Paint += new PaintEventHandler(exit_Paint);
        exit.Click += new EventHandler(exit_Click);
        schedule.Size = new Size(1300, 780);
        schedule.Location = new Point(280, 50);
        schedule.BackColor = Color.White;
        schedule.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        this.Controls.Add(schedule);
        List <string> clients = new List<string>();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT NameClient FROM Client";
        SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            clients.Add(reader.GetString(0));
        }
        conn.Close();
        foreach(string client in clients)
        {
            clientes.Items.Add(client);
        }
        clientes.Size = new Size(200, 30);
        clientes.Location = new Point(50, 440);
        clientes.Font = new Font("Open Sans", 12);
        clientes.DropDownStyle = ComboBoxStyle.DropDownList;
        clientes.BackColor = Color.White;
        this.Controls.Add(clientes);
        List<string> lawyerss = new List<string>();
        conn.Open();
        SqlCommand cmd2 = new SqlCommand();
        cmd2.Connection = conn;
        cmd2.CommandType = CommandType.Text;
        cmd2.CommandText = "SELECT NameLawyer FROM Lawyer";
        SqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            lawyerss.Add(reader2.GetString(0));
        }
        conn.Close();
        foreach (string lawyer in lawyerss)
        {
            lawyers.Items.Add(lawyer);
        }
        lawyers.Size = new Size(200, 30);
        lawyers.Location = new Point(50, 490);
        lawyers.Font = new Font("Open Sans", 12);
        lawyers.DropDownStyle = ComboBoxStyle.DropDownList;
        lawyers.BackColor = Color.White;
        this.Controls.Add(lawyers);
        this.MouseDown += new MouseEventHandler(Calendar_MouseDown);
        this.MouseMove += new MouseEventHandler(Calendar_MouseMove);
        goback.Size = new Size(60, 38);
        goback.Location = new Point(0, 0);
        goback.FlatStyle = FlatStyle.Flat;
        goback.FlatAppearance.BorderSize = 0;
        goback.BackColor = Color.White;
        this.Controls.Add(goback);
        goback.Paint += new PaintEventHandler(goback_Paint);
        goback.Click += new EventHandler(goback_Click);
        btn.Size = new Size(200, 30);
        btn.Location = new Point(50, 540);
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.BackColor = Color.FromArgb(0, 122, 204);
        btn.ForeColor = Color.White;
        btn.Font = new Font("Open Sans", 12);
        btn.Text = "Add";
        this.Controls.Add(btn);
        btn.Click += new EventHandler(btn_Click);
        grid.Size = new Size(1250, 600);
        grid.Location = new Point(0, 0);
        grid.Columns.Add(Selected);
        grid.Columns.Add(Hour);
        grid.Columns.Add(Client);
        grid.Columns[0].Width = 50;
        grid.Columns[1].Width = 100;
        grid.Columns[2].Width = 1050;
        grid.Columns[0].HeaderText = "Selected";
        grid.Columns[1].HeaderText = "Hour";
        grid.Columns[2].HeaderText = "Client";
        grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeColumns = false;
        grid.AllowUserToResizeRows = false;
        grid.RowHeadersVisible = false;
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
        for(int i=0; i<17; i++)
        {
            if(i>=8 && i<=16)
            {
                grid.Rows.Add(false, i+":00", "");
            }
        }
        foreach (DataGridViewRow row in grid.Rows)
        {
            row.Height = 50;
        }
        schedule.Controls.Add(grid);
    }
    void grid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 0)
    {
        //Loop and uncheck all other CheckBoxes.
        foreach (DataGridViewRow row in grid.Rows)
        {
            if (row.Index == e.RowIndex)
            {
                row.Cells[0].Value = !Convert.ToBoolean(row.Cells[0].EditedFormattedValue);
            }
            else
            {
                row.Cells[0].Value = false;
            }
        }
    }

    }
    public void btn_Click(object sender, EventArgs e)
    {
        
    }
    private void goback_Click(object sender, EventArgs e)
    {
        this.Hide();
        Menu menu = new Menu();
        menu.Show();
    }
    private void goback_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(10, 20), new Point(28,10), new Point(28,30) });
        g.DrawLine(new Pen(Color.Black, 3), 15, 20, 50, 20);



    }
    private void Calendar_MouseDown(object sender, MouseEventArgs e)
    {
        mouseLocation = new Point(-e.X, -e.Y);
    }
    private void Calendar_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(mouseLocation.X, mouseLocation.Y);
            Location = mousePosition;
        }
    }
    private void exit_Click(object sender, EventArgs e)
    {
        ExitScreen exit = new ExitScreen();
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

public class Appointment

{
    public DateTime day { get; set; }
    public int hour { get; set; }
    public string clientname { get; set; }
    public string clientname2 { get; set; }
}