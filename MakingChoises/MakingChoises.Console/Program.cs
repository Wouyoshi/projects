// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Console
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    using MakingChoises.BusinessLogic;
    using MakingChoises.DataAccess;
    using MakingChoises.Model;

    using Problem = MakingChoises.ReadModel.Problem;

    /// <summary>The program.</summary>
    internal class Program
    {
        #region Methods

        /// <summary>The main.</summary>
        /// <param name="args">The args.</param>
        private static void Main(string[] args)
        {
            var dbContext = new DatabaseContext();
            var story = ExampleStoryGenerator.MakeExampleStory();
            dbContext.Stories.Add(story);
            dbContext.SaveChanges();
            RunStory("Demo");
            dbContext.Stories.Remove(story);
            dbContext.SaveChanges();
            Console.ReadKey();
        }

        private static void RunStory(string storyName)
        {
            var storyManager = new StoryManager(new StoryRetriever());
            var story = storyManager.GetStory(storyName);
            Console.WriteLine(story.Name);
            Console.WriteLine();
            RunProblems(story.FirstProblem, storyManager, new List<int>(), storyName);
            Console.ReadKey();
        }

        private static void RunProblems(Problem problem, StoryManager storyManager, IList<int> options, string storyName)
        {
            Console.WriteLine(problem.Text);
            Console.WriteLine();
            if (problem.Options == null || problem.Options.Count == 0)
            {
                return;
            }

            foreach (ReadModel.Option option in problem.Options)
            {
                Console.WriteLine("{0}) {1}", option.Number, option.Text);
            }
            
            int chosenOption = 0;
            while (!int.TryParse(Console.ReadLine(), out chosenOption) || problem.Options.All(op => op.Number != chosenOption))
            {
                Console.WriteLine("Invalid option.");
            }

            options.Add(chosenOption);
            var nextProblem = storyManager.GetNextProblem(storyName, options);
            RunProblems(nextProblem, storyManager, options, storyName);
        }

        #endregion
    }
}