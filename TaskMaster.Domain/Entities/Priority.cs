using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Domain.Entities
{
	public class Priority
	{
		public int Id { get; set; }
		public string _Priority { get; set; }

        public ICollection<Error> ErrorEntry { get; set; }

    }
}
