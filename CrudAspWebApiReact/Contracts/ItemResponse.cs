namespace CrudAspWebApiReact.Contracts
{
    public record ItemResponse(Guid Id, string Title, string Description, decimal Price, DateTime CreatedAt);

}
