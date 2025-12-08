using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalentShowcasePlatform.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        // many-to-many
        public List<GroupMember> Members { get; set; } = new();
    }

    public class GroupMember
    {
        public int Id { get; set; }

        public string UserId { get; set; }   
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
