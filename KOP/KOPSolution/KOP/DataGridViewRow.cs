using System;
using System.Web.UI.WebControls;

namespace KOP
{
    internal class DataGridViewRow
    {
        public bool Selected { get; internal set; }

        public static implicit operator DataGridViewRow(GridViewRow v)
        {
            throw new NotImplementedException();
        }
    }
}