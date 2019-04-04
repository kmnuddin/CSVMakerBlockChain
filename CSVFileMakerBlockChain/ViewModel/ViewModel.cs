using CSVFileMakerBlockChain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVFileMakerBlockChain.View_Model
{
    public class ViewModel : IViewModel
    {
        private IWebRepository _webRepository;

        public ViewModel(IWebRepository webRepository)
        {
            _webRepository = webRepository;
        }
        public async Task Populate_Block_ListAsync(ListBox listbox, int from, int to)
        {
            for (int height = from; height <= to; height++)
            {
                await _webRepository.ParseBlockHeightAsync(height);

                BindingList<IBlockHeight> binding_list = new BindingList<IBlockHeight>(_webRepository.nodes_block_heights);

                listbox.DataSource = binding_list;
                listbox.DisplayMember = "Height"; 
            }
        }
    }
}
