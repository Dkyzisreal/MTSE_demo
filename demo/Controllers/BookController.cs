using demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    public class BooksController : Controller
    {
        private BookDAL bookDAL;
        public BooksController()
        {
            bookDAL = new BookDAL();
        }
        public ActionResult Edit(int id)
        {
            Book book = bookDAL.GetBookById(id);

            if (book == null)
            {
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                bookDAL.UpdateBook(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Route("/")]
        public ActionResult Index()
        {
            var books = bookDAL.GetAllBooks();
            return View(books);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                bookDAL.CreateBook(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            Book book = bookDAL.GetBookById(id);

            if (book == null)
            {
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bookDAL.DeleteBook(id);

            return RedirectToAction("Index");
        }
    }
}
