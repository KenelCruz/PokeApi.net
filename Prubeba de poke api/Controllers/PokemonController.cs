using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prubeba_de_poke_api.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prubeba_de_poke_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        // GET: api/<PokemonController>
        [HttpGet]
        public async Task<ActionResult> GetPokemones()
        {
            List<Root> pokeinfo = new List<Root>();
            using (var poke = new HttpClient())
            {
                poke.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                poke.DefaultRequestHeaders.Accept.Clear();
                poke.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                
                var res = await poke.GetAsync("pokemon?limit=99");
                var pokereponse = res.Content.ReadAsStringAsync().Result;
                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine(pokereponse);
                    

                    
                }
                return Ok(pokereponse);


            }

        }

        // GET api/<PokemonController>/5
        [HttpGet("{nombre}")]
        public async Task<ActionResult> GetPokemon(string nombre)
        {
            List<Root> pokeinfo = new List<Root>();
            using (var poke = new HttpClient())
            {
                poke.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                poke.DefaultRequestHeaders.Accept.Clear();
                poke.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                var res = await poke.GetAsync("pokemon/" + nombre);
                var pokereponse = res.Content.ReadAsStringAsync().Result;

                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine(res);
                   
                    
                    
                }
                return Ok(pokereponse);


            }

        }

       
    }
}
