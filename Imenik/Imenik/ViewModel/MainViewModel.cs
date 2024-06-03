using Imenik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik.ViewModel
{
    public class MainViewModel
    {

        public FriendDetailsViewModel DetailsViewModel { get; set; }
        public FriendListViewModel  ListViewModel { get; set; }

        public MainViewModel(IFriendDetailsViewModel friendDetailsViewModel,IFriendListViewModel friendListViewModel) { 
        

        }  

        public async Task Load()
        {

            await ListViewModel.Load();
        }
    }
}
