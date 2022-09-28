﻿using System.Collections.Generic;
using System.Linq;

namespace Examples.Enumerable
{
    public class Constructor
    {
        public void CallConstructor()
        {
            var list = System.Linq.Enumerable.Empty<int>();

            var obj = new MyClass<int>(list.ToList());
        }

        public void ManyArgumentsConstructor()
        {
            var list = System.Linq.Enumerable.Empty<Constructor>();

            var obj = new MyClass<Constructor>(list.ToArray(), false, GetList().ToArray());
        }

        public void ArrayTest()
        {
            var list = new List<int>();
            
            var obj = new MyClass<int>(list.ToArray(), true);
        }

        private static IEnumerable<Constructor> GetList()
        {
            return System.Linq.Enumerable.Empty<Constructor>();
        }

        private class MyClass<T>
        {
            private readonly IEnumerable<T> source;

            public MyClass(IEnumerable<T> source)
            {
                source = source;
            }

            public MyClass(IEnumerable<T> source, bool value, IReadOnlyCollection<T> test)
            {
                source = source;
                if (value) source = test;
            }
            
            public MyClass(T[] source, bool value)
            {
                source = source;
                if (value) source = null;
            }
        }
    }
}