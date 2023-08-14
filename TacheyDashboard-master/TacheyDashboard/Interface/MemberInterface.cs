using System;
using System.Collections.Generic;
using TacheyDashboard.ViewModel.Members;

namespace TacheyDashboard.Interface
{
    public interface MemberInterface
    {
        List<MemberViewModel> GetAllMemberData();
    }
}
