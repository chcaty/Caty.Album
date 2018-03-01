using Caty.Album.BLL.Interface;
using Caty.Album.Dal.Interface;
using Caty.Album.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Caty.Album.BLL.Implements
{
    public partial class FaceService:BaseService<Face>,IFaceService
    {
        private IFaceDal _faceDal;
        public FaceService(IFaceDal faceDal):base(faceDal)
        {
            _faceDal = faceDal;
        }
    }

    public partial class PeopleService:BaseService<People>,IPeopleService
    {
        private IPeopleDal _peopleDal;
        public PeopleService(IPeopleDal peopleDal) : base(peopleDal)
        {
            _peopleDal = peopleDal;
        }
    }
    public partial class GroupService : BaseService<Group>, IGroupService
    {
        private IGroupDal _groupDal;
        public GroupService(IGroupDal groupDal) : base(groupDal)
        {
            _groupDal = groupDal;
        }
    }

    public partial class PeopleGroupService : BaseService<PeopleGroup>, IPeopleGroupService
    {
        private IPeopleGroupDal _peoplegroupDal;
        public PeopleGroupService(IPeopleGroupDal peoplegroupDal) : base(peoplegroupDal)
        {
            _peoplegroupDal = peoplegroupDal;
        }
    }
}
