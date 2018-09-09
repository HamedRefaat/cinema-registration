using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using RemotSeates;
using System.Threading;
namespace Cinema_Seates_REG
{
    public partial class Form1 : Form
    {
        #region Global variables
        Remotticket m_remoteRoomState;
        Thread th;
        singleseat[,] m_CloneSeats;
        int m_RowsCount, m_ColsCount;
        Dictionary<string, Color> names;
        Random randomcolor;
        #endregion
        public Form1()
        {
           
            InitializeComponent();
            inittable();
            names = new Dictionary<string, Color>();
            randomcolor = new Random();
            
            #region connect server
           
            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);
            m_remoteRoomState = (Remotticket)Activator.GetObject(
                typeof(Remotticket),
                "http://localhost:9000/Room_Service_Url");
            if (m_remoteRoomState == null)
            {
                MessageBox.Show("Failed to get remote object");
                Close();
            }
            else
            {
                m_CloneSeats = (singleseat[,])m_remoteRoomState.m_allSeats.Clone(); //copy
           
                m_RowsCount = m_CloneSeats.GetLength(0);
                m_ColsCount = m_CloneSeats.GetLength(1);
            }
            #endregion

            #region Update GUI continuously
            ThreadStart t = new ThreadStart(updateGUi);
             th = new Thread(t);
             th.IsBackground = true;
             th.Start();
            #endregion
        }

        #region Create GUI for first time
        void inittable()
        {
          
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.ColumnCount = 8;
            Seat seat;

            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    seat = new Seat();
                    seat.Tag = new int[] { i, j };
                    seat.lbname.MouseClick += lbname_MouseClick;
                    seat.lncoclr.MouseClick += lbname_MouseClick;       
                    tableLayoutPanel1.Controls.Add(seat);
                }
            }
            tableLayoutPanel1.RowStyles.Clear();
         
        
        }
        #endregion

        #region Update GUI
        void updateGUi()
        {
            while (true)
            {
                //  th = new Thread(new ThreadStart(new Action(delegate { 
                for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                    {
                        Seat seat = tableLayoutPanel1.GetControlFromPosition(j, i) as Seat;
                        int row = (seat.Tag as int[])[0];
                        int col = (seat.Tag as int[])[1];

                        if (m_remoteRoomState.m_allSeats[row, col].isReservered)
                        {

                            seat.setname(m_remoteRoomState.m_allSeats[row, col].ownerName);
                            int[] rgb = m_remoteRoomState.m_allSeats[row, col].rgb;
                            Color scolor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                            if (!names.ContainsKey(m_remoteRoomState.m_allSeats[row, col].ownerName))
                                names.Add(m_remoteRoomState.m_allSeats[row, col].ownerName, scolor);
                            seat.setcolor(scolor);
                        }
                    }
                }

                //})));
                //     th.Start();
            }
        }
        #endregion

        #region Reservation on Click
        void lbname_MouseClick(object sender, MouseEventArgs e)
        {
           
            Seat _Seat = ((sender as Label).Parent.Parent as Seat);
            int i = (_Seat.Tag as int[])[0];
            int j = (_Seat.Tag as int[])[1];
            int R = randomcolor.Next(1, 244);
            int G = randomcolor.Next(1, 244);
            int B = randomcolor.Next(1, 244);
           
            if (textBox1.Text != string.Empty)
            {
               
                Color col;
                if (names.ContainsKey(textBox1.Text))
                {
                    col = names[textBox1.Text];
                    R = col.R; G = col.G; B = col.B;
                }
                else
                {
                

                    col = Color.FromArgb(R, G, B);

                    names.Add(textBox1.Text, col);
                }
                if (m_remoteRoomState.ReserveSeat(i, j, textBox1.Text, new int[] { R, G, B }))
                {
                    
                    _Seat.setname(textBox1.Text);
                    _Seat.setcolor(col);
                }
                textBox1.Text = string.Empty;
            }
            else
            MessageBox.Show("Please, Enter Customer Name");
         
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            th.Abort();
        }

    }
}
