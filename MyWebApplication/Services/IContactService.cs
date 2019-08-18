using MyWebApplication.Models;
using MyWebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Services
{
    public interface IContactService
    {
        List<Contact> GetContacts();
        Contact GetContact(int ID);
        int CreateContact(ContactVM contact);
        bool EditContact(ContactVM contact);


    }
}
