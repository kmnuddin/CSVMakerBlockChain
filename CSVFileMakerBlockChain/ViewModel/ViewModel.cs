using CSVFileMakerBlockChain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain.View_Model
{
    public class ViewModel : IViewModel
    {
        public IList<IBlockHeight> nodes_block_heights { get; set; }
        public IList<ITransaction> nodes_block_transactions { get; set; }
        public IList<IBlock> node_blocks { get; set; }

        private IWebRepository _webRepository;
        private IList<string> transactions;

        public ViewModel(IWebRepository webRepository)
        {
            _webRepository = webRepository;

        }

        public async Task Populate_Block_ListAsync(ListBox listbox, int from, int to)
        {
            for (int height = from; height <= to; height++)
            {
                nodes_block_heights = (List<IBlockHeight>) await _webRepository.ParseBlockHeightAsync(height);

                BindingList<IBlockHeight> binding_list = new BindingList<IBlockHeight>(nodes_block_heights);

                node_blocks = (List<IBlock>) await _webRepository.ParseBlocksAsync(nodes_block_heights.Last());

                transactions = (List<string>) await _webRepository.ParseTransactionIDsAsync();
                

                listbox.DataSource = binding_list;
                listbox.DisplayMember = "Height"; 
            }
        }

        
    }
}
