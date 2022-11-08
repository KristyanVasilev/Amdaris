using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ForSchool.WritingAndDrawing
{
    public abstract class Writing
    {
		private string name;

		public string Name
		{
			get { return name; }
			set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                name = value;
            }
        }

	}
}
