﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.DAL.Enums
{
    public enum RoomType
    {
        SharedAppartment = 1,
        SapareteRoom,
        SharedHouse
    }

    public enum HomeType
    { 
        House = 1,
        Appartment,
        Studio,
        Bungallo
    }

    public enum UserRole
    {
        Owner = 1,
        Client
    }
}
