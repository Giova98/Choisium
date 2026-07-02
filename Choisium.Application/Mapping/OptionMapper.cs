using Choisium.Application.DTOs.Option.Request;
using Choisium.Application.DTOs.Option.Response;
using Choisium.Domain.Entity;

namespace Choisium.Application.Mapping
{
    public static class OptionMapper
    {
        public static Option ToEntity(CreateOptionRequest request, Guid taskId) => new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Score = request.Score,
            StateOption = (Domain.Entity.StateOption)request.StateOption,
            DecisionTaskId = taskId
        };

        public static void ApplyUpdate(UpdateOptionRequest request, Option option)
        {
            option.Name = request.Name;
            option.Score = request.Score;
            option.StateOption = (Domain.Entity.StateOption)request.StateOption;
        }

        public static OptionResponse ToResponse(Option option) => new()
        {
            Id = option.Id,
            Name = option.Name,
            Score = option.Score,
            StateOption = (DTOs.Option.Response.StateOption)option.StateOption,
            DecisionTaskId = option.DecisionTaskId
        };
    }
}