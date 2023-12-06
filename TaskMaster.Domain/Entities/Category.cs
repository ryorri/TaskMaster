using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Domain.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

        public ICollection<Error> ErrorEntry { get; set; }
        public ICollection<Warning> WarningEntry { get; set; }

    }
}
