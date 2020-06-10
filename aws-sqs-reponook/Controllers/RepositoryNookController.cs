using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using AWSQueueReponook.HelperClasses;
using AWSQueueReponook.Models;
using AWSQueueReponook.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AWSQueueReponook.Controllers
{
    [Route("/")]
    public class AWSQueueReponook : Controller
    {
        // POST (C)reate Repository object - CRUD operation: Create
        [HttpPost("{database}/{collection}")]  
        public async Task<IActionResult> CreateRepositoryObject([FromServices]IRepositoryService repositoryService, string database, string collection, [FromBody] Repository repoObject)
        {
            try
            {
                await repositoryService.Create(database, collection, repoObject);
                return Ok("Created.");
            }
            catch(Exception exc)
            {
                return BadRequest("Create failed." + exc.ToString());
            }

        }
       
        // PUT update Repository object - uses ID in the Repository Object passed
        [HttpPut("{database}/{collection}")]  
        public async Task<IActionResult> UpdateRepositoryObject([FromServices]IRepositoryService repositoryService, string database, string collection, [FromBody]Repository repoObject)
        {
            try
            {
                await repositoryService.Update( database, collection, repoObject);
            }
            catch (Exception exc)
            {
                return BadRequest("Update failed. " + exc.ToString());
            }
            try
            {
                await repositoryService.Update(database, collection, repoObject);

                return Ok( "Updated. ");
            }
            catch (Exception exc)
            {
                return BadRequest("Retreiving Update failed. Record may still have been written. " + exc.ToString());
            }

        }
        // DELETE   by ID passed
        [HttpDelete("{database}/{collection}/{_id}")]    
        public async Task<IActionResult> DeleteRepositoryObject([FromServices]IRepositoryService repositoryService, string database, string collection, string _id, [FromBody]Repository repoObject)
        {
            try
            {
                await repositoryService.Delete(database, collection, _id);

                return Ok($"_id: {_id} deleted.");
            }
            catch (Exception exc)
            {
                return BadRequest( $"Delete failed for _id: {_id}." + exc.ToString());
            }

        }
    }
}
