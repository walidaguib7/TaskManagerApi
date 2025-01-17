﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Dtos.Category;
using TasksApi.Mappers;
using TasksApi.Services;
using TasksApi.Filters;
using FluentValidation;
using TasksApi.Helpers;

namespace TasksApi.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoryController(ICategory _categoryService) : ControllerBase
    {
        private readonly ICategory categoryService = _categoryService;

        [HttpGet]
        [MyLogging("All categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAllCategories();
            return Ok(categories);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await categoryService.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = dto.ToCategory();
            try
            {

            }
            catch (ValidationException e)
            {
                return BadRequest(new ValidationErrorResponse { Errors = e.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception e) {
                return StatusCode(500, "An error occurred");
            }
            var categoryModel = await categoryService.CreateCategory(category);
            return Ok(categoryModel);
        }

        [HttpPut]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto dto , [FromRoute] int categoryId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = await categoryService.UpdateCategory(categoryId, dto);
            try
            {
                if (category == null) return NotFound();
                return StatusCode(201, "Updated Successfully");
            }
            catch(ValidationException e)
            {
                return BadRequest(new ValidationErrorResponse { Errors = e.Errors.Select(e => e.ErrorMessage) });
            }catch(Exception e)
            {
                return StatusCode(500, "An error occurred");
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var category = await categoryService.DeleteCategory(id);
            if (category == null) return NotFound();
            return Ok("Category deleted!");
        }

    }
}
