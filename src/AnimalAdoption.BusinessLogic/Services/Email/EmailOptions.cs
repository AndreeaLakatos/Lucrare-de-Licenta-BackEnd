namespace AnimalAdoption.BusinessLogic.Services.Email
{
    public class EmailOptions
    {
        public string ApiKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string TemplateIdWelcome { get; set; }
        public string TemplateIdForget { get; set; }
    }
}
