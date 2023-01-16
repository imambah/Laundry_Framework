
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class GroupDbo : IDataMapper<GroupDbo>
    {

        public string nama { get; set; }


        public GroupDbo Map(System.Data.IDataReader reader)
        {
            GroupDbo obj = new GroupDbo();
            obj.nama = reader["nama"].ToString();
            return obj;
        }
    }




}



