using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Prospect.IDScan;
using ApartmentApps.Portal.Controllers;
using Korzh.EasyQuery.Db;
using Ninject;

namespace ApartmentApps.Modules.Prospect
{
    [Persistant]
    public class ProspectModuleConfig : ModuleConfig
    {
        
    }

    [Persistant]
    public class ProspectApplication : PropertyEntity
    {

        public DateTime CreatedOn { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DesiredMoveInDate { get; set; }

        [ForeignKey("SubmittedById")]
        public virtual ApplicationUser SubmittedBy { get; set; }

        public string SubmittedById { get; set; }

    }

    public class ProspectModule : Module<ProspectModuleConfig>, IMenuItemProvider, IAdminConfigurable
    {
        public ProspectModule(IKernel kernel, IRepository<ProspectModuleConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
        }

        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {
            if (UserContext.IsInRole("PropertyAdmin") || UserContext.IsInRole("Admin"))
            {
                menuItems.Add(new MenuItemViewModel("Prospect ID", "fa-barcode")
                {
                    Children = new List<MenuItemViewModel>()
                    {
                        new MenuItemViewModel("Prospects","fa-plus-square","Index","Prospect")
                    }
                });
            }
        }

        public string SettingsController => "ProspectConfig";
    }

    public class ProspectService : StandardCrudService<ProspectApplication>
    {
        private readonly IUserContext _userContext;

        public ProspectService(IKernel kernel, IRepository<ProspectApplication> repository, IUserContext userContext) : base(kernel, repository)
        {
            _userContext = userContext;
        }

        public DbQuery All()
        {
            return CreateQuery("All");
        }

        public void SubmitApplicant(ProspectApplicationBindingModel vm)
        {
            var model = Map<ProspectApplicationBindingModel>().ToModel(vm);
            model.CreatedOn = _userContext.CurrentUser.TimeZone.Now();
            Repository.Add(model);
            Repository.Save();
        }

        public ScanIdResult ScanId(string imageBase64)
        {
            var services = new DriverLicenseParserClient();
            var authKey = "2727c7a1-ab81-499c-95d9-10bf62472d16";
            //var result = services.ParseString(authKey, imageBase64, null);
            var result = services.ParseImage(authKey, Convert.FromBase64String(imageBase64), null);
            if (result.Success)
            {
                var scanIdResult = new ScanIdResult();
                scanIdResult.AddressLine1 = result.DriverLicense.Address1;
                scanIdResult.AddressLine2 = result.DriverLicense.Address2;
                scanIdResult.Birthdate = result.DriverLicense.Birthdate;
                scanIdResult.CardRevisionDate = result.DriverLicense.CardRevisionDate;
                scanIdResult.City = result.DriverLicense.City;
                scanIdResult.Country = result.DriverLicense.Country;
                scanIdResult.CountryCode = result.DriverLicense.CountryCode;
                scanIdResult.EndorsementCodeDescription = result.DriverLicense.EndorsementCodeDescription;
                scanIdResult.EndorsementsCode = result.DriverLicense.EndorsementsCode;
                scanIdResult.ExpirationDate = result.DriverLicense.ExpirationDate;
                scanIdResult.EyeColor = result.DriverLicense.EyeColor;
                scanIdResult.ClassificationCode = result.DriverLicense.ClassificationCode;
                scanIdResult.HairColor = result.DriverLicense.HairColor;
                scanIdResult.AddressLine2 = result.DriverLicense.Height;
                scanIdResult.ComplianceType = result.DriverLicense.ComplianceType;
                scanIdResult.FirstName = result.DriverLicense.FirstName;
                scanIdResult.LastName = result.DriverLicense.LastName;
                scanIdResult.FullName = result.DriverLicense.FullName;
                scanIdResult.Gender = result.DriverLicense.Gender;
                scanIdResult.IssueDate = result.DriverLicense.IssueDate;
                scanIdResult.IssuedBy = result.DriverLicense.IssuedBy;
                scanIdResult.PostalCode = result.DriverLicense.PostalCode;
                scanIdResult.Race = result.DriverLicense.Race;
                scanIdResult.VehicleClassCode = result.DriverLicense.VehicleClassCode;
                scanIdResult.VehicleClassCodeDescription = result.DriverLicense.VehicleClassCodeDescription;
                return scanIdResult;
            }
            return null;
        }


    }

    public class ScanIdResult
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? CardRevisionDate { get; set; }
        public string City { get; set; }
        public string Country { get; internal set; }
        public string CountryCode { get; set; }
        public string EndorsementCodeDescription { get; set; }
        public string EndorsementsCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string EyeColor { get; set; }
        public string ClassificationCode { get; set; }
        public string HairColor { get; set; }
        public char? ComplianceType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssuedBy { get; set; }
        public string PostalCode { get; set; }
        public string Race { get; set; }
        public string VehicleClassCode { get; set; }
        public string VehicleClassCodeDescription { get; set; }
    }

    public class ProspectApplicationMapper : BaseMapper<ProspectApplication, ProspectApplicationBindingModel>
    {
        private readonly IMapper<ApplicationUser, UserBindingModel> _userMapper;

        public ProspectApplicationMapper(IMapper<ApplicationUser, UserBindingModel> userMapper, IUserContext userContext) : base(userContext)
        {
            _userMapper = userMapper;
        }

        public override void ToModel(ProspectApplicationBindingModel bindingModel, ProspectApplication model)
        {
            model.FirstName = bindingModel.FirstName;
            model.AddressLine1 = bindingModel.AddressLine1;
            model.AddressLine2 = bindingModel.AddressLine2;
            model.AddressCity = bindingModel.AddressCity;
            model.AddressState = bindingModel.AddressState;
            model.ZipCode = bindingModel.ZipCode;
            model.Email = bindingModel.Email;
            model.PhoneNumber = bindingModel.PhoneNumber;
            model.DesiredMoveInDate = bindingModel.DesiredMoveInDate;
        }

        public override void ToViewModel(ProspectApplication model, ProspectApplicationBindingModel bindingModel)
        {
            
            bindingModel.FirstName = model.FirstName;
            bindingModel.AddressLine1 = model.AddressLine1;
            bindingModel.AddressLine2 = model.AddressLine2;
            bindingModel.AddressCity = model.AddressCity;
            bindingModel.AddressState = model.AddressState;
            bindingModel.ZipCode = model.ZipCode;
            bindingModel.Email = model.Email;
            bindingModel.PhoneNumber = model.PhoneNumber;
            bindingModel.DesiredMoveInDate = model.DesiredMoveInDate;
            if (model.SubmittedBy != null)
            {
                bindingModel.SubmittedBy = _userMapper.ToViewModel(model.SubmittedBy);
            }
            
        }
    }
    public class ProspectApplicationBindingModel : BaseViewModel
    {
        public DateTime CreatedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [DisplayName("Desired Move In Date")]
        public DateTime? DesiredMoveInDate { get; set; }

        
        public UserBindingModel SubmittedBy { get; set; }
    }
}
