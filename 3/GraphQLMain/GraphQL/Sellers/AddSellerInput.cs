namespace ConferencePlanner.GraphQL.Sellers
{
    public record AddSellerInput(
        string Name,
        string? Bio,
        string? WebSite);
}
