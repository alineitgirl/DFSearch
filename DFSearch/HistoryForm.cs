using DFSearch.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFSearch
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(List<Session> sessions)
        {
            InitializeComponent();
            LoadSessionHistory(sessions);
        }
        private void LoadSessionHistory(List<Session> sessions)
        {
            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = sessions; 

           
            dataGridView1.Columns["Actions"].Visible = false; 
            dataGridView1.Columns["StartTime"].HeaderText = "Начало";
            dataGridView1.Columns["EndTime"].HeaderText = "Конец";
            dataGridView1.Columns["UserName"].HeaderText = "Пользователь";
        }
    }
}
