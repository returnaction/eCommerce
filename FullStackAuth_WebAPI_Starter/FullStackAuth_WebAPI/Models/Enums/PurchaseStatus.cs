namespace FullStackAuth_WebAPI.Models.Enums
{
    public enum PurchaseStatus
    {
        None,
        Open,// user purchases the product, and waiting to be sent by seller
        Send, // when seller send the product to user
        Recieved, // user got the product
        Closed
    }
}
