using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary.Models
{
    public enum SortState
    {
        NameBookAsc,    // по имени по возрастанию
        NameBookDesc,   // по имени по убыванию
        YearPublishAsc, // по возрасту по возрастанию
        YearPublishDesc,    // по возрасту по убыванию
        CountPageAsc, // по компании по возрастанию
        CountPageDesc, // по компании по убыванию
        AuthorAsc, // по компании по возрастанию
        AuthorDesc // по компании по убыванию
    }
}
