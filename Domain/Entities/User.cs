using MySolution.Domain.Enums;

namespace MySolution.Domain.Entities
{
    public class User
    {
        public User(Guid id, string name, string email, byte[] passwordHash, byte[] passwordSalt, ICollection<AppRole> appRoles, DateTime created, DateTime? lastActive)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("User name cannot be empty.");
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidOperationException("User email cannot be empty.");
            if (passwordHash == null || passwordSalt == null)
                throw new InvalidOperationException("User password cannot be empty.");

            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            AppRoles = appRoles;
            Created = created;
            LastActive = lastActive;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public ICollection<AppRole> AppRoles { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime? LastActive { get; private set; }

        public void UpdateRoles(ICollection<AppRole> appRoles)
        {
            if (appRoles.Count <= 0)
                throw new ArgumentException("App roles can't be empty or null");

            AppRoles = appRoles;
        }

        public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            if (passwordHash == null || passwordSalt == null)
                throw new ArgumentException("PasswordHash or passwordSalt can't be empty or null.");

            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

        public void UpdateLastTimeActive()
        {
            LastActive = DateTime.UtcNow;
        }

        public void UpdateProfile(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("User name cannot be empty or null.");
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidOperationException("User email cannot be empty or null.");

            Name = name;
            Email = email;
        }
    }
}
