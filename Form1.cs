namespace ProjectTADS;

public partial class Form1 : Form
{
    
    Button exit = new Button();
    Label doxX, doxY;
    public Form1()
    {
        InitializeComponent();
        doxX = new Label();
        doxY = new Label();
        this.FormBorderStyle = FormBorderStyle.None;
        this.Size = new Size(800, 600); 
        this.Controls.Add(exit);
        exit.Text = "X";
        exit.Location = new Point(750,0);
        exit.Size = new Size(38, 38);
        exit.FlatStyle = FlatStyle.Flat;
        exit.FlatAppearance.BorderSize = 0;
        this.Controls.Add(doxX);
        this.Controls.Add(doxY);
        doxX.Location = new Point(50, 0);
        doxY.Location = new Point(50, 50); 
        exit.Click += new EventHandler(exit_Click);
        this.Paint += new PaintEventHandler(Form1_Paint);
        this.MouseMove += new MouseEventHandler(Form1_MouseMove);
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        doxX.Text = "X: " + e.X.ToString();
        doxY.Text = "Y: " + e.Y.ToString();
    }
    private void exit_Click(object sender, EventArgs e)
    {
        switch (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo))
        {
            case DialogResult.Yes:
                this.Close();
                break;
            case DialogResult.No:
                MessageBox.Show("You have chosen not to exit");  
                break;
        }
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
