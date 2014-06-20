// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExampleStoryGenerator.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.Console
{
    using System.Collections.Generic;

    using MakingChoises.Model;

    /// <summary>The example story generator.</summary>
    public class ExampleStoryGenerator
    {
        #region Public Methods and Operators

        /// <summary>The make example story.</summary>
        /// <returns>The <see cref="Story"/>.</returns>
        public static Story MakeExampleStory()
        {
            return new Story { Steps = MakeExampleSteps() };
        }

        #endregion

        #region Methods

        /// <summary>The make example step 1.</summary>
        /// <param name="nextStep">The next step.</param>
        /// <returns>The <see cref="Step"/>.</returns>
        private static Step MakeExampleStep1(Step nextStep)
        {
            return new Step
                       {
                           Number = 1, 
                           NextStep = nextStep, 
                           Problems =
                               MakeExampleStep1Problems(
                                   nextStep.Problems[0], 
                                   nextStep.Problems[1], 
                                   nextStep.NextStep.Problems[1])
                       };
        }

        /// <summary>The make example step 1 problem 1.</summary>
        /// <param name="step2Problem1">The step 2 problem 1.</param>
        /// <param name="step2Problem2">The step 2 problem 2.</param>
        /// <param name="step2Problem3">The step 2 problem 3.</param>
        /// <returns>The <see cref="Problem"/>.</returns>
        private static Problem MakeExampleStep1Problem1(
            Problem step2Problem1, 
            Problem step2Problem2, 
            Problem step2Problem3)
        {
            return new Problem
                       {
                           Options = MakeExampleStep1Problem1Options(step2Problem1, step2Problem2, step2Problem3), 
                           Text =
                               "You wake up finding yourself in a small room lying on the ground. Your head hurts terribly. "
                               + "You don't remember anything. Slowly you manage to stand up. "
                               + "While standing up you notice there is a large pool of blood all around you, your clothes are soaked, but it doesn't appear that it's yours. "
                               + "You look around, you see two glass doors. One of them is leading outside, but appears to be locked, The other seems to be unlocked and leads to a big hallway."
                               + "You see a bucket lying upside down in a corner. Next to that is a stack of crates in the corner with a knife lying on top."
                               + "Suddenly you hear footsteps comming your way from the hallway. "
                               + "What do you do?"
                       };
        }

        /// <summary>The make example step 1 problem 1 option 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Option"/>.</returns>
        private static Option MakeExampleStep1Problem1Option1(Problem nextProblem)
        {
            return new Option { Routes = MakeExampleStep1Problem1Option1Routes(nextProblem), Text = "Grab the knife." };
        }

        /// <summary>The make example step 1 problem 1 option 1 route 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        private static Route MakeExampleStep1Problem1Option1Route1(Problem nextProblem)
        {
            return new Route { Conditions = new List<Condition>(), NextProblem = nextProblem };
        }

        /// <summary>The make example step 1 problem 1 option 1 routes.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="IList{Route}"/>.</returns>
        private static IList<Route> MakeExampleStep1Problem1Option1Routes(Problem nextProblem)
        {
            return new[] { MakeExampleStep1Problem1Option1Route1(nextProblem) };
        }

        /// <summary>The make example step 1 problem 1 option 2.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Option"/>.</returns>
        private static Option MakeExampleStep1Problem1Option2(Problem nextProblem)
        {
            return new Option
                       {
                           Routes = MakeExampleStep1Problem1Option2Routes(nextProblem), 
                           Text = "Hide behind the crates."
                       };
        }

        /// <summary>The make example step 1 problem 1 option 2 route 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        private static Route MakeExampleStep1Problem1Option2Route1(Problem nextProblem)
        {
            return new Route { Conditions = new List<Condition>(), NextProblem = nextProblem };
        }

        /// <summary>The make example step 1 problem 1 option 2 routes.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="IList{Route}"/>.</returns>
        private static IList<Route> MakeExampleStep1Problem1Option2Routes(Problem nextProblem)
        {
            return new[] { MakeExampleStep1Problem1Option2Route1(nextProblem) };
        }

        /// <summary>The make example step 1 problem 1 option 3.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Option"/>.</returns>
        private static Option MakeExampleStep1Problem1Option3(Problem nextProblem)
        {
            return new Option { Routes = MakeExampleStep1Problem1Option3Routes(nextProblem), Text = "Call for help." };
        }

        /// <summary>The make example step 1 problem 1 option 3 route 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        private static Route MakeExampleStep1Problem1Option3Route1(Problem nextProblem)
        {
            return new Route { Conditions = new List<Condition>(), NextProblem = nextProblem };
        }

        /// <summary>The make example step 1 problem 1 option 3 routes.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="IList{Route}"/>.</returns>
        private static IList<Route> MakeExampleStep1Problem1Option3Routes(Problem nextProblem)
        {
            return new[] { MakeExampleStep1Problem1Option3Route1(nextProblem) };
        }

        /// <summary>The make example step 1 problem 1 options.</summary>
        /// <param name="step2Problem1">The step 2 problem 1.</param>
        /// <param name="step2Problem2">The step 2 problem 2.</param>
        /// <param name="step2Problem3">The step 2 problem 3.</param>
        /// <returns>The <see cref="IList{Option}"/>.</returns>
        private static IList<Option> MakeExampleStep1Problem1Options(
            Problem step2Problem1, 
            Problem step2Problem2, 
            Problem step2Problem3)
        {
            return new[]
                       {
                           MakeExampleStep1Problem1Option1(step2Problem1), MakeExampleStep1Problem1Option2(step2Problem2), 
                           MakeExampleStep1Problem1Option3(step2Problem3)
                       };
        }

        /// <summary>The make example step 1 problems.</summary>
        /// <param name="step2Problem1">The step 2 problem 1.</param>
        /// <param name="step2Problem2">The step 2 problem 2.</param>
        /// <param name="step2Problem3">The step 2 problem 3.</param>
        /// <returns>The <see cref="IList{Problem}"/>.</returns>
        private static IList<Problem> MakeExampleStep1Problems(
            Problem step2Problem1, 
            Problem step2Problem2, 
            Problem step2Problem3)
        {
            return new[] { MakeExampleStep1Problem1(step2Problem1, step2Problem2, step2Problem3) };
        }

        /// <summary>The make example step 2.</summary>
        /// <param name="nextStep">The next step.</param>
        /// <returns>The <see cref="Step"/>.</returns>
        private static Step MakeExampleStep2(Step nextStep)
        {
            return new Step
                       {
                           Number = 2, 
                           Problems = MakeExampleStep2Problems(nextStep.Problems[0], nextStep.Problems[1]),
                           NextStep = nextStep
                       };
        }

        /// <summary>The make example step 2 problem 1.</summary>
        /// <param name="step3Problem1">The step 3 problem 1.</param>
        /// <param name="step3Problem2">The step 3 problem 2.</param>
        /// <returns>The <see cref="Problem"/>.</returns>
        private static Problem MakeExampleStep2Problem1(Problem step3Problem1, Problem step3Problem2)
        {
            return new Problem
                       {
                           Options = MakeExampleStep2Problem1Options(step3Problem1, step3Problem2), 
                           Text =
                               "You grab the knife from the stack of crates. The footsteps are getting faster and louder. "
                               + "Your heart is starting to pound really fast while the footsteps are getting closer."
                               + "Through the glass door you see a man holding a large knife, it looks the same as the knife you're holding."
                               + "He sees you. He's looking angry at you. He quickly opens the door. "
                               + "What do you do?"
                       };
        }

        /// <summary>The make example step 2 problem 1 option 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Option"/>.</returns>
        private static Option MakeExampleStep2Problem1Option1(Problem nextProblem)
        {
            return new Option { Routes = MakeExampleStep2Problem1Option1Routes(nextProblem), Text = "Stab the man." };
        }

        /// <summary>The make example step 2 problem 1 option 1 route 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        private static Route MakeExampleStep2Problem1Option1Route1(Problem nextProblem)
        {
            return new Route { Conditions = new List<Condition>(), NextProblem = nextProblem };
        }

        /// <summary>The make example step 2 problem 1 option 1 routes.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="IList{Route}"/>.</returns>
        private static IList<Route> MakeExampleStep2Problem1Option1Routes(Problem nextProblem)
        {
            return new[] { MakeExampleStep2Problem1Option1Route1(nextProblem) };
        }

        /// <summary>The make example step 2 problem 1 option 2.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Option"/>.</returns>
        private static Option MakeExampleStep2Problem1Option2(Problem nextProblem)
        {
            return new Option { Routes = MakeExampleStep2Problem1Option2Routes(nextProblem), Text = "Call for help." };
        }

        /// <summary>The make example step 2 problem 1 option 2 route 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        private static Route MakeExampleStep2Problem1Option2Route1(Problem nextProblem)
        {
            return new Route { Conditions = new List<Condition>(), NextProblem = nextProblem };
        }

        /// <summary>The make example step 2 problem 1 option 2 routes.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="IList{Route}"/>.</returns>
        private static IList<Route> MakeExampleStep2Problem1Option2Routes(Problem nextProblem)
        {
            return new[] { MakeExampleStep2Problem1Option2Route1(nextProblem) };
        }

        /// <summary>The make example step 2 problem 1 options.</summary>
        /// <param name="step3Problem1">The step 3 problem 1.</param>
        /// <param name="step3Problem2">The step 3 problem 2.</param>
        /// <returns>The <see cref="IList{Option}"/>.</returns>
        private static IList<Option> MakeExampleStep2Problem1Options(Problem step3Problem1, Problem step3Problem2)
        {
            return new[]
                       {
                           MakeExampleStep2Problem1Option1(step3Problem1), MakeExampleStep2Problem1Option2(step3Problem2)
                       };
        }

        /// <summary>The make example step 2 problem 2.</summary>
        /// <param name="step3Problem1">The step 3 problem 1.</param>
        /// <param name="step3Problem2">The step 3 problem 2.</param>
        /// <returns>The <see cref="Problem"/>.</returns>
        private static Problem MakeExampleStep2Problem2(Problem step3Problem1, Problem step3Problem2)
        {
            return new Problem
                       {
                           Options = MakeExampleStep2Problem2Options(step3Problem1, step3Problem2), 
                           Text =
                               "You hide behind the stack of crates. The footsteps are getting faster and louder. "
                               + "Your heart is starting to pound really fast while the footsteps are getting closer."
                               + "Suddenly you don't hear anything anymore. You anctiously look up from the crates."
                               + "Through the glass door you see a man holding a large knife, it looks the same as the knife that's lying on the crate."
                               + "He spotted you. He looks angry and quickly opens the door. " + "What do you do?"
                       };
        }

        /// <summary>The make example step 2 problem 2 option 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Option"/>.</returns>
        private static Option MakeExampleStep2Problem2Option1(Problem nextProblem)
        {
            return new Option
                       {
                           Routes = MakeExampleStep2Problem2Option1Routes(nextProblem), 
                           Text = "Throw the knife at the man."
                       };
        }

        /// <summary>The make example step 2 problem 2 option 1 route 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        private static Route MakeExampleStep2Problem2Option1Route1(Problem nextProblem)
        {
            return new Route { Conditions = new List<Condition>(), NextProblem = nextProblem };
        }

        /// <summary>The make example step 2 problem 2 option 1 routes.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="IList{Route}"/>.</returns>
        private static IList<Route> MakeExampleStep2Problem2Option1Routes(Problem nextProblem)
        {
            return new[] { MakeExampleStep2Problem2Option1Route1(nextProblem) };
        }

        /// <summary>The make example step 2 problem 2 option 2.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Option"/>.</returns>
        private static Option MakeExampleStep2Problem2Option2(Problem nextProblem)
        {
            return new Option { Routes = MakeExampleStep2Problem2Option2Routes(nextProblem), Text = "Call for help." };
        }

        /// <summary>The make example step 2 problem 2 option 2 route 1.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        private static Route MakeExampleStep2Problem2Option2Route1(Problem nextProblem)
        {
            return new Route { Conditions = new List<Condition>(), NextProblem = nextProblem };
        }

        /// <summary>The make example step 2 problem 2 option 2 routes.</summary>
        /// <param name="nextProblem">The next problem.</param>
        /// <returns>The <see cref="IList{Route}"/>.</returns>
        private static IList<Route> MakeExampleStep2Problem2Option2Routes(Problem nextProblem)
        {
            return new[] { MakeExampleStep2Problem2Option2Route1(nextProblem) };
        }

        /// <summary>The make example step 2 problem 2 options.</summary>
        /// <param name="step3Problem1">The step 3 problem 1.</param>
        /// <param name="step3Problem2">The step 3 problem 2.</param>
        /// <returns>The <see cref="IList{Option}"/>.</returns>
        private static IList<Option> MakeExampleStep2Problem2Options(Problem step3Problem1, Problem step3Problem2)
        {
            return new[]
                       {
                           MakeExampleStep2Problem2Option1(step3Problem1), MakeExampleStep2Problem2Option2(step3Problem2)
                       };
        }

        /// <summary>The make example step 2 problems.</summary>
        /// <param name="step3Problem1">The step 3 problem 1.</param>
        /// <param name="step3Problem2">The step 3 problem 2.</param>
        /// <returns>The <see cref="IList{Problem}"/>.</returns>
        private static IList<Problem> MakeExampleStep2Problems(Problem step3Problem1, Problem step3Problem2)
        {
            return new[]
                       {
                           MakeExampleStep2Problem1(step3Problem1, step3Problem2), 
                           MakeExampleStep2Problem2(step3Problem1, step3Problem2)
                       };
        }

        /// <summary>The make example step 3.</summary>
        /// <returns>The <see cref="Step"/>.</returns>
        private static Step MakeExampleStep3()
        {
            return new Step { Number = 3, Problems = MakeExampleStep3Problems() };
        }

        /// <summary>The make example step 3 problem 1.</summary>
        /// <returns>The <see cref="Problem"/>.</returns>
        private static Problem MakeExampleStep3Problem1()
        {
            return new Problem
                       {
                           Options = null, 
                           Text =
                               "The man falls down as your knife cut his throath. As he is falling down you begin to remember what happened. "
                               + "You're working in a meat processing plant. You are in charge of cleaning the floors. "
                               + "You hit your head while trying to get outside. That man is your boss. He was checking up on you. "
                               + "Now he lies there on the ground. What have you done?"
                       };
        }

        /// <summary>The make example step 3 problem 2.</summary>
        /// <returns>The <see cref="Problem"/>.</returns>
        private static Problem MakeExampleStep3Problem2()
        {
            return new Problem
                       {
                           Options = null, 
                           Text =
                               "As you start to yell, you begin to remember what happened. "
                               + "You're working in a meat processing plant. You are in charge of cleaning the floors. "
                               + "You hit your head while trying to get outside. "
                               + "\"What the hell are you doing? \" You hear a voice say. It's your boss."
                               + "\"Sorry\" you say. \"I must have hit my head.\""
                       };
        }

        /// <summary>The make example step 3 problems.</summary>
        /// <returns>The <see cref="IList{Problem}"/>.</returns>
        private static IList<Problem> MakeExampleStep3Problems()
        {
            return new[] { MakeExampleStep3Problem1(), MakeExampleStep3Problem2() };
        }

        /// <summary>The make example steps.</summary>
        /// <returns>The <see cref="IList{Step}"/>.</returns>
        private static IList<Step> MakeExampleSteps()
        {
            Step step3 = MakeExampleStep3();
            Step step2 = MakeExampleStep2(step3);
            return new[] { MakeExampleStep1(step2), step2 };
        }

        #endregion
    }
}