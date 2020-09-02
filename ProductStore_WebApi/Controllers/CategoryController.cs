using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductStore_WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        public CategoryController()
        {
            Ref_CategoryViewModel = new Models.ViewModels.CategoryViewModel();
        }
        public Models.ViewModels.CategoryViewModel Ref_CategoryViewModel { get; set; }

        #region [- GetCategory() -]
        [Route("wapi/v1/Category/Get")]
        public async Task<IHttpActionResult> GetCategory()
        {
            var categoryList = await Ref_CategoryViewModel.Show();
            return Ok(new { categoryList });
        } 
        #endregion

        #region [- PostCategory(JObject jObject) -]
        [Route("wapi/v1/Category/Post")]
        public async Task<IHttpActionResult> PostCategory([FromBody] JObject jObject)
        {
            if (ModelState.IsValid)
            {
                var category = jObject["category"].ToObject<Models.ViewModels.CategoryViewModel>();
                await Ref_CategoryViewModel.Save(category);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion

        #region [- DeleteCategory(JObject jObject) -]
        [Route("wapi/v1/Category/Delete")]
        public async Task<IHttpActionResult> DeleteCategory([FromBody] JObject jObject)
        {
            if (ModelState.IsValid)
            {
                var category = jObject["category"].ToObject<Models.ViewModels.CategoryViewModel>();
                await Ref_CategoryViewModel.Remove(category);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        #endregion

        #region [- PutCategory(JObject jObject) -]
        [Route("wapi/v1/Category/Put")]
        public async Task<IHttpActionResult> PutCategory([FromBody] JObject jObject)
        {
            if (ModelState.IsValid)
            {
                var category = jObject["category"].ToObject<Models.ViewModels.CategoryViewModel>();
                await Ref_CategoryViewModel.Edit(category);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        } 
        #endregion
    }
}
