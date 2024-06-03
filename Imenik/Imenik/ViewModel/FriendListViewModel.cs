using Imenik.Events;
using Imenik.Model;
using Imenik.Services;
using Prism.Events;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik.ViewModel
{
    public class FriendListViewModel : BaseViewModel, IFriendListViewModel
    {
        public ObservableCollection<Friend> Friends { get; set; }

        private Friend selectedFriend;
        private IFriendService service;

        private EventAggregator eventAggregator;

        public Friend SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                selectedFriend = value;
                OnPropertyChanged();
                eventAggregator.GetEvent<OpenDetailsPubSubEvent>().Publish(selectedFriend.FirstName);
            }
        }


        public FriendListViewModel(EventAggregator eventAggregator, FriendService service)
        {
            Friends = new ObservableCollection<Friend>();

            selectedFriend = new Friend();

            this.eventAggregator = eventAggregator;
            this.service = service;

        }
        public async Task Load()
        {
            var friends = await service.GetFriends();
            foreach (var friend in friends)
            {
                Friends.Add(friend);

            }
        }
    }
}
