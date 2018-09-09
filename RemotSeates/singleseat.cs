using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotSeates
{
    [Serializable]
   public class singleseat
   {
       #region Gloabal variables
       public string ownerName;
        public int[] rgb;
        public bool isReservered = false;
        public int seat_row, seat_column;
       #endregion

        #region Set Proparites
        public void setLocation(int row, int col)
        {
            seat_row = row;
            seat_column = col;
        }
        public void setOwner(string name)
        {
            ownerName = name;
            isReservered = true;
        }

        public void removeOwner()
        {
            ownerName = string.Empty;
            isReservered = false;
        }
        #endregion
   }
}
