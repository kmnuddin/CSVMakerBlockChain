using CSVFileMakerBlockChain.Interfaces;

namespace CSVFileMakerBlockChain.Model
{
    public class BlockHeight : IBlockHeight
    {
        public BlockHeight()
        {
                
        }
        public string Hash { get; set; }
        public string Height { get; set; }
    }
}
