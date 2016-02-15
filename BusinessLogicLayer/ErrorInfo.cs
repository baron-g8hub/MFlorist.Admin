using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist)
    /// Date    : February 10, 2016 
    /// 
    /// BLL - ErrorInfo domain object
    /// </summary>
    public class ErrorInfo
    {
        public int ErrorID { get; set; }
        public string DataAreaID { get; set; }
        public decimal SeverityID { get; set; }
        public string StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string UserID { get; set; }
        public DateTime LogDateTime { get; set; }

        public IRepository Repository { get; set; }

        public int LogError()
        {
            return Repository.LogError(DataAreaID, SeverityID, StatusCode, ErrorMessage, UserID, LogDateTime);
        }
    }
}