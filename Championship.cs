using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Championship
{
	class Team
	{
		public int Number { get; set; }
		public int wins = 0;
		private static int[] scores = new int[8];

		public Team(int n)
		{
			Number = n;
		}

		//Getters
		public int GetScores(int i)
		{
			return scores[i];
		}

		//Setters
		public void SetScores(int i, int goals)
		{
			scores[i] = goals;
		}

		Random rand = new Random();

		public void ToPlayAMatch(int j)
		{
			SetScores(j, rand.Next(6));
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Team[] teams = new Team[8];
			for (int i = 0; i < 8; i++)
				teams[i] = new Team(i+1);
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
					if (i != j)
						teams[i].ToPlayAMatch(j);
					else teams[i].SetScores(j, 0);
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8 - i; j++)
					if (teams[i].GetScores(j) > teams[j].GetScores(i))
						teams[i].wins++;
			ListOfMatches(teams);
			TopTeams(teams);
			ScoreOfMatch(teams);
			Console.ReadKey();
		}

		static void ListOfMatches(Team[] teams)
		{
			for (int i = 0; i < 7; i++)
				for (int j = i; j < 8; j++)
					if (i != j)
						Console.WriteLine($"Team{teams[i].Number} {teams[i].GetScores(j)} - {teams[j].GetScores(i)} Team{teams[j].Number}");
		}

		static void Swap(ref int a, ref int b)
		{
			int t = a;
			a = b;
			b = t;
		}

		static void TopTeams(Team[] teams)
		{
			int[] wins = new int[8];
			int[] top = new int[8];
			for (int i = 0; i < 8; i++)
			{
				wins[i] = teams[i].wins;
				top[i] = i+1;
			}
			for (int i = 0; i < 7; i++)
				for (int j = 0; j < 7 - i; j++)
					if (wins[j] < wins[j + 1])
					{
						Swap(ref wins[j], ref wins[j + 1]);
						Swap(ref top[j], ref top[j + 1]);
					}
			Console.WriteLine($"\nAnd the winner iiiis..... Team{top[0]}! Gonratulations with the victory on this championship!");
			Console.WriteLine($"There was not enough for Team{top[1]} - Second Place!");
			Console.WriteLine($"And Team{top[2]} - Third Place!");
		}

		static void ScoreOfMatch(Team[] teams)
		{
			int i, j;
			Console.WriteLine("\nYou can see the separate score of the match by entering team's names (numbers)");
			do
			{
				Console.Write("Team");
				i = Convert.ToInt32(Console.ReadLine());
				i--;
				Console.Write("vs Team");
				j = Convert.ToInt32(Console.ReadLine());
				j--;
				if ((i != j) && (i >= 0) && (i < 8) && (j >= 0) && (j < 8))
					Console.WriteLine($"Team{teams[i].Number} {teams[i].GetScores(j)} - {teams[j].GetScores(i)} Team{teams[j].Number}\n");
				else
					Console.WriteLine("Incorrect input, try again\n");
			} while (true);
		}
	}
}