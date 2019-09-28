namespace StuffPacker.store.packlist.Get
{

    public class GetPackListDataFailedAction
    {
        public string ErrorMessage { get; private set; }

        public GetPackListDataFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
