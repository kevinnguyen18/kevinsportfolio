using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using formExample.Models;

namespace formExample.Controllers
{
    public class HomeController : Controller
    {
        public WordsModel _dictionaryModel = new WordsModel();


        [HttpGet]
        public ActionResult Index()
        {

            //_dictionaryModel.ReadFile(@"\files\DictionaryWords.html");
            _dictionaryModel.ArrayListOfSpecificWords = null;
            return View(_dictionaryModel);
            
        }

        [HttpPost]
        public ActionResult Index(String letters)
        {
            int numberOfCharacters = letters.Length;
            _dictionaryModel.ReadFile(@"\files\DictionaryWords.html", letters);
            _dictionaryModel.ArrayListOfSpecificWords = _dictionaryModel.matchingWordsArray;


            //return View(_dictionaryModel);
            return View(_dictionaryModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

    }
}