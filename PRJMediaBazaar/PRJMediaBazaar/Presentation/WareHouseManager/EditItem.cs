using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRJMediaBazaar.Logic;
using System.IO;

namespace PRJMediaBazaar
{
     partial class EditItem : Form
    {
        private bool validData;

        private string path;
        private Image image;
        private Thread getImageThread;
        private WRHSHome wh;
        private Item x;
        private ItemControl _itemControl;

        private List<Button> buttons;
        private List<System.Windows.Forms.Timer> timers;
        public EditItem(WRHSHome wh,Item x, ItemControl itemControl)
        {
            InitializeComponent();
            _itemControl = itemControl;
            this.wh = wh;
            this.x = x;
            buttons = new List<Button>();
            timers = new List<System.Windows.Forms.Timer>();
        }
        public void StatusFunction(String text, int x, int y, int width, int height, Color color)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Width = width;
            newButton.Height = height;
            newButton.Enabled = false;
            newButton.BackColor = color;
            newButton.Text = text;
            this.Controls.Add(newButton);
            newButton.BringToFront();
            buttons.Add(newButton);
            System.Windows.Forms.Timer temp = new System.Windows.Forms.Timer();
            timers.Add(temp);
            temp.Start();
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            if (pData != null)
            {
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
            }
            else
                return null;

        }
        private void EditItem_Load(object sender, EventArgs e)
        {
            byte[] image = _itemControl.GetItemImage(x.ID);
            this.tbName.Text = x.Name;
            this.tbCategory.Text = x.Category;
            this.tbBrand.Text = x.Brand;
            this.tbModel.Text = x.Model;
            this.tbDescription.Text = x.Description;
            this.tbPrice.Text = x.Price.ToString();
            this.tbRoomWebshop.Value = x.RoomInWebshop;
            this.tbRoomShop.Value = x.RoomInShop;
            this.tbRoomStorage.Value = x.RoomInStorage;
            this.tbMinimumAmount.Text = x.MinimumAmountInStock.ToString();
            this.pbxCurrentImage.Image = ByteToImage(image);
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>();
                Helper.ValidateInteger(tbRoomWebshop.Text, "RoomWebshop", errors);
                Helper.ValidateInteger(tbRoomShop.Text, "RoomShop", errors);
                Helper.ValidateInteger(tbRoomStorage.Text, "RoomStorage", errors);
                Helper.ValidateInteger(tbMinimumAmount.Text, "MinimumAmount", errors);
                Helper.ValidateString(tbName.Text, "ItemName", errors);
                Helper.ValidateString(tbCategory.Text, "Category", errors);
                Helper.ValidateString(tbBrand.Text, "Brand", errors);
                Helper.ValidateString(tbModel.Text, "Model", errors);
                Helper.ValidateString(tbDescription.Text, "Description", errors);
                Helper.ValidateDouble(tbPrice.Text, "Price", errors);

                if (errors.Any())
                {
                    throw new InputException(errors);
                }

                byte[] img = null;
                int id = x.ID;
                string itemName = tbName.Text;
                string category = tbCategory.Text;
                string brand = tbBrand.Text;
                string model = tbModel.Text;
                string description = tbDescription.Text;
                double price = Convert.ToDouble(tbPrice.Text);
                int roomWebshop = Convert.ToInt32(tbRoomWebshop.Text);
                int roomShop = Convert.ToInt32(tbRoomShop.Text);
                int roomStorage = Convert.ToInt32(tbRoomStorage.Text);
                int minAmount = Convert.ToInt32(tbMinimumAmount.Text);

                _itemControl.UpdateAnItem(id, itemName, category, brand, model, description, price,
                    roomWebshop, roomShop, roomStorage, minAmount, img);
                wh.LoadItemsLESGOO();
               img = ImageToBinary(image);
               _itemControl.UpdateItemImage(id, img);
                StatusFunction("Item updated!", -6, -1, 900, 28, Color.Green);

            }
            catch (InputException ex)
            {
                StatusFunction(ex.ToString(), -6, -1, 900, 28, Color.Red);
            }

        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (timers[i].Enabled == true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }

        private void EditItem_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                pbxNewImage.Image = ScaleImage(image);
                image = pbxNewImage.Image;
                byte[] img = ImageToBinary(image);
            }
        }

        private void EditItem_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            string filename;
            validData = GetFilename(out filename, e);
            if (validData)
            {
                path = filename;
                getImageThread = new Thread(new ThreadStart(LoadImage));
                getImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }
        private void LoadImage()
        {
            image = new Bitmap(path);
        }
        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }
        private Image ScaleImage(Image image)
        {
            int height = this.pbxNewImage.Height;
            double ratio = (double)height / image.Height;
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
        private byte[] ImageToBinary(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
