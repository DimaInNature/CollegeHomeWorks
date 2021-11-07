using System;
using Work3.Models;

namespace Work3.Interfaces.Models
{
    public interface IReader : IHuman
    {
       int Id { get; set; }

       DateTime BirthDay { get; set; }

       string Phone { get; set; }

       DateTime DateOfTaking { get; set; }

       Book Book { get; set; }
    }
}