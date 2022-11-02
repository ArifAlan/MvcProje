using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll(string parametre);
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingId(int id);
        Content GetById(int id);
         void Add(Content content);
        void Update(Content content);
        void Delete(Content content);

    }
}
