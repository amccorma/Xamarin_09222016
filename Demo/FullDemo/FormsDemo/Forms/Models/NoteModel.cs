using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Demo.Models
{
    public class NoteModel : BindableBase
    {
        // for demo this will work as a Primary Key
        public static Int32 PrimaryKey = 0;

        private Int32 id;
        private string text;
        private DateTime entered;
       

        public NoteModel(string text, DateTime entered)
        {
            this.ID = PrimaryKey++;
            this.Text = text;
            this.Entered = entered;
        }

        public Int32 ID
        {
            get
            {
                return id;
            }
            set
            {
                SetProperty(ref id, value);
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                SetProperty(ref text, value);
            }
        }

        public DateTime Entered
        {
            get
            {
                return entered;
            }
            set
            {
                SetProperty(ref entered, value);
            }
        }
    }
}
