using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.OSDB.Modles
{
    public class GenericControl
    {
        private readonly string id;

        private readonly string content;

        public GenericControl() { }

        public GenericControl(string id, string content)
        {
            this.id = id;
            this.content = content;
        }

        public String Id => id;

        public String Content => content;
    }
}
