
using Microsoft.AspNetCore.Mvc;
using Services;
using Mongo.Api.Models;

namespace smartapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    public UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<object>>> GetAllCustomers(){
        try
        {
            List<object> users =  await _userService.GetAllUsers();
            if(users!=null){
                return Ok(users);
            }else{
                return NoContent();
            }
        }
        catch (Exception e)
        {
            
            throw new Exception($"Somethiing went wrong trying to Get all Customer on CustomerController. \n\n {e.Message}");
        }
    }

    [HttpPost]
    public async Task CreateCustomer(object user){
        try
        {
            await _userService.CreateUser(user);
        }
        catch (Exception e)
        {
            throw new Exception($"Something wrong ocurred trying to create new Customer on CustomerController \n\n {e.Message}");
        }
    }
}