﻿using System.Collections.Generic;

namespace permiakov_lab4.Models
{
    class UserStorage
    {
        public UserStorage(List<Person> users)
        {
            Users = users;
        }

        public List<Person> Users { get; set; } = new List<Person>();
    }
}

