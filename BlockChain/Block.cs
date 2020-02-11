
﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace BlockChain
{
    /// <summary>
    /// Блок данных.
    /// </summary>
    [DataContract]
    public class Block
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Данные блока.
        /// </summary>
        [DataMember]
        public string Data { get; private set; }
        /// <summary>
        /// Дата создания блока.
        /// </summary>
        [DataMember]
        public DateTime Created { get; private set; }
        /// <summary>
        /// Хэш блока.
        /// </summary>
        [DataMember]
        public string Hash { get; private set; }
        /// <summary>
        /// Хэш предыдущего блока.
        /// </summary>
        [DataMember]
        public string PreviousHash { get; private set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [DataMember]
        public string User { get; private set; }


        /// <summary>
        /// Конструктор генезис блока.
        /// </summary>
        public Block()
        {
            Id = 1;
            Data = "Hello world";
            Created = DateTime.Parse("03.04.2020 00:00:00.000").ToUniversalTime();
            PreviousHash = "111111";
            User = "Admin";
            Hash = GetHash(GetData());
        }
        
        /// <summary>
        /// Конструктор блока.
        /// </summary>
        /// <param name="data">Данные блока.</param>
        /// <param name="user">Имя пользователя.</param>
        /// <param name="block">Предыдущий блок.</param>
        public Block(string data, string user, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException(nameof(data), "Данные не могут быть пустыми...");
            }

            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException(nameof(user), "Пользователь не может быть пустым...");
            }

            if (block is null)
            {
                throw new ArgumentNullException(nameof(block), "Блок, не может быть пустым...");
            }

            Data = data;
            User = user;
            Hash = GetHash(GetData());
            PreviousHash = block.Hash;
            Created = DateTime.UtcNow;
            Id = block.Id + 1;
        }

        /// <summary>
        /// Получение данных блока.
        /// </summary>
        /// <returns>Блок в виде строки.</returns>
        private string GetData()
        {
            var result = "";
            //result += Id.ToString();
            result += Data;
            result += Created.ToString("dd.MM.yyyy HH:mm:ss.fff");
            result += PreviousHash;
            result += User;

            return result;
        }

        /// <summary>
        /// Хэширование.
        /// </summary>
        /// <param name="data">Блок в виде строки.</param>
        /// <returns>Хэш блока.</returns>
        private string GetHash(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            SHA256Managed hash = new SHA256Managed();
            var value = hash.ComputeHash(message);

            var hex = "";
            foreach (var x in value)
            {
                hex += string.Format("{0:x2}", x);
            }

            return hex;
        }


        public override string ToString() => Data;

        /// <summary>
        /// Сериализация объекта Block из JSON строки.
        /// </summary>
        /// <returns>JSON строка.</returns>
        public string Serialize()
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Block));

            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());

                return result;
            }
        }
