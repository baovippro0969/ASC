using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Model.BaseTypes
{
    internal class Constants
    {
    }
    public enum Roles
    {
        Admin, Engineer, User
    }

    public enum MasterKeys
    {
        VehicleName, VehicleType
    }

    public enum Status
    {
        New, Denied, Pending, Initiated, InProgress,
        PendingCustomerApproval, RequestForInformation, Completed
    }
}
