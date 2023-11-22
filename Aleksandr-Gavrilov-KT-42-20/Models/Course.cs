using Aleksandr_Gavrilov_KT_42_20.Models;
using System.Text.Json.Serialization;

namespace Aleksandr_Gavrilov_KT_42_20.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int GroupId { get; set; }

        [JsonIgnore]
        public Group? Group { get; set; }
        //public Group? Group { get; set; }
    }
}
