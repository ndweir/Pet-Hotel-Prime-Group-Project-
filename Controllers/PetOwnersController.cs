using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        /*
        /api/petowners is the base URL for the Pet Owner API

GET /api/petowners/ should return a list of pet owner objects. A Pet Owner should have a read-only petCount field that contains the number of pets that belong to the pet owner. DONE

GET /api/petowners/:id should return the PetOwner object with the given id. DONE

POST /api/petowners/ should create a new pet object. The body of the HTTP post should contain the PetOwner object in JSON format with all required fields. DONE

DELETE /api/petowners/:id should delete the Pet Owner with the given primary key (id).

PUT /api/petowners/:id should update the Pet Owner with the given primary key (id). The HTTP Body should include the entire Pet Owner object to be updated with all required keys, including the id.
*/

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        //GET /api/petowners/
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return _context.PetOwners;
        }

        //POST /api/petowners/
        [HttpPost]
        public PetOwner Post(PetOwner petOwner) {
            _context.Add(petOwner);
            _context.SaveChanges();
            return petOwner;
        }

        //GET /api/petowners/:id
         [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id){
            PetOwner petOwner = _context.PetOwners
            .SingleOrDefault(petOwner => petOwner.id == id);

            if(petOwner is null){
                return NotFound();
            }
            return petOwner;
        }

        //Deletes a pet owner from the petOwners table in the pet_hotel database
        //DELETE /api/petowners/:id 
         [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //set the petOwner variable equal to the pet owner in the petOwners
            //table with the id that was sent as a parameter
            PetOwner petOwner = _context.PetOwners.Find(id);
            //remove that pet owner from the petOwners table
            _context.PetOwners.Remove(petOwner);
            //save changes
            _context.SaveChanges();
            //send status 204 - no content to return
            Response.StatusCode = 204;
        }

        //PUT /api/pets/:id
        [HttpPut("{id}")]
        public PetOwner updatePetOwner(int id, PetOwner petOwner)
        {
            PetOwner toUpdate = _context.PetOwners.Find(id);
            if(toUpdate is null){
                Response.StatusCode=404;
                return null;
            }
            toUpdate.name = petOwner.name;
            toUpdate.emailAddress = petOwner.emailAddress;
            toUpdate.id = petOwner.id;
            _context.SaveChanges();
            return toUpdate;
        }
    }
}
