using Caty.Album.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caty.Album.Dal.Interface
{
    public partial interface IUserDal : IBaseDal<User>
    {
        
    }
    public partial interface IRoleDal : IBaseDal<Role>
    {

    }
    public partial interface IFaceDal : IBaseDal<Face>
    {

    }
    public partial interface IPeopleDal : IBaseDal<People>
    {
        
    }
    public partial interface IGroupDal : IBaseDal<Group>
    {

    }
    public partial interface IPeopleGroupDal : IBaseDal<PeopleGroup>
    {

    }
}
