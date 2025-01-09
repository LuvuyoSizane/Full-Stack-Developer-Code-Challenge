using System.Net;
using AutoMapper;
using FullStackChallengeAPI.Data.DTO;
using FullStackChallengeAPI.Data.Interfaces;
using FullStackChallengeAPI.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FullStackChallengeAPI.Controller;


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository<User> _userRepository;
        

        public UserController(IUserRepository<User>  userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                
                if (user == null)
                {
                    return BadRequest(new {message="No data has been sent."});
                }

                try
                {
                    await _userRepository.RegisterAsync(user);
                    return Ok(new { message = "User Successfully Registered" });

                }
                catch (Exception ex)
                {
                    return (StatusCode(500, new { error = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(HttpStatusCode.BadRequest.ToString(), ex);
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            try
            {
                // Check if the login request is null
                if (loginRequest == null)
                {
                    return BadRequest(new { message = "No login data has been sent" });
                }

                // Validate login request (ensure the fields are populated)
                if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    return BadRequest(new { message = "Email and password are required" });
                }

                // Attempt to authenticate the user
                var loginResponse = await _userRepository.LoginAsync(loginRequest);

                // Return JWT token and user details if authentication is successful
                return Ok(new
                {
                    message = "Login successful",
                    data = loginResponse
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle invalid login (wrong email or password)
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle  other types of errors (database, service issues, etc.)
                return StatusCode(500, new { error = ex.Message });
            }
        }

    }

