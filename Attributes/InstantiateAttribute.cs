using System;
using System.Runtime.Remoting.Messaging;

namespace Attributes
{
    // Should be applied to classes only.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InstantiateUserAttribute : Attribute
    {
        public int? Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public InstantiateUserAttribute(string FirstName, string LastNamr)
        {
            this.FirstName = FirstName;
            this.LastName = LastNamr;
        }

        public InstantiateUserAttribute(int Id, string FirstName, string LastNamr) 
            : this(FirstName, LastNamr)
        {
            this.Id = Id;
        }

        public User CreateUserInstance()
        {
            int id = Id.HasValue
                ? Id.Value
                : new Random().Next();

            var result = new User(id)
            {
                FirstName = FirstName,
                LastName = LastName
            };

            return result;
        }
    }
}
