using System.Drawing.Imaging;

namespace SimpleEdit
{
    public partial class MainForm : Form
    {
        private List<Bitmap> originalImages;
        private List<Bitmap> images;
        private List<string> imageNames;
        private int editing;

        public MainForm()
        {
            InitializeComponent();
            editing = 0;
            images = new List<Bitmap>();
            originalImages = new List<Bitmap>();
            imageNames = new List<string>();
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
                    if (images.Count > 0)
                    {
                        images.Clear();
                        originalImages.Clear();
                        imageNames.Clear();
                    }

                    pictureBox.Image = new Bitmap(openFileDialog.FileNames[0]);
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        var img = new Bitmap(fileName);
                        images.Add(img);
                        originalImages.Add(img);
                        imageNames.Add(Path.GetFileNameWithoutExtension(fileName));
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

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    var folderName = folderDialog.SelectedPath;

                    for (int i = 0; i < images.Count; i++)
                    {
                        var image = images[i];
                        var fileName = imageNames[i] + "_edited" + ".png";
                        var filePath = Path.Combine(folderName, fileName);
                        image.Save(filePath, ImageFormat.Png);
                    }
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

            for (int i = 0; i < images.Count; i++)
            {
                images[i] = originalImages[i];
            }
        }
    }
}