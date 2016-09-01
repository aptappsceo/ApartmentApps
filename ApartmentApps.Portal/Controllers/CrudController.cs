using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Newtonsoft.Json;
using Ninject;
using Syncfusion.EJ.Export;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.JavaScript.Models;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using PageSettings = Syncfusion.JavaScript.Models.PageSettings;

namespace ApartmentApps.Portal.Controllers
{

    public class CrudController<TViewModel, TModel> : AAController where TModel : IBaseEntity, new() where TViewModel : BaseViewModel, new()
    {
      //  public IRepository<TModel> Repository { get; set; }
        public StandardCrudService<TModel, TViewModel> Service { get; set; }

        public CrudController(IKernel kernel, IRepository<TModel> repository, StandardCrudService<TModel, TViewModel> service, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            //Repository = repository;
            Service = service;
        }

        public ActionResult Insert(TViewModel value)
        {
            if (ModelState.IsValid)
            {
                Service.Save(value);
            }


            return RedirectToAction("Index");
        }
        public ActionResult Update(TViewModel value)
        {
            if (ModelState.IsValid)
            {
                Service.Save(value);
            }
            return RedirectToAction("Index");
        }
        [ValidateInput(false)]
        public ActionResult ExportToExcel(string GridModel)
        {
            ExcelExport exp = new ExcelExport();
            Dm.Skip = 0;
            Dm.Take = 0;
            int count;
            var Data = GetData(Dm, out count);
            //var DataSource = Service.GetAll().OrderBy(p => p.Id);
            GridProperties properties = ConvertGridObject(GridModel);
            //var ds = properties.DataSource;
            //DataManager manager = new DataManager()
            //{
            //    Where =properties.FilterSettings.
            //};

            properties.AllowPaging = false;
            properties.PageSettings.PageSize = Int32.MaxValue;

            exp.Export(properties, Data, $"{ ExportFileName}.xlsx", ExcelVersion.Excel2010);
            return RedirectToAction("Index");
        }
        private GridProperties ConvertGridObject(string gridProperty)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IEnumerable div = (IEnumerable)serializer.Deserialize(gridProperty, typeof(IEnumerable));
            GridProperties gridProp = new GridProperties();
            foreach (KeyValuePair<string, object> ds in div)
            {
                var property = gridProp.GetType()
                    .GetProperty(ds.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (property != null)
                {
                    Type type = property.PropertyType;
                    string serialize = serializer.Serialize(ds.Value);
                    object value = serializer.Deserialize(serialize, type);
                    property.SetValue(gridProp, value, null);
                }
                if (ds.Key == "dataSource")
                {
                    //Deserialize the value to DataManager type.
                    GridDataManager = (DataManager)serializer.Deserialize(serializer.Serialize(ds.Value), typeof(DataManager));
                    continue;
                }
            }
            return gridProp;
        }

        public DataManager GridDataManager { get; set; }

        private object DeserializeToModel(Type type, string gridModel)
        {
           return JsonConvert.DeserializeObject(gridModel, type,new JsonSerializerSettings()
           {
               
           });
        }
        //[ValidateInput(false)]
        //public void ExportToWord(string GridModel)
        //{
        //    WordExport exp = new WordExport();
      
        //    var DataSource = Service.GetAll().OrderBy(p => p.Id);
        //    GridProperties properties = ConvertGridObject(GridModel);
        //    properties.AllowPaging = false;
        //    properties.PageSettings.PageSize = Int32.MaxValue;
        //    var dataSource = new DataOperations().Execute(DataSource, properties,true);
        //    exp.Export(properties, dataSource, "Export.docx");
        //}
        [ValidateInput(false)]
        public void ExportToPdf(string GridModel)
        {
            PdfExport exp = new PdfExport();
            var doc = new PdfDocument();
            doc.PageSettings.Orientation = PdfPageOrientation.Landscape;

            doc.DocumentInformation.Title = ExportHeader;
            doc.DocumentInformation.Author = "Apartment Apps: " + Property.Name;
            doc.DocumentInformation.CreationDate = Property.TimeZone.Now();
            doc.DocumentInformation.Creator = "Apartment Apps Portal";

            Dm.Skip = 0;
            Dm.Take = 0;
            int count;
            var Data = GetData(Dm, out count);
            //var DataSource = Service.GetAll().OrderBy(p => p.Id);
            GridProperties properties = ConvertGridObject(GridModel);


            //properties.AllowTextWrap = true;


            //properties.ColumnLayout = ColumnLayout.Fixed;

            var commentsField = properties.Columns.FirstOrDefault(c=>c.Field == "Comments");
            if (commentsField != null)
            {
                properties.Columns.Remove(commentsField);
                //commentsField. 
            }


            //var ds = properties.DataSource;
            //DataManager manager = new DataManager()
            //{
            //    Where =properties.FilterSettings.
            //};

            //properties.AllowPaging = false;

            doc.PageSettings.Size = PdfPageSize.A4;

            //var dataSource = new DataOperations().Execute(DataSource.ToArray(), properties,true);
            exp.Export(properties, Data, $"{ExportFileName}.pdf",false,false,"flat-saffron",true,false,doc,ExportHeader,false);
        }

        public virtual string ExportFileName
        {
            get { return "Export"; }
        }

        public virtual string ExportHeader
        {
            get { return ""; }
        }

        public virtual ActionResult Remove(int key)
        {
            Service.Remove(key);
            return RedirectToAction("Index");
        }
        public virtual ActionResult Index()
        {
            return View(Service.GetAll());
        }
        public ActionResult DataSource(Syncfusion.JavaScript.DataManager dm)
        {
            Dm = dm;


            int count;
            var Data = GetData(dm, out count);

            return Json(new { result = Data.ToArray(), count = count }, JsonRequestBehavior.AllowGet);
            //IQueryable<TModel> Data = Repository.GetAll();
            //int count = Repository.Count();
            //Syncfusion.JavaScript.DataSources.DataOperations operation = new Syncfusion.JavaScript.DataSources.DataOperations();
            //var d = operation.Execute(Data, dm).Cast<TModel>();
            //return Json(new { result = d.Select(x=>Service.ToViewModel(x)), count = count }, JsonRequestBehavior.AllowGet);

        }

        protected IEnumerable<TViewModel> GetData(DataManager dm, out int count, bool forceAll = false)
        {
            IEnumerable<TViewModel> Data = Service.GetAll().ToArray();
          
            Syncfusion.JavaScript.DataSources.DataOperations operation = new Syncfusion.JavaScript.DataSources.DataOperations();
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                Data = (IEnumerable<TViewModel>) operation.PerformSorting(Data, dm.Sorted);
            }
            else
            {
                //Data = (IEnumerable<TViewModel>) Data.OrderBy(p => p.Id);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                Data =
                    (IEnumerable<TViewModel>)
                        operation.PerformWhereFilter(Data, dm.Where, dm.Where[0].Operator).Cast<TViewModel>();
            }
            count = Data.Count();
            if (!forceAll)
            {
                if (dm.Skip != 0)
                {
                    Data = (IEnumerable<TViewModel>)Data.Skip(dm.Skip);
                }
                if (dm.Take != 0)
                {
                    Data = (IEnumerable<TViewModel>)Data.Take(dm.Take);
                }
            }
            return Data;
        }

        protected DataManager Dm
        {
            get { return Session["LastDataManagerRequested"] as DataManager; }
            set { Session["LastDataManagerRequested"] = value; }
        }

        // GET: /Units/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = Service.Find(id.Value);
            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: /Units/Create
        public virtual ActionResult Create()
        {
            var vm = Service.CreateNew();
            FormViewBag(vm);
            return View(vm);
        }

        public virtual void FormViewBag(TViewModel viewModel)
        {
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Service.Add(viewModel);
                return RedirectToAction("Index");
            }
            FormViewBag(viewModel);
            return View(viewModel);
        }

        // GET: /Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var unit = Service.Find(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            FormViewBag(unit);
            return View(unit);
        }

        // POST: /Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TViewModel item)
        {
            if (ModelState.IsValid)
            {
                Service.Save(item);
                return RedirectToAction("Index");
            }
            FormViewBag(item);
            return View(item);
        }

        // GET: /Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var unit = Service.Find(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: /Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //var unit = Service.Find(id);
         Service.Remove(id);
            return RedirectToAction("Index");
        }

    }
}