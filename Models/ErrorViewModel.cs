using System;
using System.ComponentModel.DataAnnotations;

namespace Online_Exam_Management_System.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);


    }
}
