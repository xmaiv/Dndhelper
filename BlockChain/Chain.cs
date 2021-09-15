using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockChain
{
    /// <summary>
    /// Цепочка блоков.
    /// </summary>
    public class Chain
    {
        /// <summary>
        /// Список блоков цепочки.
        /// </summary>
        public List<Block> Blocks { get; private set; }
        /// <summary>
        /// Последний блок.
        /// </summary>
        public Block Last { ge