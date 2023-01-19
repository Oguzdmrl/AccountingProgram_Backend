using AccountingSolutions.Domain.Abstractions;
using AccountingSolutions.Domain.AppEntities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingSolutions.Domain.AppEntities
{
    public class UserAndCompanyRelationship : Entity
    {
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
