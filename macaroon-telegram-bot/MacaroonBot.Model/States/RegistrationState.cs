namespace MacaroonBot.Model
{
    public class RegistrationState
    {
        public RegistrationStep Step { get; set; } = RegistrationStep.Start;
        public string? ParentFirstName { get; set; }
        public string? ParentLastName { get; set; }
        public string? ParentSurName { get; set; }
        public string? ParentPhone { get; set; }

        public string? ChildFirstName { get; set; }
        public string? ChildLastName { get; set; }
        public string? ChildSurName { get; set; }
        public DateTime? ChildBirthDate { get; set; }
    }
}
