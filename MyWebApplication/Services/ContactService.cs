using MyWebApplication.DAL;
using MyWebApplication.Models;
using MyWebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Services
{
    public class ContactService : IContactService
    {
        private IDBRepository<Contact> repoContact;

        public ContactService(IDBRepository<Contact> repoContact)
        {
            this.repoContact = repoContact;
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                contacts = repoContact.GetAll().ToList();
            }
            catch (Exception)
            {

            }
            return contacts;
        }
        public Contact GetContact(int ID)
        {
            Contact contact = new Contact();
            try
            {
                contact = repoContact.Get(ID);
            }
            catch (Exception)
            {

            }
            return contact;
        }

        public int CreateContact(ContactVM viewmodel)
        {
            try
            {
                Contact dbmodel = new Contact();
                AssignDBModel(viewmodel, dbmodel);
                return repoContact.Add(dbmodel);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool EditContact(ContactVM viewmodel)
        {
            try
            {
                Contact dbmodel = new Contact();
                AssignDBModel(viewmodel, dbmodel);
                return repoContact.Update(dbmodel, dbmodel.ID);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void AssignDBModel(ContactVM viewmodel, Contact dbmodel)
        {
            dbmodel.Name = viewmodel.Name;
            dbmodel.Address = viewmodel.Address;
            dbmodel.Phone = viewmodel.Phone;
            dbmodel.Email = viewmodel.Email;
        }
    }
}