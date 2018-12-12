using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WMSSuitable
{
	public class AlterMethods
	{
		public void ExampleWithoutParameters()
		{
			MessageBox.Show("Metod : ExampleWithoutParameters");
		}

		public void ExampleWithParameters(int i, bool b, string s, DateTime d, char c)
		{
			MessageBox.Show("Metod : ExampleWithParameters\nParam : " +
				i.ToString() + ", " +
				b.ToString() + ", " +
				s + ", " +
				d.ToString() + ", " +
				c.ToString());
		}
		
	}
}