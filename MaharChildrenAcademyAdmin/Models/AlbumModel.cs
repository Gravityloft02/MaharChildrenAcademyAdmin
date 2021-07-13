using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaharChildrenAcademyAdmin.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        //public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public int Flag { get; set; }
        public List<string> Image { get; set; }
        public string HiddenImages
        {
            get
            {
                if (this.Image != null && this.Image.Count() > 0)
                {
                    string _images = "";
                    foreach (string _img in this.Image)
                    {
                        _images = _images + GetFileName(_img) + "," + _img + ";";
                    }
                    return _images;
                }
                return "";
            }
        }

        private string GetFileName(string file)
        {
            var str = file.Split('/');
            int l = str.Length;
            return str[l - 1];
        }

    }
}