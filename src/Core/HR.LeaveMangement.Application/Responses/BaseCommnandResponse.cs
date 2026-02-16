using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Responses
{
    public class BaseCommnandResponse
    {
        public int Id {  get; set; }    
        public bool Success { get; set; }
        public string Message { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
