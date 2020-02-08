
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