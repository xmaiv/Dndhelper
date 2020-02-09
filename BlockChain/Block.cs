
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