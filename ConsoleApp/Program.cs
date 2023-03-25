using ClassLibrary.DAL;
using ClassLibrary.Factory;
using ClassLibrary.Models;

IRepository<UserRole> userroleRep = FactoryProvider.GetFactory().GetUserRoleRepository();
//for (int i = 0; i < userroleRep.GetAll().Count; i++)
//{
//    Console.WriteLine($"{userroleRep.GetAll()[i].Id} {userroleRep.GetAll()[i].RoleName}");
//}
var t = userroleRep.Get(3);
Console.WriteLine(t.RoleName);
t.RoleName = "TestUpdate";
userroleRep.Update(t);
//userroleRep.Refresh();
//for (int i = 0; i < userroleRep.GetAll().Count; i++)
//{
//    Console.WriteLine($"{userroleRep.GetAll()[i].Id} {userroleRep.GetAll()[i].RoleName}");
//}
using var db = new ApplicationContext();
Console.WriteLine("Querying for a blog");
var blog = db.UserRole.ToList();
for (int i = 0; i < blog.Count; i++)
    {
        Console.WriteLine($"{blog[i].Id} {blog[i].RoleName} {blog[i].RowUpdateTime}");
    }
    //    //.OrderBy(b => b.UserId)
    //    //.First();

    Console.WriteLine("Hello, World!");
