using System;
using System.Collections.Generic;

namespace Test_Process_Services.Models
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Guid?> QuestionsIds { get; set; }
        public Guid? TestThemeId { get; set; }
    }
}