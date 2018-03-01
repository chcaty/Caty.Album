using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caty.Album.Model
{
    public class AlbumContext:DbContext
    {
        public AlbumContext() : base() { }
        public AlbumContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<RoleRight> RoleRights { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<PeopleGroup> PeopleGroups { get; set; }
    }
}
