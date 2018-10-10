﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyWithAuthentication.Models;

namespace VidlyWithAuthentication.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}