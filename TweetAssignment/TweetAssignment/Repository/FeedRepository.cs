using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TweetAssignment.Repository
{
	public class FeedRepository
	{

		public static void GetFeed(string tweetFilePath, SortedDictionary<string, List<string>> users)
		{
			var userTweets = new List<Tuple<string, string>>();
			//
		
				const string bracket = "> ";

				foreach (var line in FileReadWorker.ReadFile(tweetFilePath))
				{ 
					var userIndex = line.IndexOf(bracket);
					var user = line.Substring(0, userIndex);
					var tweet = line.Substring(user.Length + bracket.Length, line.Length - user.Length - bracket.Length);

					userTweets.Add(Tuple.Create(user, tweet));
				}
				BuildUserFeeds(users, userTweets);
			

		}

		public static void BuildUserFeeds(SortedDictionary<string, List<string>> users,List<Tuple<string,string>> userTweets)
		{
			foreach (var user in users)
			{
				Console.WriteLine(user.Key);

				foreach (var userTweet in userTweets)
				{
					if (user.Key == userTweet.Item1)
					{
						PrintFeed(userTweet.Item1, userTweet.Item2);
					}
					else if (user.Value.Contains(userTweet.Item1))
					{
						PrintFeed(userTweet.Item1, userTweet.Item2);
					}
				}
			}
		}

		public static void PrintFeed(string user, string tweet)
		{
			Console.WriteLine("@" + user + ": " + tweet);
		}
	}
}
