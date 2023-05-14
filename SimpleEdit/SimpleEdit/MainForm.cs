using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SimpleEdit
{
    public partial class MainForm : Form
    {
        private List<Bitmap> originalImages;
        private List<Bitmap> images;
        private int editing;

        public MainForm()
        {
            InitializeComponent();
            editing = 0;
            images = new List<Bitmap>();
            originalImages = new List<Bitmap>();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (editing != 0)
            {
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg,*.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = new Bitmap(openFileDialog.FileNames[0]);
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        var img = new Bitmap(fileName);
                        images.Add(img);
                        originalImages.Add(img);
                    }
                }
            }
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null || editing != 0)
            {
                return;
            }

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

                    // pictureBox.Image.Save(saveFileDialog.FileName, format);
                    images[0].Save(saveFileDialog.FileName, format);
                }
            }
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null || editing != 0 || images.Count == 0)
            {
                return;
            }

            Interlocked.Exchange(ref editing, 1);
            Cursor = Cursors.WaitCursor;
            var tasks = new List<Task>();

            for (int i = 0; i < images.Count; i++)
            {
                int temp = i;
                var image = images[temp];
                tasks.Add(Task.Run(async () =>
                {
                    if (grayscaleButton.Checked)
                    {
                        images[temp] = await ImageProcessor.Grayscale(image);
                    }
                    else if (invertColorsButton.Checked)
                    {
                        images[temp] = await ImageProcessor.InvertColors(image);
                    }
                    else if (flipImageButton.Checked)
                    {
                        images[temp] = ImageProcessor.FlipImage(image);
                    }
                    else if (smallBlurButton.Checked)
                    {
                        images[temp] = await ImageProcessor.Blur(image, 2);
                    }
                    else if (bigBlurButton.Checked)
                    {
                        images[temp] = await ImageProcessor.Blur(image, 9);
                    }
                    else if (nukeButton.Checked)
                    {
                        images[temp] = ImageProcessor.Nuke(image);
                    }
                    else
                    {
                        throw new Exception("Non-existing edit choice.");
                    }
                }));
            }

            await Task.WhenAll(tasks);

            pictureBox.Image = images[0];
            Cursor = Cursors.Arrow;
            Interlocked.Exchange(ref editing, 0);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null || editing != 0)
            {
                return;
            }

            pictureBox.Image = originalImages[0];
        }
    }
}