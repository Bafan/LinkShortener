using LinkShortener.Engine.DataAccess;
using LinkShortener.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Engine.Database
{
    internal interface ILinksDataAccessService
    {
        Link AddLink(Link link);
        void UpdateShortenLink(int Id, string shortenLink);
        Link GetById(int Id);
    }

    internal class LinksDataAccessService: ILinksDataAccessService
    {
        LinkShortenerContext _context;

        public LinksDataAccessService(LinkShortenerContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        public Link AddLink(Link link)
        {
            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }

        public void UpdateShortenLink(int Id,string shortenLink)
        {
            var link= _context.Links.FirstOrDefault(x => x.ID == Id);

            if (link==null)
                throw new Exception("The given ID is not registered before");

            link.Shorten = shortenLink;

            _context.SaveChanges();
        }

        public Link GetById(int Id)
        {
            return _context.Links.FirstOrDefault(x => x.ID == Id);
        }
    }
}
