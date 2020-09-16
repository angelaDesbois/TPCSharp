using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3Chat.Database;
using TP3Chat.Models;

namespace TP3Chat.Controllers
{
    public class ChatController : Controller
    {
      
        // GET: Chat
        public ActionResult Index()
        {
           


            return View(FakeDb.Instance.ListeChat);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {

            return View(FakeDb.Instance.ListeChat.FirstOrDefault(x => x.Id == id));
        }

       

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View(FakeDb.Instance.ListeChat.FirstOrDefault(x => x.Id == id));
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chat = FakeDb.Instance.ListeChat.FirstOrDefault(x => x.Id == id);
                FakeDb.Instance.ListeChat.Remove(chat);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
