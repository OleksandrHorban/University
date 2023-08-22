using Problem5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    public class Robot : IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.model = model;
            this.id = id;
        }

        public string Id
        {
            get => this.id;
        }
    }
}
