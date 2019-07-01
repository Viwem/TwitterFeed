using System;
using System.Collections.Generic;
using System.IO;
using TweetAssignment.Repository;

namespace TweetAssignment
{
	class Program
	{
		static void Main(string[] args)
		{

			var users =  UserRepository.GetUsers(args[0]);

			if (users != null && users.Count > 0)
			{
				FeedRepository.GetFeed(args[1], users);
			}
			
			Console.ReadLine();
		}

	}
}
