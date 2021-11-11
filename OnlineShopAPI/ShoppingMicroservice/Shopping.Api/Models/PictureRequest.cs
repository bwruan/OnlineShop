using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Models
{
    public class PictureRequest
    {
        public long ItemId { get; set; }

        public string Picture { get; set; }
    }
}
