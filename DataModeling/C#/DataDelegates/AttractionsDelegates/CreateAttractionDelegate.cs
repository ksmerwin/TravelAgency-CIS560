using DataAccess;
using System.Data;
using System.Data.SqlClient;
using DataModeling.Model;

namespace DataModeling
{
    public class CreateAttractionDelegate : NonQueryDataDelegate<Attraction>
    {
        public readonly string name;
        public readonly int cityID;

        public CreateAttractionDelegate(string name, int cityID)
           : base("Attractions.CreateAttraction")
        {
            this.name = name;
            this.cityID = cityID;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("CityID", cityID);

            var p = command.Parameters.Add("AttractionID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Attraction Translate(SqlCommand command)
        {
            return new Attraction((int)command.Parameters["AttractionID"].Value, name, cityID);
        }
    }
}