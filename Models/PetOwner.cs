using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner {
        public int id {get; set;}

        public string emailAddress {get; set;}

        public string name {get; set;}

        public int petCount {get; set;}



    }
}
