using System.Drawing.Imaging;
using System.IO;

namespace SimpleEdit
{
    public partial class MainForm : Form
    {
        private Bitmap originalImage;
        private String imageName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg,*.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBox.Image = new Bitmap(openFileDialog.FileName);
                    ImageProcessor.Grayscale((Bitmap)pictureBox.Image);
                }
            }
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = ".jpg|*.jpg|.jpeg|*.jpeg|.png|*.png";
                saveFileDialog.RestoreDirectory = true;
                ImageFormat format = ImageFormat.Png;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                    switch (extension)
                    {
                        case ".jpg":
                            ;
                            break;
                        case ".jpeg":
                            ;
                            break;
                        case ".png":
                            ;
                            break;
                    }

                    pictureBox.Image.Save(saveFileDialog.FileName, format);
                }
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                return;
            }

            if (grayscaleButton.Checked)
            {
                pictureBox.Image = ImageProcessor.Grayscale((Bitmap)pictureBox.Image);
            } else if (invertColorsButton.Checked)
            {
                pictureBox.Image = ImageProcessor.InvertColors((Bitmap)pictureBox.Image);
            } else if (flipImageButton.Checked)
            {
                pictureBox.Image = ImageProcessor.FlipImage((Bitmap)pictureBox.Image);
            } else if (smallBlurButton.Checked)
            {
                pictureBox.Image = ImageProcessor.Blur((Bitmap)pictureBox.Image, 3);
            } else if (bigBlurButton.Checked)
            {
                pictureBox.Image = ImageProcessor.Blur((Bitmap)pictureBox.Image, 10);
            } else if (nukeButton.Checked)
            {
                pictureBox.Image = ImageProcessor.Nuke((Bitmap)pictureBox.Image);
            } else
            {
                throw new Exception("Non-existing edit choice.");
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                return;
            }

            pictureBox.Image = originalImage;
        }
    }
}