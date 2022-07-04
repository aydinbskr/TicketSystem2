using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SessionAdded = "Session eklendi";
        public static string SessionTimeInvalid = "Session Bugünden önceki tarih olamaz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string SessionsListed="Session lar listelendi";
        public static string SessionCountOfSceneError="Bir sahnede en fazla 10 session olabilir";
        public static string MovieLimitExceed="Film limiti aşıldı";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        
    }
}
