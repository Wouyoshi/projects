// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperConfiguration.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.BusinessLogic
{
    using System.Linq;

    using AutoMapper;

    using MakingChoises.ReadModel;

    /// <summary>The auto mapper configuration.</summary>
    public static class AutoMapperConfiguration
    {
        #region Public Methods and Operators

        /// <summary>The configure.</summary>
        public static void Configure()
        {
            ConfigureStory();
            Mapper.CreateMap<Problem, Model.Problem>().ReverseMap();
            Mapper.CreateMap<Option, Model.Option>().ReverseMap();
        }

        private static void ConfigureStory()
        {
            var mappingForward = Mapper.CreateMap<Story, Model.Story>();
            var mappingBackward = Mapper.CreateMap<Model.Story, Story>();
            mappingBackward.ForMember(
                destination => destination.FirstProblem,
                expression => expression.MapFrom(itm => itm.Steps.First(step => step.Number == 1).Problems.First()));
        }

        #endregion
    }
}