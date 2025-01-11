using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quiz_GUI.Stores
{
    public class SelectedPlayerStores
    {
        private Models.Player _selectedPlayer;

        public Models.Player selectedPlayer
        {
            get
            {
                return _selectedPlayer;
            }
            set
            {
                _selectedPlayer = value;
                SelectedPlayerChanged?.Invoke();
            }
        }

        public event Action SelectedPlayerChanged;
    }
}
