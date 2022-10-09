﻿using NetCore.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Interfaces
{
    public interface IUser //Interface:실제 사용할 서비스 메서드 선언
    {
        bool MatchTheUserInfo(LoginInfo login);
    }
}
