using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Modules.Prospect;
using Entrata.Model.Requests;
using Microsoft.AspNet.Identity.Owin;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class ProspectController : AutoGridController<ProspectService, ProspectApplicationBindingModel>
    {
        public ProspectController(IKernel kernel, ProspectService formService, PropertyContext context, IUserContext userContext) : base(kernel, formService, context, userContext)
        {

        }
        public override ActionResult GridResult(GridList<ProspectApplicationBindingModel> grid)
        {
            if (Request != null && Request.IsAjaxRequest())
            {
                return View("OverviewListPartial", grid);
            }
            return base.GridResult(grid);
        }
        public override ActionResult SaveEntry(ProspectApplicationBindingModel model)
        {
            if (string.IsNullOrEmpty(model.Id) || model.Id == "0")
            {
                Service.SubmitApplicant(model);
                return RedirectToAction("Index");
            }
            return base.SaveEntry(model);
        }
    }

    [RoutePrefix("Property")]
    [Authorize(Roles = "Admin")]
    public class PropertyController : AutoGridController<PropertyService, PropertyBindingModel>
    {
        public EntrataModule Entrata { get; set; }
        public IUnitImporter Importer { get; set; }

        private readonly IRepository<Unit> _unitsRepo;
        private ApplicationUserManager _userManager;

        public PropertyController(IRepository<Unit> unitsRepo, IKernel kernel, EntrataModule entrata, IUnitImporter importer, PropertyContext context, IUserContext userContext, ApplicationUserManager userManager, PropertyService propertyService) : base(kernel, propertyService, context, userContext)
        {
            Entrata = entrata;
            Importer = importer;
            _unitsRepo = unitsRepo;
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

        public ActionResult CreateLabelCSV(int propertyId)
        {
            var sb = new StringBuilder();
            var property = Service.Find<PropertyBindingModel>(propertyId.ToString());
            var units = Kernel.Get<BaseRepository<Unit>>().GetAll().Where(x => x.PropertyId == propertyId).ToArray();
            foreach (var unit in units)
            {
                sb.AppendLine($"{unit.Name},{unit.Building.Name}");
            }
            return File(new System.Text.UTF8Encoding().GetBytes(sb.ToString()), "text/csv", $"{property.Name}.csv");
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

    }
    public class ImportResidentCSVModel
    {
        [Description("Should the first row be skipped (AKA are the column names in the first row?)")]
        public bool SkipFirstRow { get; set; }
        [Description("The csv file. Open in notepad and copy and paste the file contents here")]
        [DataType(DataType.MultilineText)]
        public string File { get; set; }
        [DataType("Hidden")]
        public int PropertyId { get; set; }
    }
}
