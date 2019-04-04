using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain.Interfaces
{
    public interface IViewModel
    {
        Task Populate_Block_ListAsync(ListBox listbox, int from, int to);
    }
}
