using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Attributes;

namespace TryReflection
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            var userList = new List<User>();

            userList.Add(new User(23)
            {
                FirstName = "Ivannjsankdsnkvnfklnfkdlnbkdfnbklfdnbklndflkbndk",
                LastName = "Lol"
            });

            userList.Add(new User(1023)
            {
                FirstName = "Doma",
                LastName = "Karpojgoirwjgorepgalsf[opgjfdjohkdpf[kh"
            });

            foreach (var user in userList)
            {
                PrintResult(user);
            } */
            Console.ReadKey();
        }

        private IEnumerable<User> CreateUserListLinq()
        {
            Type userType = typeof (User);
            TypeInfo metaData = userType.GetTypeInfo();

            IEnumerable<User> userList =
                metaData.GetCustomAttributes(typeof (InstantiateUserAttribute))
                .Select(x => ((InstantiateUserAttribute)x).CreateUserInstance())
                .ToList();

            return userList;
        } 

    /*    private static void PrintResult(User user)
        {
            if (ValidateUser(user))
                Console.WriteLine("User {0} valid", user.FirstName);
            else
            {
                Console.WriteLine("User {0} invalid", user.FirstName);
            }
        }

        private static bool ValidateUser(User user)
        {
            Type userType = user.GetType();
            TypeInfo metaData = userType.GetTypeInfo();

            FieldInfo idField = metaData.DeclaredFields.First(x => x.Name == "_id") as FieldInfo;

            IntValidatorAttribute idValidatorAttribute =
                idField.GetCustomAttributes(typeof (IntValidatorAttribute))
                .First() as IntValidatorAttribute;

            int minValue = idValidatorAttribute.MinValue;
            int maxValue = idValidatorAttribute.MaxValue;

            int idValue = (int) idField.GetValue(user);

            //idField.SetValue(user, idValue);

            bool isValid = idValue >= minValue && idValue <= maxValue;

            PropertyInfo firstNameProp = metaData.DeclaredProperties
                .First(x => x.Name == "FirstName");

            isValid &= ValidateStringField(firstNameProp, user);

            PropertyInfo lastNameProp = metaData.DeclaredProperties
                .First(x => x.Name == "LastName");

            isValid &= ValidateStringField(lastNameProp, user);

            return isValid;

        }

        private static bool ValidateStringField(PropertyInfo propInfo, User instanceUser)
        {
            StringValidatorAttribute strAttribute =
                propInfo.GetCustomAttributes(typeof(StringValidatorAttribute), true)
                .FirstOrDefault() as StringValidatorAttribute;

            int length = strAttribute.Length;

            string propValue = (string) propInfo.GetValue((instanceUser));

            bool isValid = propValue.Length <= length;

            if (!isValid)
                Console.WriteLine(string.Format("The {0} value is too long", propInfo.Name));

            return isValid;
        } */
    }
}
