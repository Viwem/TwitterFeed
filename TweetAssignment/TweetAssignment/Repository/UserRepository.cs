using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TweetAssignment.Repository
{
	public class UserRepository
	{
	
		public static SortedDictionary<string, List<string>> GetUsers(string userFilePath)
		{
			var userDictionary = new SortedDictionary<string, List<string>>();

			const string follows = " follows ";

			foreach (var line in FileReadWorker.ReadFile(userFilePath))
			{   
				var followerIndex = line.IndexOf(follows, 0);
				var follower = line.Substring(0, followerIndex);

				var users = line.Substring(followerIndex + follows.Length, line.Length - followerIndex - follows.Length);

				var userList = users.Split(',');
				BuildUserRelationship(userDictionary, follower, userList);
			}
				
			return userDictionary;
		}
		
		public static SortedDictionary<string, List<string>> BuildUserRelationship(SortedDictionary<string, List<string>> userDictionary, string follower, string[] userList )
		{
			if (!userDictionary.ContainsKey(follower))
			{
				userDictionary.Add(follower, new List<string>());
			}

			foreach (var user in userList)
			{
				var currentUser = user.Trim();

				if (!userDictionary.ContainsKey(currentUser))
				{
					userDictionary.Add(currentUser, new List<string>());
				}

				if (!userDictionary[follower].Contains(currentUser))
				{
					userDictionary[follower].Add(currentUser);
				}
			}
			return userDictionary;
		}
	}
}
