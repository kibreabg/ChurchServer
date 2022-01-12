using ChurchServer.SharedKernel;
using System;

namespace ChurchServer.Core.Entities
{
    public class Member : BaseEntity
    {
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string SurName { get; private set; }
        public string Sex { get; private set; }
        public DateTime BirthDate { get; private set; }        
        public DateTime WeddingDate { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string MaritalStatus { get; private set; }
        public bool BaptizedHere { get; private set; }
        public string PreviousChurch { get; private set; }
        public string MembershipDate { get; private set; }
        public string DiscipleshipTeacher { get; private set; }
        public bool IsServing { get; private set; }
        public string EducationLevel { get; private set; }
        public bool IsInHomeCell { get; private set; }
        public int HomeCellId { get; private set; }
        public string NotInHomeCellReason { get; private set; }
        public bool PermitHomeForHomeCell { get; private set; }
        public bool IsInChurchSocialService { get; private set; }
        public bool HasJob { get; private set; }
        public string Occupation { get; private set; }
        public string Company { get; private set; }
        public string Responsibility { get; private set; }
        public string Profession { get; private set; }
        public string OtherAbilities { get; private set; }
        public string SpouseTitle { get; private set; }
        public string SpouseFullName { get; private set; }
        public bool IsSpouseBeliever { get; private set; }
        public string SpouseChurch { get; private set; }
        public string SpouseMaxEducationalLevel { get; private set; }
        public int FemaleBelieverChildren { get; private set; }
        public int MaleBelieverChildren { get; private set; }
        public int FemaleNonBelieverChildren { get; private set; }
        public int MaleNonBelieverChildren { get; private set; }
        public int AgeOneToSeven { get; private set; }
        public int AgeEightToThirteen { get; private set; }
        public int AgeFourteenToThirty { get; private set; }
        public int EduKgToSix { get; private set; }
        public int EduSevenToTwelve { get; private set; }
        public int EduCollage { get; private set; }
        public int EduUniversity { get; private set; }
        

    }
}
