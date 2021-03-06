﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Modules.Inspections
{
  


    [Persistant]
    public class InspectionsModuleConfig : PropertyModuleConfig
    {
        
    }
    public class InspectionsModule : Module<InspectionsModuleConfig>, IMenuItemProvider
    {
        private readonly IRepository<Inspection> _inspections;

        public InspectionsModule(IRepository<Inspection> inspections, IKernel kernel, IRepository<InspectionsModuleConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
            _inspections = inspections;
        }
        public void PopulateMenuItems(List<MenuItemViewModel> menuItems)
        {

            var menuItem = new MenuItemViewModel("Inspections", "fa-briefcase");
            menuItem.Children.Add(new MenuItemViewModel("New Inspection", "fa-plus-square", "NewInspection", "Inspections"));
            //if (UserContext.IsInRole("PropertyAdmin"))
            //{
            //    menuItem.Children.Add(new MenuItemViewModel("Requests", "fa-folder", "Index", "MaitenanceRequests"));
            //}
            //if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            //{
            //    menuItem.Children.Add(new MenuItemViewModel("Schedule", "fa-folder", "MySchedule", "MaitenanceRequests"));
            //}
            //if (UserContext.IsInRole("Maintenance") || UserContext.IsInRole("PropertyAdmin"))
            //{
            //    menuItem.Children.Add(new MenuItemViewModel("Monthly Report", "fa-folder", "MonthlyReport", "MaitenanceRequests"));
            //}
            menuItems.Add(menuItem);
        }

    }

    public enum InspectionStatus
    {
        Created,
        Started,
        Paused,
        Completed,
    }

    [Persistant]
    public class Inspection : PropertyEntity
    {
        public InspectionStatus Status { get; set; }

        public virtual ICollection<InspectionCategoryResult> InspectionCategoryResults { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? CompleteDate { get; set; }

        public int UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        public DateTime CreateDate { get; set; }
        public string Message { get; set; }
        
        public string SubmissionUserId { get; set; }

        [ForeignKey("SubmissionUserId")]
        public ApplicationUser SubmissionUser { get; set; }

        public int PetStatus { get; set; }
        public Guid GroupId { get; set; }
        public string AssignedToId { get; set; }
        [ForeignKey("AssignedToId")]
        public ApplicationUser AssignedTo { get; set; }
    }
    [Persistant]
    public class InspectionCheckin : PropertyEntity
    {
        public string Name { get; set; }

        public Guid GroupId { get; set; }

        public DateTime Date { get; set; }

        public string WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public ApplicationUser Worker { get; set; }

        public InspectionStatus Status { get; set; }
        public string Comments { get; set; }



        public int InspectionId { get; set; }

        [ForeignKey("InspectionId")]
        public virtual Inspection Inspection { get; set; }
    }
    [Persistant]
    public class InspectionRoom : PropertyEntity
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Counters/Walls/etc
    /// </summary>
    [Persistant]
    public class InspectionCategory : PropertyEntity
    {
        public string Name { get; set; }
    }

    public enum InspectionCategoryStatus
    {
        Fair,
        Poor,
        Good,
        Great
    }
    [Persistant]
    public class InspectionCategoryResult : PropertyEntity
    {
        public int InspectionId { get; set; }

        [ForeignKey("InspectionId")]
        public Inspection Inspection { get; set; }

        public int InspectionCategoryId { get; set; }

        [ForeignKey("InspectionCategoryId")]
        public InspectionCategory InspectionCategory { get; set; }

        public int InspectionRoomId { get; set; }

        [ForeignKey("InspectionRoomId")]
        public virtual InspectionRoom InspectionRoom { get; set; }

        public InspectionCategoryStatus Status { get; set; }

        public virtual ICollection<InspectionResult> Results { get; set; } 
    }
    [Persistant]
    public class InspectionResult : PropertyEntity
    {
        public int InspectionCategoryResultId { get; set; }

        [ForeignKey("InspectionCategoryResultId")]
        public virtual InspectionCategoryResult InspectionCategoryResult { get; set; }
        
        public int InspectionQuestionId { get; set; }

        [ForeignKey("InspectionQuestionId")]
        public virtual InspectionQuestion InspectionQuestion { get; set; }

        public string Value { get; set; }
    }


    public enum InspectionQuestionType
    {
        YesNo,

    }

    [Persistant]
    public class InspectionQuestion : PropertyEntity
    {
        public string QuestionName { get; set; }
        public InspectionQuestionType QuestionType { get; set; }
    }

}
