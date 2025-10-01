using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IPropertyGroupService
    {
        void Add(PropertyGroup propertyGroup);
        void Update(PropertyGroup propertyGroup);
        void Delete(PropertyGroup propertyGroup);
        List<PropertyGroup> GetAll(byte languageId);
        List<PropertyGroup> GetAll_UIControl(byte languageId, string text = "- Seçim Yapınız -");

        PropertyGroup GetById(int id);
    }
}
