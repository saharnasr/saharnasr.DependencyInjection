using MVCUnityIOCDemo.DomainModels;
using MVCUnityIOCDemo.Interfaces;
using System.Web.Mvc;

namespace MVCUnityIOCDemo.Controllers
{
    public class ProductController : Controller
    {
        private  IProductRepository repository;

        //inject dependency
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var data = repository.GetAll();
            return View(data);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Add(product);

                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Edit(int Id)
        {
            var data = repository.Get(Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Update(product);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var product = repository.Get(Id);
            return View(product);
        }

        public ActionResult Delete(int Id)
        {
            var product = repository.Get(Id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var product = repository.Get(Id);
            repository.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}