using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.store.packlist
{
   
    public class PackListDataState
    {
        public bool IsLoading { get; private set; }
        public string ErrorMessage { get; private set; }
        public PackListViewModel[] PackLists { get; private set; }

        public PackListDataState()
        {
            PackLists = new PackListViewModel[0];
        }

        public PackListDataState(bool isLoading, string errorMessage, IEnumerable<PackListViewModel> packLists)
        {
            IsLoading = isLoading;
            ErrorMessage = errorMessage;
            PackLists = packLists == null ? null : packLists.ToArray();
        }
    }
  
}
