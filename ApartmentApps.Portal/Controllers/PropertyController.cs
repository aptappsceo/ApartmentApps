using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Entrata.Model.Requests;
using FormFactory.AspMvc.UploadedFiles;
using FormFactory.Attributes;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    [RoutePrefix("Property")]
    [Authorize(Roles = "Admin")]
    public class PropertyController : AAController, ILogger
    {
        public EntrataModule Entrata { get; set; }
        public IUnitImporter Importer { get; set; }

        private ApplicationUserManager _userManager;

        public PropertyController(IKernel kernel, EntrataModule entrata, IUnitImporter importer, PropertyContext context, IUserContext userContext, ApplicationUserManager userManager) : base(kernel, context, userContext)
        {
            Entrata = entrata;
            Importer = importer;
            _userManager = userManager;
        }
       
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: /Properties/
        public ActionResult Index()
        {
            
            var properties = Context.Properties.GetAll();
            return View(properties.ToList());
        }

        public async Task<ActionResult> ImportEntrata(int id)
        {
            //var result = await Entrata.Execute()
            return RedirectToAction("Index");
        }
        // GET: /Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Property property = Context.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

  
        public ActionResult ImportResidentCSV(int propertyId)
        {
            
            return View(new ImportResidentCSVModel() {PropertyId = propertyId});
        }
        [HttpPost]
        public async Task<ActionResult> ImportResidentCSV([FormModel] ImportResidentCSVModel model)
        {

            if (model.File.ContentLength > 0)
            {
                var fullPath = Server.MapPath($"~/App_Data/UploadedFiles/{model.File.Id}/{model.File.FileName}");
                var text = System.IO.File.ReadAllText(fullPath);

                IEnumerable<string> records = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (model.SkipFirstRow)
                    records = records.Skip(1);
                foreach (var record in records)
                {
                    var rc = record.Split(',');

                    var unitRecord = new ExternalUnitImportInfo()
                    {
                        BuildingName = rc[0],
                        UnitNumber = rc[1],
                        IsVacant = rc[2] == "Vacant",
                        FirstName = rc[3],
                        LastName = rc[4],
                        PhoneNumber = rc[5],
                        Email = rc[6],
                    };
                    await Importer.ImportResident(UserManager, Context.Properties.Find(model.PropertyId), unitRecord);
                }

                return RedirectToAction("Index","Units");
            }

            return RedirectToAction("Index");
        }

        // GET: /Properties/Create
        public ActionResult Create()
        {
            ViewBag.CorporationId = new SelectList(Context.Corporations, "Id", "Name");
            return View();
        }

        // POST: /Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,CorporationId")] Data.Property property)
        {
            if (ModelState.IsValid)
            {
                
                Context.Properties.Add(property);
                Context.SaveChanges();
                CurrentUser.PropertyId = property.Id;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CorporationId = new SelectList(Context.Corporations, "Id", "Name", property.CorporationId);
            return View(property);
        }

        // GET: /Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Property property = Context.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.CorporationId = new SelectList(Context.Corporations, "Id", "Name", property.CorporationId);
            return View(property);
        }

        // POST: /Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,CorporationId")] Data.Property property)
        {
            if (ModelState.IsValid)
            {
                var p = Context.Properties.FirstOrDefault(x => x.Id == property.Id);
                p.Name = property.Name;
                p.CorporationId = property.CorporationId;
                //Context.Entry(property);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CorporationId = new SelectList(Context.Corporations, "Id", "Name", property.CorporationId);
            return View(property);
        }

        // GET: /Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Property property = Context.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: /Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Data.Property property = Context.Properties.Find(id);
            Context.Properties.Remove(property);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }


        public void Error(string str, params object[] args)
        {
            
        }

        public void Warning(string str, params object[] args)
        {
            
        }

        public void Info(string str, params object[] args)
        {
            
        }
    }
    public class ImportResidentCSVModel
    {
        [Description("Should the first row be skipped (AKA are the column names in the first row?)")]
        public bool SkipFirstRow { get; set; }
        [Description("The csv file")]
        public UploadedFile File { get; set; }
        [DataType("Hidden")]
        public int PropertyId { get; set; }
    }
}
