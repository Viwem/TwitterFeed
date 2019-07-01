using System;
using System.Collections.Generic;
using System.Text;

namespace TweetAssignment.Repository.Models
{
	public class User
	{
		public string Name { get; set; }


		public User[] Following { get; set; }
	}
}
