using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.SelectMenu
{
    public class StatusMenu
    {
        public string Query { get; set; }

        public StatusMenu(string query)
        {
            Query = query;
        }
    }
}
