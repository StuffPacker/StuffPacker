using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.store.packlist.Get
{
    
    public class GetPackListDataSuccessAction
    {
        public PackListViewModel[] PackLists { get; private set; }

        public GetPackListDataSuccessAction(PackListViewModel[] packLists)
        {
            PackLists = packLists;
        }
    }
}
