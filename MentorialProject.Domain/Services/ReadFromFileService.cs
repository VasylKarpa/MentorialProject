using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MentorialProject.DAL.Enteties;
using MentorialProject.Domain.Interfaces;
using Newtonsoft.Json;

namespace MentorialProject.Domain.Services {
  public class ReadFromFileService : IReadFromFileService<Sale> {
    public void LoadJson() {
     using (StreamReader reader = new StreamReader(".json")) {
        string json = reader.ReadToEnd();
        Sale sale = JsonConvert.DeserializeObject<Sale>(json);
      }
    }
  }
}
