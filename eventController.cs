using practical1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practical1.Controllers
{
    public class eventController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: event

        public ActionResult Search(string searchby, string search)
        {

            // return View(db.event1s.Where(x => x.title.StartsWith(search) || search == null).ToList());
            return View();
        }


        public ActionResult Index()
        {
            IList<eventmodel> list = new List<eventmodel>();
            var query = from qrs in db.event1s select qrs;

            var listdata = query.ToList();

            foreach (var userdata in listdata)
            {
                list.Add(new eventmodel()
                {
                    eventcode = userdata.eventcode,
                    title=userdata.title,
                    typeofevent=userdata.typeofevent,
                    estimatecost= (int)userdata.estimatecost,
                    actualcost= (int)userdata.actualcost,
                    dateofevent= (DateTime)userdata.dateofevent
                   
                });
            }
            return View(list);
        }

       

        // GET: event/Details/5
        public ActionResult Details(int id)
        {
            eventmodel model = db.event1s.Where(val => val.eventcode == id).
               Select(val => new eventmodel()
               {
                   eventcode = val.eventcode,
                   title = val.title,
                   typeofevent = val.typeofevent,
                   estimatecost = (int)val.estimatecost,
                  actualcost = (int)val.actualcost,
                   dateofevent = (DateTime)val.dateofevent


               }).SingleOrDefault();
            return View(model);
        }

        // GET: event/Create
        public ActionResult Create()
        {

            eventmodel e = new eventmodel();
            return View(e);
        }

        // POST: event/Create
        [HttpPost]
        public ActionResult Create(eventmodel model)
        {
            event1 e = new event1();
            e.title = model.title;
            e.typeofevent = model.typeofevent;
            e.estimatecost = model.estimatecost;
            e.actualcost = model.actualcost;
            e.dateofevent = model.dateofevent;

            db.event1s.InsertOnSubmit(e);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }

        // GET: event/Edit/5
        public ActionResult Edit(int id)
        {
            eventmodel model = db.event1s.Where(val => val.eventcode == id).
               Select(val => new eventmodel()
               {
                 
                   eventcode = val.eventcode,
                   title = val.title,
                   typeofevent = val.typeofevent,
                   estimatecost = (int)val.estimatecost,
                   actualcost = (int)val.actualcost,
                   dateofevent = (DateTime)val.dateofevent

               }).SingleOrDefault();
            return View(model);
        }

        // POST: event/Edit/5
        [HttpPost]
        public ActionResult Edit(eventmodel model)
        {
            event1 em= db.event1s.Where(val => val.eventcode == model.eventcode).
                    Single<event1>();
            em.eventcode = model.eventcode;
            em.title = model.title;
            em.typeofevent = model.typeofevent;
            em.estimatecost = model.estimatecost;
            em.actualcost = model.actualcost;
            em.dateofevent = model.dateofevent;

            db.SubmitChanges();

            return RedirectToAction("Index");
        }

        // GET: event/Delete/5
        public ActionResult Delete(int id)
        {
            event1 tbl = new event1();
            tbl = db.event1s.Where(var => var.eventcode == id).FirstOrDefault();
            db.event1s.DeleteOnSubmit(tbl);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }

        // POST: event/Delete/5
        [HttpPost]
        public ActionResult Delete(eventmodel model)
        {
            // TODO: Add delete logic here

                return RedirectToAction("Index");
            }

      
    }
}
