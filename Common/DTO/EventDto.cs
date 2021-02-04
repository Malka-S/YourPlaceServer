using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class EventDto
    {
    public DateTime event_date { get; set; }
    public string event_des { get; set; }
    public DateTime due_date { get; set; }
    public int event_id { get; set; }
    public int event_type_id { get; set; }
    public string invitation_file { get; set; }
    public int num_places_around_a_table { get; set; }

    public int num_tables { get; set; }
    public int user_id { get; set; }

  }
}
