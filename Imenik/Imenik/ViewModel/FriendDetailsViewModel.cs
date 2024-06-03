using Imenik.Events;
using Imenik.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik.Model
{
    public class FriendDetailsViewModel : BaseViewModel, IFriendDetailsViewModel
    {
        private Friend friend;

        private readonly IFriendService service;
        private readonly IEventAggregator eventAggregator;
        private readonly OpenDetailsPubSubEvent openDetailsPubSubEvent;
        private DelegateCommand saveCommand;

        public DelegateCommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }

        }

        public Friend Friend
        {
            get { return friend; }
            set
            {
                friend = value;
                OnPropertyChanged();
            }
        }
        private void SaveFriend()
        {
            service.Save(friend);
        }

        private bool CanSave()
        {
            return true;
        }

        public FriendDetailsViewModel(IFriendService service, IEventAggregator eventAggregator)
        {
            this.service = service;

            this.eventAggregator = eventAggregator;
            openDetailsPubSubEvent = eventAggregator.GetEvent<OpenDetailsPubSubEvent>();
            Friend = new Friend();
            eventAggregator.GetEvent<OpenDetailsPubSubEvent>().Subscribe(GetFriend);

            SaveCommand = new DelegateCommand(SaveFriend, CanSave);


        }

        private void GetFriend(string firstName)
        {
            Friend = service.GetFriendByFirstName(firstName);

        }


    }
}
