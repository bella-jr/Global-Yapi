using KZ.Entity.Models.Data;
using System.Collections.Generic;

namespace KZ.Business.Abstract
{
    public interface IReferenceService
    {
        void Add(Reference reference);
        void Update(Reference reference);
        void Delete(Reference reference);
        Reference GetById(int id);
        List<Reference> GetAll(byte languageId, bool isDefault = false);

        List<Reference> GetAll_UI(byte languageId, byte typeId);
    }
}
