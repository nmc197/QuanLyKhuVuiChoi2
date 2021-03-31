using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QuanLyKhuVuiChoi2.Models;
using QuanLyKhuVuiChoi2.Repository;
using QuanLyKhuVuiChoi2.Util;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyKhuVuiChoi2.Controllers.Core
{
    [Route("[controller]")]
    [ApiController]
    public class KhuTroChoiController : ControllerBase
    {
        IKhuTroChoiRepository repository;
        public KhuTroChoiController(IKhuTroChoiRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        [Route("api/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var dataList = await repository.List();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var reponse = NovaResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(reponse);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/Detail/{Id}")]
        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var dataList = await repository.Detail(Id);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaResponse.SUCCESS(dataList.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("api/Search")]
        public async Task<IActionResult> Search(string keyword)
        {
            try
            {
                var dataList = await repository.Search(keyword);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaResponse.SUCCESS(dataList.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("api/Add")]
        public async Task<IActionResult> Add([FromBody]Khutrochoi model)
        {
            if (ModelState.IsValid)
            {
                //1. business logic

                //data validation
                if (model.TenKhu.Length == 0)
                {
                    return BadRequest();
                }
                //2. add new object
                try
                {
                    var newObj = await repository.Add(model);
                    if (newObj.MaKhu != null)
                    {
                        var novaticResponse = NovaResponse.CREATED(model);
                        return Created("", novaticResponse);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("api/Update")]
        public async Task<IActionResult> Update([FromBody]Khutrochoi model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic 


                    //2. update object
                    await repository.Update(model);

                    var novaticResponse = NovaResponse.SUCCESS(model);
                    return Ok(novaticResponse);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("api/Delete")]
        public async Task<IActionResult> Delete([FromBody]Khutrochoi model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic
                    //set Active to 0

                    //2. logically delete object
                    await repository.Delete(model.MaKhu);

                    var novaticResponse = NovaResponse.SUCCESS(model);
                    return Ok(novaticResponse);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
