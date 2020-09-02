using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductStore_WebApi.Models.DomainModels.POCO
{
    public class CategoryRepository
    {
        #region [- ctor -]
        public CategoryRepository()
        {

        }
        #endregion

        #region [- Select() -]
        public async Task<List<DTO.EF.Category>> Select()
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    var categoryList = await context.Categories.ToListAsync();
                    return categoryList;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Insert(Category ref_Category) -]
        public async Task Insert(DTO.EF.Category ref_Category)
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    context.Categories.Add(ref_Category);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Delete(int id) -]
        public async Task Delete(int id)
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    var category = new DTO.EF.Category() { Id = id };
                    context.Entry(category).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Update(Category ref_Category) -]
        public async Task Update(DTO.EF.Category ref_Category)
        {
            using (var context = new DTO.EF.ProductStoreEntities())
            {
                try
                {
                    context.Entry(ref_Category).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        } 
        #endregion
    }
}