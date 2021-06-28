using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingTracking.Controllers
{
    public class BaseController: Controller
    {
        private readonly HttpContext _context;

        protected BaseController()
        {
            _context = new DefaultHttpContext();
        }

        public int GetUserId()
        {
            return int.Parse(_context.User.Claims
                .First(i => i.Type == ClaimTypes.Sid).Value);
        }
    }
}