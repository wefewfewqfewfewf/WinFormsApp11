using System.Linq.Expressions;

namespace WinFormsApp11
{
    public partial class lista : Form
    {
        public lista()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void danedodane(string tytul,string rezyser,string data,string aktor)
        { 
      ListViewItem item  = new ListViewItem(new string[] { tytul,rezyser,data,aktor});
            listView1.Items.Add(item);
        }
        private void danedodane(string[] dane)
        { 
        ListViewItem item=new ListViewItem(dane);
            listView1.Items.Add(item);

        }
        private void daneusuwane()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        
        }
        private string[] daneplikowane()
        {
            string[] linie = new string[listView1.Items.Count];
            int i = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                linie[i] = "";
                for (int k=0;k<item.SubItems.Count;k++)
                    linie[i]+= item.SubItems[k].Text+"+";
                i++;
            }
            return linie;
        }
        private void daneodzczytane()
        {
            if (!File.Exists("filmy.txt"))
                return;
            string[] linie = File.ReadAllLines("filmy.txt");
            foreach (string linia in linie)
            {
                string[]yikes = linia.Split('*');
                danedodane(yikes);
            }
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zapisz_Click(object sender, EventArgs e)
        {
            string[] linie = daneplikowane();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            danedodane(tytul.Text, rezyser.Text, data.Text, rezyser.Text);
        }
    }
}