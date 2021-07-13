using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaharChildrenAcademyAdmin.Models
{
    public class DocumentModel
    {
        ///// <summary>
        ///// Optional
        ///// </summary>
        //public IFormFile File { get; set; }

        /// <summary>
        /// Required - Application Name
        /// </summary>
        public string AppName { get; set; }
        public string Identity { get; set; }
        public short ImageType { get; set; }
        public short DocumentType { get; set; }
        public string FileName { get; set; }

        /// <summary>
        /// Pass ImageArray if dont have base64encrypteddata
        /// </summary>
        public byte[] ImageArray { get; set; }

        /// <summary>
        /// Pass base64encrypteddata if dont have ImageArray
        /// </summary>
        public string Base64EncryptedData { get; set; }
        public Int64 UniqueDocumentId { get; set; }
    }
}