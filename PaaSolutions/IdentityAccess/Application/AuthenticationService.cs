using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Encryption;
using IdentityAccess.Infrastructure.Identity;
using IdentityAccess.Domain.Model.Identity;
using Common.Domain.Model;


namespace IdentityAccess.Application
{
    public class AuthenticationService
    {
        public AuthenticationService(UserRepository userRepository, IEncryptionService encryptionService)
        {
            this.userRepository = userRepository;
            this.encryptionService = encryptionService;
        }

        readonly UserRepository userRepository;
        readonly IEncryptionService encryptionService;

        public User Authenticate(string username, string password) 
        {
            AssertionConcern.AssertArgumentNotEmpty(username, "Username must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(password, "Password must be provided.");

            string encryptedPassword = this.encryptionService.EncryptedValue(password);

            User user = this.userRepository.UserFromAuthenticCredentials(username, encryptedPassword);

            return user;
        }
    }
}
