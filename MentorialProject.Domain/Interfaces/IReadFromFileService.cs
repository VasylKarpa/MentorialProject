using System;
using System.Collections.Generic;
using System.Text;

namespace MentorialProject.Domain.Interfaces {
  public interface IReadFromFileService<T> {
    void LoadJson();
  }
}
