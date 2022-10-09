using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Svcs
{
    public class UserService : IUser
    {
        #region private methods
        private IEnumerable<User> GetUsersInfos() //Data Model: Database와 연동할 Model
        {
            return new List<User>()
            {
                new User()
                {
                    UserId = "ideal1",
                    UserName = "이상규",
                    UserEmail = "idealgyu@kakao.com",
                    Password = "123456"
                }
            };
        }
        private bool checkTheUserInfo(string userId, string password)
        {
            return GetUsersInfos().Where(u => u.UserId.Equals(userId) && u.Password.Equals(password)).Any(); //Any 메서드 : 리스트 데이터 유무체크
        }
        #endregion

        bool IUser.MatchTheUserInfo(LoginInfo login)//Service class : Interface를 상속 받은 후에 명시적으로 Interface 구현
        {
            return checkTheUserInfo(login.UserId, login.Password);
        }
    }
}
