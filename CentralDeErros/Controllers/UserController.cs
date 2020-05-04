﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.DTO;
using CentralDeErros.Models;
using CentralDeErros.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentralDeErros.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userService.ProcurarPorId(id);

            if(user != null)
            {
               var retorno = _mapper.Map<UserDTO>(user);
                /*var retorno = new UserDTO()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    CreatedAt = user.CreatedAt,
                    Name = user.Name
                };*/
                return Ok(retorno);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody]UserDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            /*var user = new User()
            {
                Id = value.Id,
                Login = value.Login,
                Password = value.Password,
                CreatedAt = value.CreatedAt,
                Name = value.Name
            };*/
            var user = _mapper.Map<User>(value);

            var retorno = _userService.Salvar(user);

            return Ok(_mapper.Map<UserDTO>(retorno));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<UserDTO> Put(int id, [FromBody]string value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(value);

            var retorno = _userService.Salvar(user);

            return Ok(_mapper.Map<UserDTO>(retorno));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
