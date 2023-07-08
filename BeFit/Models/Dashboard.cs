namespace BeFit.Models
{
    public class Dashboard
    {
        public Dashboard(string userName, List<WeightMeasurement> weightMeasurements)
        {
            this.UserName = userName;
            this.WeightMeasurements = weightMeasurements;
        }

        public List<WeightMeasurement> WeightMeasurements { get; set; }
        public string UserName { get; set; }
    }
}
