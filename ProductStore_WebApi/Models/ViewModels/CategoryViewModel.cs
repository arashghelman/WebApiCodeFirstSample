using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Newtonsoft.Json;

namespace ProductStore_WebApi.Models.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Ref_CategoryRepository = new DomainModels.POCO.CategoryRepository();
        }

        #region [- class props -]
        [JsonIgnore]
        public DomainModels.POCO.CategoryRepository Ref_CategoryRepository { get; set; }
        [JsonIgnore]
        public DomainModels.DTO.EF.Category Ref_Category { get; set; } 
        #endregion

        #region [- models props -]
        public int Id { get; set; }
        public string Name { get; set; } 
        #endregion

        #region [- Show() -]
        public async Task<List<CategoryViewModel>> Show()
        {
            var categoryList = await Ref_CategoryRepository.Select();
            var categoryViewModelList = categoryList.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.CategoryName
            }).ToList();

            return categoryViewModelList;
        }
        #endregion

        #region [- Select() -]
        public async Task<List<DomainModels.DTO.EF.Category>> Select()
        {
            var categoryList = await Ref_CategoryRepository.Select();
            return categoryList;
        }
        #endregion

        #region [- Save(CategoryViewModel ref_CategoryViewModel) -]
        public async Task Save(CategoryViewModel ref_CategoryViewModel)
        {
            Ref_Category = new DomainModels.DTO.EF.Category()
            {
                CategoryName = ref_CategoryViewModel.Name
            };

            await Ref_CategoryRepository.Insert(Ref_Category);
        }
        #endregion

        #region [- Remove(CategoryViewModel ref_CategoryViewModel) -]
        public async Task Remove(CategoryViewModel ref_CategoryViewModel)
        {
            var categoryId = ref_CategoryViewModel.Id;
            await Ref_CategoryRepository.Delete(categoryId);
        }
        #endregion

        #region [- Edit(CategoryViewModel ref_CategoryViewModel) -]
        public async Task Edit(CategoryViewModel ref_CategoryViewModel)
        {
            Ref_Category = new DomainModels.DTO.EF.Category()
            {
                Id = ref_CategoryViewModel.Id,
                CategoryName = ref_CategoryViewModel.Name
            };
            await Ref_CategoryRepository.Update(Ref_Category);
        } 
        #endregion

    }
}