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
        this.Size = new Size(600, 650); 
        this.Controls.Add(exit);
        this.BackColor = Color.Aquamarine;
        exit.Location = new Point(560,0);
        exit.Size = new Size(38, 38);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        exit.Click += new EventHandler(exit_Click);
        exit.Paint += new PaintEventHandler(exit_Paint);
        this.Paint += new PaintEventHandler(Form1_Paint);
        LDLogo.Image = Image.FromFile("LDLogo.png");
        LDLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        LDLogo.Size = new Size(430, 360);
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
        username.Size = new Size(200, 20);
        this.Controls.Add(username);
        password.Location = new Point(250, 530);
        password.Size = new Size(200, 20);
        this.Controls.Add(password);
        this.CenterToScreen();
        LoginLabel.Text = "Login";
        LoginLabel.Font = new Font("Open Sans", 20);
        LoginLabel.Location = new Point(250, 400);
        LoginLabel.Size = new Size(130, 60);
        this.Controls.Add(LoginLabel);
        LoginButton.Text = "Login";
        LoginButton.Font = font;    
        LoginButton.Location = new Point(300, 560);
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
        g.DrawLine(p, 0, 40, 800, 40);
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
        Font f = new Font("Arial", 12);
        this.Size = new Size(404, 204);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Paint += new PaintEventHandler(MiMBox_Paint);
        this.BackColor = Color.Black;
        cuerpo.Size = new Size(400, 200);
        cuerpo.Location = new Point(2,2);
        cuerpo.BackColor = Color.Silver;
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
    Button exit = new Button();
    public Registering()
    {
        this.Size = new Size(800, 600);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Paint += new PaintEventHandler(Registering_Paint);
        this.BackColor = Color.DarkSeaGreen;
        this.CenterToScreen();
        exit.Size = new Size(38,38);
        exit.Location = new Point(760, 0);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        exit.BackColor = Color.DarkSeaGreen;
        exit.Paint += new PaintEventHandler(exit_Paint);
        exit.Click += new EventHandler(exit_Click);
        this.Controls.Add(exit);
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
        e.Graphics.DrawLine(blackpen, 0, 40, 800, 40);
    }
}
