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
        public Block Last { get; private set; }
        //private BlockchainContext context;

        /// <summary>
        /// Конструктор создания цепочки блоков.
        /// </summary>
        public Chain()
        {
            Blocks = Load();
            if (Blocks.Count == 0)
            {
                var genesisBlock = new Block();

                Blocks.Add(genesisBlock);
                Last = genesisBlock;

                Save(Last);
            }
            else
            {
                if (Check())
                {
                    Last = Blocks.Last();
                }
                else
                {
                    throw new Exception("Ошибка получения блоков из базы данных. Цепочка не прошла проверку на целостность.");
                }
            }
        }

        /// <summary>
        /// Добавление нового блока.
        /// </summary>
        /// <param name="data">Данные блока.</param>
        /// <param name="user">Имя пользователя.</param>
        public void Add(string data, string user)
        {
            var block = new Block(data, user, Last);
            Blocks.Add(block);
            Last = block;

            Save(block);
        }

        /// <summary>
        /// Метод проверки корректности цепочки.
        /// </summary>
        /// <returns>Р