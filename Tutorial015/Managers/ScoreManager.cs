using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Tutorial015.Models;

namespace Tutorial015.Managers
{
	public class ScoreManager
	{
		private static string _fileName = "scores.xml";
		public List<Score> HighScores { get; private set; }
		public List<Score> Scores { get; private set; }

		public ScoreManager() : this(new List<Score>())
		{

		}

		public ScoreManager(List<Score> scores)
		{
			Scores = scores;

			UpdateHighScores();
		}

		public void Add(Score score)
		{
			Scores.Add(score);
			Scores = Scores.OrderByDescending(s => s.Value).ToList();

			UpdateHighScores();
		}

		public static ScoreManager Load()
		{
			if (!File.Exists(_fileName))
			{
				return new ScoreManager();
			}

			using (var reader = new StreamReader(new FileStream(_fileName, FileMode.Open)))
			{
				var serializer = new XmlSerializer(typeof(List<Score>));

				var scores = (List<Score>)serializer.Deserialize(reader);

				return new ScoreManager(scores);
			}
		}

		public static void Save(ScoreManager scoreManager)
		{
			using (var writer = new StreamWriter(new FileStream(_fileName, FileMode.Create)))
			{
				var serializer = new XmlSerializer(typeof(List<Score>));

				serializer.Serialize(writer, scoreManager.Scores);
			}
		}

		public void UpdateHighScores()
		{
			HighScores = Scores.Take(5).ToList();
		}
	}
}
