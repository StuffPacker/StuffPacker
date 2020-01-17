namespace StuffPacker.store.UserProduct.Get
{

    public class GetUserProductsDataFailedAction
    {
        public string ErrorMessage { get; private set; }

        public GetUserProductsDataFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
