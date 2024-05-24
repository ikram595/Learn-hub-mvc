﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LearnHubApp.Models; // Assuming BookClient is defined in this namespace

namespace LearnHubApp.Controllers
{
    public class FormationClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllFormations()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7249");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Books/get-all-formations");

            if (response.IsSuccessStatusCode)
            {
                var formations = await response.Content.ReadFromJsonAsync<IEnumerable<FormationClient>>();
                return View(formations);
            }
            else
            {
                return View();
            }
        }
    }
}
