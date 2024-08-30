namespace SLaw.Application.Features.Queries.ContactForms.GetAll
{
    public class GetAllContactFormQueryResponse
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
