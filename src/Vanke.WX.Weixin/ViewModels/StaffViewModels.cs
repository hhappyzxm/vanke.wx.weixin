﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vanke.WX.Weixin.ViewModels
{
    public class StaffEditViewModel
    {
        public long ID { get; set; }

        public string RealName { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsExternalPersonnelDiningManager { get; set; }

        public bool IsItemBorrowManager { get; set; }
    }

    public class StaffImportViewModel
    {
        public string FileName { get; set; }
    }

    public class StaffSearchViewModel
    {
        public string RealName { get; set; }
    }
}