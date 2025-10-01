using System.Collections.Generic;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IPropertyService
    {
        void Add(Property property);
        void Update(Property property);
        void Delete(Property property);
        List<PropertyJoin> GetAll();
        List<Property> GetAll_GroupId(int groupId);
        Property GetById(int id);
    }
}
