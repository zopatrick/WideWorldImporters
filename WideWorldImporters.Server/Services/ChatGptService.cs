using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WideWorldImporters.Server.Manager;
using WideWorldImporters.Server.Models;

namespace WideWorldImporters.Server.Services
{

    [ApiController]
    [Route("api/[controller]")]
    public class ChatGptController
    {
        private readonly ApplicationDbContext _context;
        public ChatGptController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        [HttpGet("{userInput}")]
        public async Task<string> GetChatGPTResponse(string userInput)
        {
            var chat = new ChatGptManager();
            string response = await chat.GetChatGPTResponse(userInput);
            Console.WriteLine(response);
            return response;
        }
    }
}
