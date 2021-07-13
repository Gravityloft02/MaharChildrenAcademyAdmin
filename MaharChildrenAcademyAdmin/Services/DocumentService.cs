using MaharChildrenAcademyAdmin.Models;
using MaharChildrenAcademyAdmin.Interfaces;
using MaharChildrenAcademyAdmin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MaharChildrenAcademyAdmin.Services
{
    public class DocumentService :BaseService, IDocument
    {
        public async Task<string> UploadDocuments(DocumentModel request)
        {
            var responese = await DocumentUploadAsync(request);

            return responese;
        }
    }
}