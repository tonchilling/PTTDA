using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public interface IAntiforgeryToken
    {
        void IsVeryfy(HttpContext context);


    }
