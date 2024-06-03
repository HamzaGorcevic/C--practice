using Imenik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik.Services
{

    // povezati service sa nekom bazom (Acces imate spreman kod)
    public class FriendService : IFriendService
    {
        private List<Friend> friends = new List<Friend>
        {
            new Friend {FirstName="Hamza",LastName="Gorcevic",Phone="3213123",Email="ha@gmail.com"},
                        new Friend {FirstName="Haris",LastName="Gorcevic",Phone="3213123",Email="ha@gmail.com"},
            new Friend {FirstName="",LastName="Gorcevic",Phone="3213123",Email="ha@gmail.com"}

        };

        // CRUD operacije za ovaj model
        public Friend GetFriendByFirstName(string firstName)
        {
            var friend = friends.FirstOrDefault(f => f.FirstName.Equals(firstName));
            return friend;
        }
    

        public async Task<IEnumerable<Friend>> GetFriends()
        {
            return friends;
        }

        public void Save(Friend friend)
        {
            var ff = GetFriendByFirstName(friend.FirstName);
            if (ff != null)
            {
                ff.Email = friend.Email;
                ff.LastName = friend.FirstName;
                ff.Phone = friend.Phone;
            }
            else
            {
                friends.Add(friend);

            }
        }

        public void DeleteFriend(string firstName)
        {
            var friend = GetFriendByFirstName(firstName);
            if (friend != null)
            {
                friends.Remove(friend);
            }
        }
    }
}
