using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class PropertyManager : IPropertyService
    {
        private IPropertyDal _propertyDal;

        public PropertyManager(IPropertyDal propertyDal)
        {
            _propertyDal = propertyDal;
        }

        public void Add(Property property)
        {
            _propertyDal.Add(property);
        }

        public void Update(Property property)
        {
            _propertyDal.Update(property);
        }

        public void Delete(Property property)
        {
            _propertyDal.Delete(property);
        }

        public List<PropertyJoin> GetAll()
        {
            return _propertyDal.GetAllJoin();
        }

        public List<Property> GetAll_GroupId(int groupId)
        {
            return _propertyDal.GetList(x => x.PropertyGroupId == groupId);
        }

        public Property GetById(int id)
        {
            return _propertyDal.Get(x => x.Id == id);
        }
    }
}
