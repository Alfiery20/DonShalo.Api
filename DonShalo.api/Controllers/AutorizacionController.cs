﻿using DonShalo.api.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class AutorizacionController : AbstractController
    {
        [HttpPost]
        [Authorize]
        [Route("UserInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UserInfoContr()
        {
            return Ok(CurrentUser);
        }
    }
}
