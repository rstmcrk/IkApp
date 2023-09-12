﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.DTOs
{
    public class NotificationDTO
    {
        public int ID { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationDetail { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
    }
}
