using ChurchServer.Application.Common.Exceptions;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Members.Commands.UpdateMember
{
    public class UpdateMemberCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime WeddingDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime MembershipDate { get; set; }
        public string MaritalStatus { get; set; }
        public bool BaptizedHere { get; set; }
        public string PreviousChurch { get; set; }
        public string DiscipleshipTeacher { get; set; }
        public bool IsServing { get; set; }
        public string EducationLevel { get; set; }
        public bool IsInHomeCell { get; set; }
        public int HomeCellId { get; set; }
        public string NotInHomeCellReason { get; set; }
        public bool PermitHomeForHomeCell { get; set; }
        public bool IsInChurchSocialService { get; set; }
        public bool HasJob { get; set; }
        public string Occupation { get; set; }
        public string Company { get; set; }
        public string Responsibility { get; set; }
        public string Profession { get; set; }
        public string OtherAbilities { get; set; }
        public string SpouseTitle { get; set; }
        public string SpouseFullName { get; set; }
        public bool IsSpouseBeliever { get; set; }
        public string SpouseChurch { get; set; }
        public string SpouseMaxEducationalLevel { get; set; }
        public int FemaleBelieverChildren { get; set; }
        public int MaleBelieverChildren { get; set; }
        public int FemaleNonBelieverChildren { get; set; }
        public int MaleNonBelieverChildren { get; set; }
        public int AgeOneToSeven { get; set; }
        public int AgeEightToThirteen { get; set; }
        public int AgeFourteenToThirty { get; set; }
        public int EduKgToSix { get; set; }
        public int EduSevenToTwelve { get; set; }
        public int EduCollage { get; set; }
        public int EduUniversity { get; set; }
    }

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand>
    {
        private readonly IRepository _repository;

        public UpdateMemberCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var theMember = await _repository.GetByIdAsync<Member>(request.Id);

            if (theMember == null)
            {
                throw new NotFoundException(nameof(Member), request.Id);
            }

            theMember.Title = request.Title;
            theMember.FirstName = request.FirstName;
            theMember.LastName = request.LastName;
            theMember.SurName = request.SurName;
            theMember.Sex = request.Sex;
            theMember.BirthDate = request.BirthDate;
            theMember.WeddingDate = request.WeddingDate;
            theMember.RegistrationDate = request.RegistrationDate;
            theMember.MembershipDate = request.MembershipDate;
            theMember.MaritalStatus = request.MaritalStatus;
            theMember.BaptizedHere = request.BaptizedHere;
            theMember.PreviousChurch = request.PreviousChurch;
            theMember.DiscipleshipTeacher = request.DiscipleshipTeacher;
            theMember.IsServing = request.IsServing;
            theMember.EducationLevel = request.EducationLevel;
            theMember.IsInHomeCell = request.IsInHomeCell;
            theMember.HomeCellId = request.HomeCellId;
            theMember.NotInHomeCellReason = request.NotInHomeCellReason;
            theMember.PermitHomeForHomeCell = request.PermitHomeForHomeCell;
            theMember.IsInChurchSocialService = request.IsInChurchSocialService;
            theMember.HasJob = request.HasJob;
            theMember.Occupation = request.Occupation;
            theMember.Company = request.Company;
            theMember.Responsibility = request.Responsibility;
            theMember.Profession = request.Profession;
            theMember.OtherAbilities = request.OtherAbilities;
            theMember.SpouseTitle = request.SpouseTitle;
            theMember.SpouseFullName = request.SpouseFullName;
            theMember.IsSpouseBeliever = request.IsSpouseBeliever;
            theMember.SpouseChurch = request.SpouseChurch;
            theMember.SpouseMaxEducationalLevel = request.SpouseMaxEducationalLevel;
            theMember.FemaleBelieverChildren = request.FemaleBelieverChildren;
            theMember.MaleBelieverChildren = request.MaleBelieverChildren;
            theMember.FemaleNonBelieverChildren = request.FemaleNonBelieverChildren;
            theMember.MaleNonBelieverChildren = request.MaleNonBelieverChildren;
            theMember.AgeOneToSeven = request.AgeOneToSeven;
            theMember.AgeEightToThirteen = request.AgeEightToThirteen;
            theMember.AgeFourteenToThirty = request.AgeFourteenToThirty;
            theMember.EduKgToSix = request.EduKgToSix;
            theMember.EduSevenToTwelve = request.EduSevenToTwelve;
            theMember.EduCollage = request.EduCollage;
            theMember.EduUniversity = request.EduUniversity;

            await _repository.UpdateAsync(theMember);

            return Unit.Value;

        }
    }
}
