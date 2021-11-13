using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("/api/gwp/avg")]
    public class ServerController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("countrygwp")]
        public async Task<IActionResult> CountryGwp(IFormCollection form)
        {
            
            string country = form["country"];
            string lob = form["lob"];
            var _lob = new HashSet<String>(lob.Split(','));

            StreamReader sr = new StreamReader("data/gwpByCountry.csv");//Give the correct path where the file is present.
            sr.ReadLine();

            string output = "{";
            bool flag = false;

            while (!sr.EndOfStream)
            {
                var feild = sr.ReadLine().Split(',');
                double avg = 0;
                int c = 0;
                if (feild[0] == country && _lob.Contains(feild[3]))
                {
                    for (int i = 12; i < 20; i++)
                    {
                        try
                        {
                            avg += Double.Parse(feild[i]);
                            c++;
                        }
                        catch (Exception exc)
                        {

                        }
                    }
                    output += (flag ? "," : "") + "\"" + feild[3] + "\":" + avg / c;
                    flag = true;
                }
            }
            output += "}";
            sr.Close();
            Console.Write("Output:" + output);
            return Ok(output);
        }
    }
}
