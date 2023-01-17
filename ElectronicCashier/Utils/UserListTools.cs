using SimpleATM.Objects;

namespace SimpleATM.Utils
{
    internal class UserListTools
    {
        public void RemoveUserFromList(List<User> users, string creditCardNumber)
        {
            users.RemoveAll(user => user.creditCardNumber == creditCardNumber);
        }

        public User GetUserFromList(List<User> users, string creditCardNumber)
        {
            return users.Where(user => user.creditCardNumber == creditCardNumber).First();
        }
    }
}
