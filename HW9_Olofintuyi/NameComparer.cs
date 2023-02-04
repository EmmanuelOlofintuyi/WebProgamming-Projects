using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW9_Olofintuyi
{
    public class NameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((Ticket)x).Name, ((Ticket)y).Name);
        }
    }
}