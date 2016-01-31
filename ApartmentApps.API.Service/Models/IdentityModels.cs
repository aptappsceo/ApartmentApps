using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ApartmentApps.API.Service.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
     
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<MaitenanceRequest> MaitenanceRequests { get; set; }
        public DbSet<MaitenanceAction> MaitenanceActions { get; set; }
        public DbSet<MaitenanceRequestType> MaitenanceRequestTypes { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class Corporation
    {
   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }

    public class Property
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CorporationId { get; set; }

        [ForeignKey("CorporationId")]
        public Corporation Corporation { get; set; }

        public ICollection<Building> Buildings { get; set; } 
    }

    public class Building
    {
        [Key]
        public int Id { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }

        public ICollection<Unit> Units { get; set; }
    }

    public class Unit
    {
        [Key]
        public int Id { get; set; }

        public int BuildingId { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }
    }

    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }

    public class MaitenanceRequest
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public ApplicationUser Worker { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


        public ICollection<MaitenanceAction> Actions { get; set; }
    }

    public class MaitenanceAction
    {
        public int MaitenanceRequestId { get; set; }

        [ForeignKey("MaitenanceRequestId")]
        public MaitenanceRequest MaitenanceRequest { get; set; }
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public MaitenanceActionType ActionType { get; set; }


    }

    public enum MaitenanceActionType
    {
        Requested,
        Accepted,
        Paused,
        Complete,
        Other

    }
    public class MaitenanceRequestType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    
    
}