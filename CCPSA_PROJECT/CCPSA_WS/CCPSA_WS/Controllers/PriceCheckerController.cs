using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CCPSA_WS.Context;
using CCPSA_WS.ModelsContext;
using Microsoft.Extensions.Configuration;
using CCPSA_WS.Models;
using System.Net;


namespace CCPSA_WS.Controllers
{
    [Route("api/PriceChecker")]
    public class PriceCheckerController : Controller
    {
        readonly CCPSAContext CcpsaContext;
        IConfiguration configuration;

        public PriceCheckerController(IConfiguration configuration_)
        {
            this.configuration = configuration_;
            this.CcpsaContext = new CCPSAContext(configuration_);
        }

        [HttpGet("echo")]
        public Response echo()
        {
            Response response = new Response();
            response.httpResponseStatusCode = HttpContext.Response.StatusCode;
            response.success = this.CcpsaContext.Database.CanConnect();
            response.data = null;
            response.message = "CS=" + Environment.GetEnvironmentVariable("CONECTION_STRING")?.ToString();
            return response;
        }

        [HttpGet("GetProducto/{codigo}")]
        public Response GetProducto(string codigo)
        {
            Response response = new Response();
            try
            {
                var producto = this.CcpsaContext.Productos.FirstOrDefault<Producto>((Producto producto) => producto.Codigo == codigo);
                if (producto == null)
                {

                    response.httpResponseStatusCode = HttpContext.Response.StatusCode;
                    response.success = true;
                    response.data = null;
                }
                else
                {
                    //HttpStatusCode(StatusCode) 
                    response.httpResponseStatusCode = HttpContext.Response.StatusCode;
                    response.success = true;
                    response.data = producto;
                }
            }
            catch (Exception e)
            {
                response.httpResponseStatusCode = HttpContext.Response.StatusCode;
                response.success = false;
                response.data = null;
                response.message = e.Message;
            }
            return response;
        }

        [HttpGet("GetAllPublicityBanners")]
        public Response GetAllPublicityBanners()
        {
            Response response = new Response();
            try
            {
                var bannerList = this.CcpsaContext.Banners.ToArray<Banner>().Where<Banner>((banner) => { return (banner.AnchoImagen <= 464 && banner.AltoImagen <= 200); });

                if (bannerList == null)
                {

                    response.httpResponseStatusCode = HttpContext.Response.StatusCode;
                    response.success = true;
                    response.data = null;
                    response.message = "No se encontraron imagenes o estas superan las dimensiones establecidas!";
                }
                else
                {
                    //HttpStatusCode(StatusCode) 
                    response.httpResponseStatusCode = HttpContext.Response.StatusCode;
                    response.success = true;
                    response.data = bannerList;
                }
            }
            catch (Exception e)
            {
                response.httpResponseStatusCode = HttpContext.Response.StatusCode;
                response.success = false;
                response.data = null;
                response.message = e.Message;
            }
            return response;
        }

    }
}

