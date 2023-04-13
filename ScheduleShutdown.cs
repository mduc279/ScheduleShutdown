namespace ScheduleShutdown
{
    public partial class ScheduleShutdown : Form
    {
        public ScheduleShutdown()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar >= 0;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar >= 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                return;
            }
            var hours = string.IsNullOrEmpty(textBox1.Text) ? 0 : int.Parse(textBox1.Text);
            var minutes = string.IsNullOrEmpty(textBox2.Text) ? 0 : int.Parse(textBox2.Text);
            var totalSec = (TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(minutes)).TotalSeconds;

            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C shutdown -s -t {totalSec}";
                process.StartInfo = startInfo;
                process.Start();
                label4.ForeColor = Color.Green;
                label4.Text = "Success";
            } 
            catch (Exception ex)
            {
                label4.ForeColor = Color.Red;
                label4.Text = ex.Message;
            }
            label4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C shutdown -a";
                process.StartInfo = startInfo;
                process.Start();
                label4.ForeColor = Color.Green;
                label4.Text = "Success";
            }
            catch (Exception ex)
            {
                label4.ForeColor = Color.Red;
                label4.Text = ex.Message;
            }
            label4.Visible = true;
        }
    }
}