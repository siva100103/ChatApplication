using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3;

namespace ChatApplication
{
    public class Group
    {
        public string GroupName{
            set;
            get;
        }
        public int GroupID{
            set;
            get;
        }
        public List<Client> GroupMembers;
        public Group(string groupName,int groupID,List<Client> groupMembers)
        {
            GroupName = groupName;
            GroupID = groupID;
            GroupMembers = groupMembers;
        }
    }
}
