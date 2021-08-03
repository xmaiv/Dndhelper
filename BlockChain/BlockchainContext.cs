using System.Data.Entity;

namespace BlockChain
{
    public class BlockchainContext : DbContext
    {
        public BlockchainContext() : base("BlockchainDB") { }


        public DbSet<Block> Blocks { get; set; }
  