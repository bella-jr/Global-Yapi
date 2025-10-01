using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class PropertyGroupManager : IPropertyGroupService
    {
        private IPropertyGroupDal _propertyGroupDal;

        public PropertyGroupManager(IPropertyGroupDal propertyGroupDal)
        {
            _propertyGroupDal = propertyGroupDal;
        }

        public void Add(PropertyGroup propertyGroup)
        {
            _propertyGroupDal.Add(propertyGroup);
        }

        public void Update(PropertyGroup propertyGroup)
        {
            _propertyGroupDal.Update(propertyGroup);
        }

        public void Delete(PropertyGroup propertyGroup)
        {
            _propertyGroupDal.Delete(propertyGroup);
        }

        public List<PropertyGroup> GetAll(byte languageId)
        {
            return _propertyGroupDal.GetList(x => x.LanguageId == languageId);
        }

        public List<PropertyGroup> GetAll_UIControl(byte languageId, string text = "- Seçim Yapınız -")
        {
            var propertyGroup = _propertyGroupDal.GetList(x => x.LanguageId == languageId);

            propertyGroup.Insert(0, new PropertyGroup { Id = 0, Name = text });

            return propertyGroup;
        }

        public PropertyGroup GetById(int id)
        {
            return _propertyGroupDal.Get(x => x.Id == id);
        }
    }
}
