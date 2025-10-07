using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace KZ.Business.Concrete
{
    public class ReferenceManager : IReferenceService
    {
        private IReferenceDal _referenceDal;

        public ReferenceManager(IReferenceDal referenceDal)
        {
            _referenceDal = referenceDal;
        }

        public void Add(Reference reference)
        {
            _referenceDal.Add(reference);
        }

        public void Update(Reference reference)
        {
            _referenceDal.Update(reference);
        }

        public void Delete(Reference reference)
        {
            _referenceDal.Delete(reference);
        }

        public Reference GetById(int id)
        {
            return _referenceDal.Get(x => x.Id == id);
        }

        public List<Reference> GetAll(byte languageId, bool isDefault = false)
        {
            var data = _referenceDal.GetList(x => x.LanguageId == languageId).OrderBy(x => x.SequenceNumber).ToList();

            if (isDefault)
                data.Insert(0, new Reference() { Id = 0, Title = "- Seçim Yapınız -" });

            return data;
        }

        public List<Reference> GetAll_UI(byte languageId, byte typeId)
        {
            return _referenceDal.GetList(x => x.IsStatus && x.LanguageId == languageId && x.TypeId == typeId).OrderBy(x => x.SequenceNumber).ToList();
        }
    }
}
