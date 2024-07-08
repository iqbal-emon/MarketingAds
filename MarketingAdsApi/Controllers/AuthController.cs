﻿using MarketingAds.Data;
using MarketingAds.Models;
using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(AuthService authService,IConfiguration configuration)
        {
            _authService = authService;
            _configuration= configuration;
        }


        [HttpPost("CreateAccount")]
        public async Task CreateAccount(string? email, string? Password)
        {
            User user = new User();
            user.PasswordHash = Password;
            user.Email = email;
            await _authService.CreateAccount(user);

          
        }
        [HttpPost("login")]
       
        public async Task<IActionResult> Login(string? email, string? Password,string? UserRole)
        {
            User user = new();
            user.Email = email;
            user.PasswordHash=Password;
            user.UserRole = UserRole;

            var newUser = await _authService.LogIn(user);
            if (newUser!=null)
            {
                var token = CreateToken(user);
                return Ok(token);
            }
            else
            {
                return BadRequest("Login failed.");
            }
        }

        [HttpGet("Testing")]
        [Authorize(Roles="string")]

        public async Task<IActionResult> Testing()
        {
           
            return Ok("Its Succesful");
        }



        private string CreateToken(User user)
            {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Role,user.UserRole)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddDays(30),
                signingCredentials:creds
                );
            var jwt=new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
            }


    }
}
