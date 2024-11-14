using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // `GET /api/pets` should return a list of pet objects. Each pet should contain a nested `petOwner` field that contains the full `PetOwner` object that owns this pet. Be sure that the `PetOwner` object does not additionally circularly reference the pets owned. DONE
        // `GET /api/pets/:id` should return the pet object with the given id. DONE
        // `POST /api/pets` should create a new pet object. The body of the HTTP post should contain the `Pet` object in JSON format with all required fields. The `Pet` object should contain a reference to a `PetOwnerId`, which is the primary key of the `PetOwner` that the pet belongs to. DONE
        // `PUT /api/pets/:id` should update the `Pet` with the given primary key (id). The HTTP Body should include the entire `Pet` object to be updated with all required keys, including the `id`.
        // `DELETE /api/pets/:id` should delete the pet with the given id. DONE
        // `PUT /api/pets/:id/checkin` should check in a pet with given id. Checking in will set the `checkedInAt` field to an ISO8601 timestamp that set to the current time.
        // `PUT /api/pets/:id/checkout` should check out the pet with the given id. Checking out simply resets the `checkedInAt` field to `null`.













        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
         public IEnumerable<Pet> GetPets() {
            return _context.Pets
            .Include(pet => pet.petOwner);
        }

        [HttpPost]
        public Pet Post(Pet pet) {
            pet.checkedInAt = null;
            _context.Add(pet);
            _context.SaveChanges();
            Response.StatusCode = 201;
            return pet;
        }

         [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id){
            Pet pet = _context.Pets.Include(pet => pet.petOwner)
            .SingleOrDefault(pet => pet.id == id);

            if(pet is null){
                return NotFound();
            }
            return pet;
        }
    
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //set the pet variable equal to the pet in the pets
            //table with the id that was sent as a parameter
            Pet pet = _context.Pets.Find(id);
            //remove that pet  from the pets table
            _context.Pets.Remove(pet);
            //save changes
            _context.SaveChanges();
            //send status 204 - no content to return
            Response.StatusCode = 204;
        }

        [HttpPut("{id}")]
        public Pet updatePet(int id, Pet pet)
        {
            Pet toUpdate = _context.Pets.Find(id);
            if(toUpdate is null){
                Response.StatusCode=404;
                return null;
            }
            toUpdate.name = pet.name;
            toUpdate.breed = pet.breed;
            toUpdate.color = pet.color;
            toUpdate.petOwnerId = pet.petOwnerId;
            toUpdate.checkedInAt = pet.checkedInAt;
            _context.SaveChanges();
            return toUpdate;
        }

        [HttpPut("{id}/checkin")]
        public Pet checkinPet(int id)
        {
            Pet toUpdate = _context.Pets.Find(id);
            if(toUpdate is null){
                Response.StatusCode=404;
                return null;
            }
            toUpdate.checkedInAt = DateTime.UtcNow;

            _context.SaveChanges();
            return toUpdate;
        }

        [HttpPut("{id}/checkout")]
        public Pet checkOutPet(int id)
        {
            Pet toUpdate = _context.Pets.Find(id);
            if(toUpdate is null){
                Response.StatusCode=404;
                return null;
            }
            toUpdate.checkedInAt = null;

            _context.SaveChanges();
            return toUpdate;
        }
        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
