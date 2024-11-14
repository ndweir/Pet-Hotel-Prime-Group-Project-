using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

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
    public class Pet {}
}
