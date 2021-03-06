using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Data;
using MyWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHangHoasController : ControllerBase
    {
        public readonly MyDBContext context;

        public LoaiHangHoasController(MyDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var dsloai = context.LoaiHangHoas.ToList();
                return Ok(dsloai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var loai = context.LoaiHangHoas.SingleOrDefault(x => x.MaLoai == id);

            if(loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public IActionResult Create(LoaiHangHoaModel loaiHangHoa)
        {
            try
            {
                var loai = new LoaiHangHoa();
                loai.TenLoai = loaiHangHoa.TenLoai;
                context.Add(loai);
                context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, LoaiHangHoaModel model)
        {
            var loai = context.LoaiHangHoas.SingleOrDefault(x => x.MaLoai == id);

            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var loai = context.LoaiHangHoas.SingleOrDefault(x => x.MaLoai == id);

            if (loai != null)
            {
                context.LoaiHangHoas.Remove(loai);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
