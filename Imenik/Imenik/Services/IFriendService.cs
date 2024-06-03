using Imenik.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imenik.Services
{
    public interface IFriendService
    {
        void DeleteFriend(string firstName);
        Friend GetFriendByFirstName(string firstName);
        Task<IEnumerable<Friend>> GetFriends();
        void Save(Friend friend);
    }
}