using System;
using ContactsAPI.Models;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace ContactsAPI.Controllers
{
    public class ContactsAPIController : Controller
    {

        readonly IUserService service;
        readonly ILogger<ContactsAPIController> _logger;
        public ContactsAPIController(IUserService userService, IConfiguration configuration, ILogger<ContactsAPIController> logger)
        {
            service = userService;
            _logger = logger;
        }

        [HttpGet("GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            try
            {
                _logger.LogInformation($"Getting all user contacts");
                return Ok(service.GetContactList());
            }
            catch (UserNotFoundException cnf)
            {
                _logger.LogInformation($"No user contacts available");
                return NotFound(cnf.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in fetching data: {ex.Message}");
                return StatusCode(500);
            }
        }


        [HttpGet("GetContactDetailsById/{userId}")]
        public IActionResult GetContactDetailsById(int userId)
        {
            try
            {
                _logger.LogInformation($"Getting Contact details of user : {userId}");
                return Ok(service.GetContactDetails(userId));
            }
            catch (UserNotFoundException cnf)
            {
                _logger.LogInformation($"User ID : {userId} not exists");
                return NotFound(cnf.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in fetching data: {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
