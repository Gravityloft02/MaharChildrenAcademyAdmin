using MaharChildrenAcademyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaharChildrenAcademyAdmin.Interfaces
{
   public interface IAdmin
    {
        Task<bool> AddAlbum(AlbumModel album);
    }
}
