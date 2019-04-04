using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain.Interfaces
{
    public interface IViewModel
    {
        Task Populate_Block_ListAsync(ListBox listbox, int from, int to);

        IList<IBlockHeight> nodes_block_heights { get; set; }
        IList<ITransaction> nodes_block_transactions { get; set; }
        IList<IBlock> node_blocks { get; set; }
    }
}
