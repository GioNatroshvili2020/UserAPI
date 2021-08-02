using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.Model
{
    public class OperationResult
    {
        public Boolean Result { get; set; }

        public String Message { get; set; }

        public object Data { get; set; }
        public String UrlAction { get; set; }

        public OperationResult()
        {

        }

        public OperationResult(bool result)
        {
            if (result)
                SetSuccess();
        }

        public void SetSuccess()
        {
            Message = "Operation Succeeded";
            Result = true;
        }

        public void SetSuccess(String message)
        {
            Message = message;
            Result = true;
        }

        public void SetError(String message)
        {
            Message = message;
            Result = false;
        }

    }
}
