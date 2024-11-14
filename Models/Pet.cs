using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;

namespace pet_hotel
{
    public enum PetBreedType : byte 
    {
        Shepherd, Poodle, Beagle, Bulldog, Terrier, Boxer, Labrador, Retriever
    }
    public enum PetColorType : byte
     {
        White, Black, Golden, Tricolor, Spotted

     }
    public class Pet {

        public int id {get; set;}

        [Required]
        public PetColorType color {get; set;}

        [AllowNull]
        public DateTime checkedinAt {get; set;}

        public string name {get; set;}

        [Required]
        public PetBreedType breed {get; set;}

        [Required, ForeignKey("PetOwnerId")]
        public int PetOwnerId {get; set;}

        
    }
}


