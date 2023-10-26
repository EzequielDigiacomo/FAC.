﻿using Fac.Entidades;

namespace FAC.API.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
              new UserModel()
              {
                  UserName = "admin",
                  Password = "admin",
                  Rol = "administrador",
                  EmailAdress = "ezequiel250891@hotmail.com",
                  LastName = "Di Giacomo",
                  FirstName = "Ezequiel"
              },

               new UserModel()
              {
                  UserName = "user1",
                  Password = "user1",
                  Rol = "entrenador",
                  EmailAdress = "user1@hotmail.com",
                  LastName = "Jose",
                  FirstName = "Perez"
              }
        };
    }
}
