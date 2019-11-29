using System;
namespace MyRez.Models
{
    public class WorkOrder
    {
            public int WorkOrderID { get; }
            public String WorkOrderMonth { get; set; }
            public String WorkOrderItem { get; set; }
            public int ResId { get; set; }
    }
}
