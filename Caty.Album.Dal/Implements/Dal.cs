using Caty.Album.Dal.Interface;
using Caty.Album.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caty.Album.Dal.Implements
{
    public partial class UserDal : BaseDal<User>, IUserDal
    {
        public UserDal(AlbumContext dbContext) : base(dbContext)
        {

        }
    }
    public partial class RoleDal : BaseDal<Role>, IRoleDal
    {
        public RoleDal(AlbumContext dbContext) : base(dbContext)
        {

        }
    }
    public partial class FaceDal : BaseDal<Face>, IFaceDal
    {
        public FaceDal(AlbumContext dbContext) : base(dbContext)
        {

        }
    }
    public partial class PeopleDal : BaseDal<People>, IPeopleDal
    {
        public PeopleDal(AlbumContext dbContext) : base(dbContext)
        {

        }
    }
    public partial class GroupDal : BaseDal<Group>, IGroupDal
    {
        public GroupDal(AlbumContext dbContext) : base(dbContext)
        {

        }
    }
    public partial class PeopleGroupDal : BaseDal<PeopleGroup>, IPeopleGroupDal
    {
        public PeopleGroupDal(AlbumContext dbContext) : base(dbContext)
        {

        }
    }
}
