using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Members.Commands.CreateMember
{
    public class CreateMemberCommand : IRequest<int>
    {
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

    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, int>
    {
        public IRepository _repository { get; set; }

        public CreateMemberCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var newMember = new Member
            {
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SurName = request.SurName,
                Sex = request.Sex,
                BirthDate = request.BirthDate,
                WeddingDate = request.WeddingDate,
                RegistrationDate = request.RegistrationDate,
                MembershipDate = request.MembershipDate,
                MaritalStatus = request.MaritalStatus,
                BaptizedHere = request.BaptizedHere,
                PreviousChurch = request.PreviousChurch,
                DiscipleshipTeacher = request.DiscipleshipTeacher,
                IsServing = request.IsServing,
                EducationLevel = request.EducationLevel,
                IsInHomeCell = request.IsInHomeCell,
                HomeCellId = request.HomeCellId,
                NotInHomeCellReason = request.NotInHomeCellReason,
                PermitHomeForHomeCell = request.PermitHomeForHomeCell,
                IsInChurchSocialService = request.IsInChurchSocialService,
                HasJob = request.HasJob,
                Occupation = request.Occupation,
                Company = request.Company,
                Responsibility = request.Responsibility,
                Profession = request.Profession,
                OtherAbilities = request.OtherAbilities,
                SpouseTitle = request.SpouseTitle,
                SpouseFullName = request.SpouseFullName,
                IsSpouseBeliever = request.IsSpouseBeliever,
                SpouseChurch = request.SpouseChurch,
                SpouseMaxEducationalLevel = request.SpouseMaxEducationalLevel,
                FemaleBelieverChildren = request.FemaleBelieverChildren,
                MaleBelieverChildren = request.MaleBelieverChildren,
                FemaleNonBelieverChildren = request.FemaleNonBelieverChildren,
                MaleNonBelieverChildren = request.MaleNonBelieverChildren,
                AgeOneToSeven = request.AgeOneToSeven,
                AgeEightToThirteen = request.AgeEightToThirteen,
                AgeFourteenToThirty = request.AgeFourteenToThirty,
                EduKgToSix = request.EduKgToSix,
                EduSevenToTwelve = request.EduSevenToTwelve,
                EduCollage = request.EduCollage,
                EduUniversity = request.EduUniversity
            };
            await _repository.AddAsync(newMember);
            return newMember.Id;

        }
    }
}
