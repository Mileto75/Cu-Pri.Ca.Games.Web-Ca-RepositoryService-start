using System.Collections.Generic;

namespace Pri.Ca.Games.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<BaseGameViewModel> Games { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    
}
