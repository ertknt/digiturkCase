﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ertan.Kanter.Repository;
using ErtanKanter.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ErtanKanter.CoreService.Controllers
{
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IDataRepository<Article> _dataRepository;

        public ArticleController(IDataRepository<Article> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/article/list")]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Article> employees = _dataRepository.GetAll();

            return Ok(employees);
        }

        [Route("api/article/getsingle/{id}")]
        public IActionResult Get(long id)
        {
            Article article = _dataRepository.Get(id);

            if (article == null)
            {
                return NotFound("Gelen parametreye ait makale bulunamadı!");
            }

            return Ok(article);
        }

        [Route("api/article/post")]
        [HttpPost]
        public IActionResult Post([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Gelen model boş olduğu için kayıt eklenemedi!");
            }

            int result = _dataRepository.Add(article);

            if (result > 0)
                return Ok("Makale Başarılı Şekilde Eklendi.");
            else
                return BadRequest("Kayıt eklenemedi!");
        }

        [Route("api/article/update/{id}")]
        public IActionResult Put(long id, [FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Gelen model boştur!");
            }

            Article articleToUpdate = _dataRepository.Get(id);
            if (articleToUpdate == null)
            {
                return NotFound("Kayıt Bulunamadı!");
            }

            int result = _dataRepository.Update(articleToUpdate, article);

            if (result > 0)
                return Ok("Makale Başarılı Şekilde Güncellenmiştir.");
            else
                return BadRequest("Kayıt güncellenirken bir hata meydana geldi!");

        }

        [Route("api/article/delete/{id}")]
        public IActionResult Delete(long id)
        {
            Article article = _dataRepository.Get(id);
            if (article == null)
            {
                return NotFound("Kayıt Bulunamadı!");
            }

            int result = _dataRepository.Delete(article);

            if (result > 0)
                return Ok("Kayıt Başarılı Şekilde Silinmiştir.");
            else
                return BadRequest("Kayıt silinirken bir hata meydana geldi!");


        }

        [Route("api/article/search/{data}")]
        public IActionResult Search(string data)
        {
            var article = _dataRepository.GetAll().Where(x => x.Subject.ToLower().Trim().Contains(data.ToLower().Trim()) || x.Content.ToLower().Trim().Contains(data.ToLower().Trim())).ToList();

            if (article.Count == 0)
            {
                return NotFound("Gelen parametreye ait makaleler bulunamadı!");
            }

            return Ok(article);
        }
    }
}