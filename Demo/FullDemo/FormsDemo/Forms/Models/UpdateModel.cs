using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Demo.Models
{
    public class UpdateModel
    {
        public bool IsAdd { get; set; }

        public NoteModel Data { get; set; }
        public int ID { get; internal set; }
    }
}
