using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace _2001321062_image_resizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    Image selectedImage = Image.FromFile(selectedImagePath);
                    pictureBox1.Image = selectedImage;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a downscaling factor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedItemText = comboBox1.SelectedItem.ToString();
            Console.WriteLine(selectedItemText);
            if (string.IsNullOrEmpty(selectedItemText))
            {
                MessageBox.Show("Invalid selection. Please select a valid downscaling factor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectedItemText = selectedItemText.Substring(0, selectedItemText.Length - 1);

            if (!float.TryParse(selectedItemText, out float downscalingFactor))
            {
                MessageBox.Show("Invalid downscaling factor. Please select a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select an image first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            downscalingFactor = downscalingFactor / 100;
            Image downScaledImage = Process((Bitmap)pictureBox1.Image, downscalingFactor);
            pictureBox1.Image = downScaledImage;
        }

        private Bitmap Process(Bitmap orig, double scaleVal)
        {
            if (scaleVal <= 0 || scaleVal > 1) throw new ArgumentOutOfRangeException("scaleVal");

            int resizedW = Math.Max(1, (int)(orig.Width * scaleVal));
            int resizedH = Math.Max(1, (int)(orig.Height * scaleVal));
            Bitmap resized = new Bitmap(resizedW, resizedH, orig.PixelFormat);

            BitmapData origData = orig.LockBits(new Rectangle(0, 0, orig.Width, orig.Height), ImageLockMode.ReadOnly, orig.PixelFormat);
            BitmapData resizedData = resized.LockBits(new Rectangle(0, 0, resizedW, resizedH), ImageLockMode.WriteOnly, resized.PixelFormat);

            int pixelDepth = Bitmap.GetPixelFormatSize(orig.PixelFormat) / 8;
            byte[] origBuff = new byte[origData.Stride * orig.Height];
            byte[] resizedBuff = new byte[resizedData.Stride * resizedH];
            Console.WriteLine(origBuff);

            System.Runtime.InteropServices.Marshal.Copy(origData.Scan0, origBuff, 0, origBuff.Length);

            for (int row = 0; row < resizedH; row++)
            {
                for (int col = 0; col < resizedW; col++)
                {
                    int startRow = (int)(row / scaleVal), startCol = (int)(col / scaleVal);
                    int endRow = (int)Math.Ceiling((row + 1) / scaleVal), endCol = (int)Math.Ceiling((col + 1) / scaleVal);
                    long sumR = 0, sumG = 0, sumB = 0, counter = 0;
                    for (int y = startRow; y < endRow; y++)
                    {
                        for (int x = startCol; x < endCol; x++)
                        {
                            int index = y * origData.Stride + x * pixelDepth;
                            sumB += origBuff[index];
                            sumG += origBuff[index + 1];
                            sumR += origBuff[index + 2];
                            counter++;
                        }
                    }
                    int newIndex = row * resizedData.Stride + col * pixelDepth;
                    resizedBuff[newIndex] = (byte)(sumB / counter);
                    resizedBuff[newIndex + 1] = (byte)(sumG / counter);
                    resizedBuff[newIndex + 2] = (byte)(sumR / counter);
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(resizedBuff, 0, resizedData.Scan0, resizedBuff.Length);
            orig.UnlockBits(origData);
            resized.UnlockBits(resizedData);
            return resized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
