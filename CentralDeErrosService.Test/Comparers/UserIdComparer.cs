﻿using CentralDeErros.DTO;
using CentralDeErros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErrosService.Test.Comparers
{
    public class UserIdComparer : IEqualityComparer<UserDTO>
    {
        public bool Equals(UserDTO x, UserDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(UserDTO obj)
        {
            return obj.GetHashCode();
        }
    }
}
