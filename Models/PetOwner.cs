using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner {

        public int id {get ; set;}

        [Required]
        [EmailAddress]
        public string emailAddress {get; set;}
        [Required]
        public string name {get; set;}

        [NotMapped]
        public int petCount {get; set;}

        [JsonIgnore]
        public List<Pet> petList {get; set;}




    }
}
