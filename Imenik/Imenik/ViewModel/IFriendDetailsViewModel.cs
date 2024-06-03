using Prism.Commands;

namespace Imenik.Model
{
    public interface IFriendDetailsViewModel
    {
        Friend Friend { get; set; }
        DelegateCommand SaveCommand { get; set; }
    }
}