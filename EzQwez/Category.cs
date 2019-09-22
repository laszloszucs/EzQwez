using System.Collections.Generic;

namespace EzQwez
{
    public abstract class Category
    {
        public IEnumerable<Qwez> Pool { get; set; }
        public string Key { get; }
        public string Name { get; }

        public Category(string key, string name)
        {
            Key = key;
            Name = name;
        }

        public void Test()
        {
            new Test(Pool);
        }
    }
}