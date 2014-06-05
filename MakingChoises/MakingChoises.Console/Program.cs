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

    using MakingChoises.DataAccess;
    using MakingChoises.Model;

    /// <summary>The program.</summary>
    internal class Program
    {
        #region Methods

        /// <summary>The main.</summary>
        /// <param name="args">The args.</param>
        private static void Main(string[] args)
        {
            var dbContext = new DatabaseContext();
            dbContext.Conditions.Add(new Condition { Id = 1 });
            Console.ReadKey();
        }

        #endregion
    }
}