using System.Collections.Generic;

namespace MentorialProject.DAL.Enteties {
  public class Sale {
    public int id { get; set; }
    public int offset { get; set; }
    public List<SaleResult> results { get; set; }
    public int total { get; set; }
  }
}
