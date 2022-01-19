using ChurchServer.Application.Common.Mappings;
using ChurchServer.Core.Entities;
using System;

namespace ChurchServer.Application.Members.Queries
{
    public class MemberDto : IMapFrom<Member>
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
}
