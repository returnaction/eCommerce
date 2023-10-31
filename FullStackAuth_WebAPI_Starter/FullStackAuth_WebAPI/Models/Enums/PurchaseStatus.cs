namespace FullStackAuth_WebAPI.Models.Enums
{
    public enum PurchaseStatus
    {
        None,
        Open,// user purchases the product, and waiting to be sent by seller
        AwaitingToSend, // when seller send the product to user
        AwaitingToRecieve,
        Recieved, // user got the product
        Closed
    }
}
