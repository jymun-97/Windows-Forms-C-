using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            foreach (var item in DataManager.Users)
            {
                comboBoxUserList.Items.Add(item.Id.ToString());
            }
        }

        private void selectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            List<Book> output = (from item in DataManager.Books
                         where (item.UserId.ToString() == cb.SelectedItem.ToString()
                            && item.isBorrowed)
                         select item).ToList();

            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = output;
        }
    }
}
