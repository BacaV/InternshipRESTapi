﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Datalayer;
using Product.Business.DTO;
using Product.BusinessLayer.Services;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        private readonly IProductService _productService;

        private readonly IValidator<ProductDTO> validator;

        public ProductController(AppDbContext appDbContext, IProductService productService, IValidator<ProductDTO> validator)
        {
            this.appDbContext = appDbContext;
            _productService = productService;
            this.validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductDTO>>> AddProduct(ProductDTO productDTO)
        {
            try
            {
                 _productService.AddProductAsync(productDTO);
                return Ok(productDTO);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id)
;
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("Product not found");
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                 await _productService.UpdateProductAsync(productDTO);
                return Ok();
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProductDTO>>> DeleteProduct(int id)
        {
            if (true) {
                await _productService.DeleteProductAsync(id);
            var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            else {
                return NotFound("Product does not exist!");
            }
        }
    }
}