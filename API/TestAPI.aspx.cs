using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestAPI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShipPlan();
    }


    void ShipPlan()
    {
       // int moveDay = 0;

        int diffPODay = 0;
        int diffActionDay = 0;

        int diffSpecPODay = 0;
        int diffPOActionDay = 0;

        // spec
        DateTime SpecSTDate = new DateTime(2018,3,1);
        DateTime SpecETDate = new DateTime(2018, 3, 7);


        // po
        DateTime POSTDate = new DateTime(2018, 3, 8);
        DateTime POETDate = new DateTime(2018, 3, 21);

        diffPODay = POETDate.Day - POSTDate.Day;


        // action
        DateTime ActionSTDate = new DateTime(2018, 3, 22);
        DateTime ActionETDate = new DateTime(2018, 3, 31);
        diffActionDay = ActionETDate.Day - ActionSTDate.Day;



        diffSpecPODay = POSTDate.Day - SpecETDate.Day;

        diffPOActionDay = ActionSTDate.Day - POETDate.Day;




        // Change
        DateTime ChangeSDate= new DateTime(2018,3,8);
        DateTime ChangeEDate = new DateTime(2018, 3, 14);
      //  moveDay = ChangeSDate.Day - SpecSTDate.Day;







        POSTDate = ChangeEDate.AddDays(diffSpecPODay); //15

        POETDate = POSTDate.AddDays(diffPODay);

        if (POETDate.Day >= 22 && POETDate.Day <= 31)
        {
            POETDate = new DateTime(POETDate.Year, POETDate.Month,1).AddMonths(1).AddDays(-1);

        }
        else if (POETDate.Day > 7 && POETDate.Day <= 10)
        {
            POETDate = new DateTime(POETDate.Year, POETDate.Month, 7);
        }


        ActionSTDate = POETDate.AddDays(diffPOActionDay);

        ActionETDate = ActionSTDate.AddDays(diffActionDay);

        if (ActionETDate.Day >= 22 && ActionETDate.Day <= 31)
        {
            ActionETDate = new DateTime(ActionETDate.Year, ActionETDate.Month,1).AddMonths(1).AddDays(-1);

        }
        else if (ActionETDate.Day > 7 && ActionETDate.Day <= 10)
        {
            ActionETDate = new DateTime(ActionETDate.Year, ActionETDate.Month, 7);
        }
    }
}