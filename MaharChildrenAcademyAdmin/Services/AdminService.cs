using MaharChildrenAcademyAdmin.Interfaces;
using MaharChildrenAcademyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MaharChildrenAcademyAdmin.Services
{
    public class AdminService:BaseService,IAdmin
    {
        #region Album
        public async Task<bool> AddAlbum(AlbumModel album)
        {
            var res = await ServiceCallAsync <bool>("Service/MaharAdmin/Gallery/Add", album, null);
            return res;
        }
        #endregion

    }
}