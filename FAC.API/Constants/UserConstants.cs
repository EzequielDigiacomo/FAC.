﻿using Fac.Entidades;

namespace FAC.API.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
              new UserModel()
              {
                  Username = "admin",
                  Password = "admin",
                  Rol = "Administrador",
                  EmailAdress = "ezequiel250891@hotmail.com",
                  LastName = "Di Giacomo",
                  FirstName = "Ezequiel"
              },

               new UserModel()
              {
                  Username = "user1",
                  Password = "user1",
                  Rol = "usuer",
                  EmailAdress = "user1@hotmail.com",
                  LastName = "Jose",
                  FirstName = "Perez"
              }
        };
    }
}
