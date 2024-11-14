using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;

namespace pet_hotel
{
    public enum PetBreed {
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }
    public enum PetColor {
        White, Black, Golden, Tricolor, Spotted
    }
    public class Pet {
        public int id {get ; set;}

        [Required]
        public string name {get; set;}

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreed breed {get; set;}

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColor color {get; set;}

        
        public DateTime? checkedinAt {get; set;}

        [Required, ForeignKey("PetOwnerId")]
        public int petOwnerId {get; set;}

        public PetOwner petOwner {get; set;}


        /*int id: primary key
string name (required): The pet name
PetBreed breed (required): Pet breed, based on the PetBreed enum.
PetColor color (required): Pet color, based on the PetColor enum.
DateTime checkedInAt (nullable): The time that this pet was checked in. If null, the pet has not been checked in yet.
int petOwnerid */

    }
}
