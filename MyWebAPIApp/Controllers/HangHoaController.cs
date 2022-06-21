using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> list = new List<HangHoa>();

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(list);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = list.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null)
                {
                    return NotFound(); // Error 404: Not Found.
                }

                return Ok(hanghoa);
            }
            catch(Exception ex)
            {
                return BadRequest(); // Error 400: Bad Request.
            }
        }


        [HttpPost]
        [Route("post")]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa()
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };

            list.Add(hanghoa);
            return Ok(new { 
                Success = true, Data = hanghoa,
            });
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult Edit(string id, HangHoa hangHoa)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = list.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null)
                {
                    return NotFound(); // Error 404: Not Found.
                }

                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest(); // Error 400: Bad Request.
                }

                // Update
                hanghoa.TenHangHoa = hangHoa.TenHangHoa;
                hanghoa.DonGia = hangHoa.DonGia;

                return Ok(); // Status 200: OK
            }
            catch (Exception ex)
            {
                return BadRequest(); // Error 400: Bad Request.
            }
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = list.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null)
                {
                    return NotFound(); // Error 404: Not Found.
                }

                // Remove
                list.Remove(hanghoa);
                return Ok(); // Status 200: OK
            }
            catch (Exception ex)
            {
                return BadRequest(); // Error 400: Bad Request.
            }
        }
    }
}
