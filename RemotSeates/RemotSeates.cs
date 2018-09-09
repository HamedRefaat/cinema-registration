using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotSeates
{
    public class Remotticket:MarshalByRefObject
    {
        
        public singleseat[,] m_allSeats = new singleseat[8,8];

        #region Init all seates with thier locations
        public Remotticket()
        {
            for (int i = 0; i < m_allSeats.GetLength(0); i++)
            {
                for (int j = 0; j < m_allSeats.GetLength(1); j++)
                {
                    m_allSeats[i, j] = new singleseat();
                    m_allSeats[i, j].seat_row = i;
                    m_allSeats[i, j].seat_column = j;
                }
            }
        }
        #endregion

        #region Reservation operation 
        public bool ReserveSeat(int row, int col, string name,int[]rgb)
        {
            lock (this)
            {
                if (m_allSeats[row, col].isReservered)
                    return false; 
                else
                {
                    m_allSeats[row, col].setOwner(name);
                    m_allSeats[row, col].rgb = rgb;
                    return true;
                }
            }
        }
        #endregion
    }
}
