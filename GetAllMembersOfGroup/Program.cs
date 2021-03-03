using System;
using System.DirectoryServices.AccountManagement;

namespace GetAllMembersOfGroup
{
    class Program
    {
        static void Main()
        {
            GetAllUsersOfGroup();

            Console.ReadLine();
        }

        public static void GetAllUsersOfGroup()
        {
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "NestedGroup");

            // if found....
            if (group != null)
            {
                // iterate over members
                foreach (Principal p in group.GetMembers(true))
                {
                    Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);

                    // do whatever you need to do to those members
                    //UserPrincipal theUser = p as UserPrincipal;
                }
            }
        }
    }
}
