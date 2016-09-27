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
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    [RoutePrefix("Property")]
    [Authorize(Roles = "Admin")]
    public class PropertyController : AutoGridController<PropertyService, PropertyBindingModel>
    {
        public EntrataModule Entrata { get; set; }
        public IUnitImporter Importer { get; set; }

        private ApplicationUserManager _userManager;

        public PropertyController(IKernel kernel, EntrataModule entrata, IUnitImporter importer, PropertyContext context, IUserContext userContext, ApplicationUserManager userManager, PropertyService propertyService) : base(kernel, propertyService, context, userContext)
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

        public ActionResult ImportResidentCSV(int propertyId)
        {

            return AutoForm(new ImportResidentCSVModel() { PropertyId = propertyId }, "ImportResidentCSV", "Import CSV");
        }

        [HttpPost]
        public async Task<ActionResult> ImportResidentCSV(ImportResidentCSVModel model)
        {
            var text = model.File;

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

            return RedirectToAction("Index", "Units");

        }



        // GET: /Properties/Create

    }
    public class ImportResidentCSVModel
    {
        [Description("Should the first row be skipped (AKA are the column names in the first row?)")]
        public bool SkipFirstRow { get; set; }
        [Description("The csv file. Open in notepad and copy and paste the file contents here")]
        public string File { get; set; }
        [DataType("Hidden")]
        public int PropertyId { get; set; }
    }
}
