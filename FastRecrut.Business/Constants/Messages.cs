using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using FastRecrut.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAdded = "User added";
        public static string UserDeleted = "User deleted";
        public static string UserUpdated = "User updated";
        public static string UserList = "User list";


        public static string MaintenanceTime= "Site under maintenance";

        public static string FailAddedImageLimit = "Resim limiti aşıldı";
        public static string AuthorizationDenied = "Authorization denied";

        public static string UserRegistered = "User Registered";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Password Error";
        public static string SuccessfulLogin = "Successfull Login";
        public static string UserAlreadyExists = "User Already Exists";

        public static string AccessTokenCreated = "Access Token Created";
    }
}
