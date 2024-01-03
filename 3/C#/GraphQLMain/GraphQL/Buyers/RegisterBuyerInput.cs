namespace ConferencePlanner.GraphQL.Buyers
{
    public record RegisterBuyerInput(
        string FirstName,
        string LastName,
        string UserName,
        string EmailAddress);
}
