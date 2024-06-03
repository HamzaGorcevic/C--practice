using Imenik.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Imenik.ViewModel
{
    public interface IFriendListViewModel
    {
        ObservableCollection<Friend> Friends { get; set; }
        Friend SelectedFriend { get; set; }

        Task Load();
    }
}



