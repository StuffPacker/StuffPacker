using Blazor.Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.store.UserProduct
{
   
    public class UserProductsDataFeature : Feature<UserProductsDataState>
    {
        public override string GetName() => "UserProductsData";
        protected override UserProductsDataState GetInitialState()
        {
            return new UserProductsDataState(
          isLoading: false,
          errorMessage: null,
          null,
          null
          );
        }


    }
}
