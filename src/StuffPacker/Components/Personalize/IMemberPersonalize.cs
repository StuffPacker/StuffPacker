using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffPacker.ViewModel.Members;

namespace StuffPacker.Components.Personalize
{
    public interface IMemberPersonalize
    {
        Task<IEnumerable<MemberListItemViewModel>> Personalize(IEnumerable<MemberListItemViewModel> models);
    }
}
