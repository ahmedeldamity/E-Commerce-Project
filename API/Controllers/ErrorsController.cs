using API.Errors;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace API.Controllers
{
    public class ErrorsController : BaseApiController
    {
        private readonly StoreContext _storeContext;

        public ErrorsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        [HttpGet("notfound")]
        public ActionResult<Product> GetNotFound() // not found product
        {
            var product = _storeContext.Products.Find(100);
            if(product == null) 
                return NotFound(new ApiResponse(404));
            return Ok(product);
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest() // bad request -> Client\Front-end Send Some Thing Wrong
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("unauthorize")] // when we need to return Unauthorized
        public ActionResult GetUnanouthorizeError(int id)
        {
            return Unauthorized(new ApiResponse(401));
        }

        [HttpGet("badrequest/{id}")] // bad request -> validation error, because id is int and i send string 
        public ActionResult GetBadRequest(int id)
        {
            return Ok(new ApiResponse(400));
        }

        [HttpGet("servererror")] // server error = exception [null reference exception]
        public ActionResult GetServerError()
        {
            var product = _storeContext.Products.Find(100);
            var productToReturn = product.ToString();
            return Ok(productToReturn);
        }

        // Error Not Fount End Point
        // we use it when (Client access end point not exist | this end point must access it using token)



        // ** Errors is:
        // --- Not Found Some Thing In Data Base So We Return NotFound()
        // --- Bad Request When FrontEnd/Client Send Some Thing Wrong So We Return BadRequest()
        // --- Unauthorized When Client Want To Enter Some Where Not Allowed For You So We Return Unauthorized()
        // .... This three errors we can handling with object from class we made (ApiResponse) and this class must have two parameters
        // .... 1.Satus Code 2.Message
        // --- Validation Error: Is Type Of Bad Request Errors 
        // .... we made it in this way: 
        // .... In this error we need return to Frontend object from three parameters
        // .... 1.Satus Code 2.Message 3.Errors
        // .... 1 and 2 : inherit it from class ApiResponse
        // .... 3       : we bring this errors from program class
        // --- Server Error 
        // .... We Create Middleware (ExceptionMiddleware) Then Use It In Program Class
        // --- Not Fount End Point | access authorized end poind without token
        // .... We Need When This Error Happen: We Send Object From ApiResponse(404)
        // .... To Make It: We Need Some Steps
        // .... 1. Create New Controller (ErrorController) And Make End Point In It 
        // .... 2. Write (app.UseStatusCodePagesWithReExecute("/Errors/{0}");) in program class So When Not Found End Point Error Happen Will Redirect To This End Point
    }
}