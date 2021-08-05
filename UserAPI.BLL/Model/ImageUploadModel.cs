using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.Model
{
    public class ImageUploadModel
    {
        public int PersonId { get; set; }
        public IFormFile Image { get; set; }
    }
}
