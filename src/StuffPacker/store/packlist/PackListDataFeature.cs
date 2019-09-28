using Blazor.Fluxor;

namespace StuffPacker.store.packlist
{

    public class PackListDataFeature : Feature<PackListDataState>
    {
        public override string GetName() => "PackListData";
        protected override PackListDataState GetInitialState()
        {
            return new PackListDataState(
          isLoading: false,
          errorMessage: null,
          null
          );
        }


    }
}
