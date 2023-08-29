using API.Entities;

namespace API.Interface
{
    public interface IEmailHelper
    {
        public void SendWelcomeEmail(User user);
        
        public void SendUpdateInfoEmail(User user);
        
        public void SendNewRegstrationEmail(User user);
        
        public void SendUpdateInfoEmail(List<User> contacts);

        public void SendPasswordResetEmail(string email, string password);

        public void SendTermsAndConditionsEmail(List<User> contacts);

        public void SendEnableUserEmail(string name, string email, string iKNumber);

        public void SendDisableUserEmail(string name, string email, string iKNumber);
    }
}
