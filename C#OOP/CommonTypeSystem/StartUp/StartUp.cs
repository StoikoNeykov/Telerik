namespace StartUp
{
    using System;

    using Student.Enumerations;
    using Student.Models;
    using Person.Models;
    using BitArray64;
    using BinaryTree;

    /// <summary>
    /// Testing classes
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            // TestStudent();

            // TestPerson();

            // TestArr();

            // TestBinaryTree();
        }

        private static void TestStudent()
        {
            var stud = new Student("Pesho", "Ivanov", "Georgiev", "999-00-4444", "Pesho`s address is deep secret",
                "+1 155 1254845", "pesho@mail.bg", "Programming", Specialties.Engineering, Faculties.Programming,
                University.MIT);

            var evilTwin = (Student)stud.Clone();
            Console.WriteLine("GetHashCode() return: {0}", stud.GetHashCode() == evilTwin.GetHashCode());

            Console.WriteLine("Equals return: {0}", stud.Equals(evilTwin));

            Console.WriteLine("CompareTo return: {0}", stud.CompareTo(evilTwin));

        }

        private static void TestPerson()
        {
            var pesho = new Person("Pesho");
            var gosho = new Person("Gosho", 13);
            Console.WriteLine(pesho);
            Console.WriteLine(gosho);
        }

        private static void TestArr()
        {
            var arr = new BitArray64();
            arr[8] = 1;
            Console.WriteLine(arr);

            arr = new BitArray64(1646235);
            Console.WriteLine(arr);

            var arr2 = new BitArray64(100);
            arr = new BitArray64(100);
            Console.WriteLine(arr == arr2);
            Console.WriteLine(arr.GetHashCode());
            Console.WriteLine(arr2.GetHashCode());
        }

        private static void TestBinaryTree()
        {
            var tree = new BinaryTree<int>();

            Console.WriteLine(tree.Root);

            tree.Add(5);
            tree.Remove(5);
            tree.Add(5);
            tree.Add(3);
            tree.Add(2);
            tree.Add(8);
            tree.Add(9);
            tree.Add(18); 
            tree.Add(84);
            tree.Remove(2);
            tree.Remove(3);
            tree.Add(4);
            tree.Remove(5);
            tree.Add(5);
            tree.Add(83);
            tree.Add(58);
            tree.Add(85);
            tree.Add(86);
            tree.Add(34);
            tree.Add(65);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            Console.WriteLine(tree.Search(5));
            Console.WriteLine(tree.Search(18));
            tree.Remove(4);
            tree.Remove(5);
            tree.Remove(83);
            tree.Remove(65);
            tree.Add(99);
            tree.Remove(34);
            tree.Add(65);
            tree.Remove(9);
            tree.Remove(7);
            tree.Add(4);
            Console.WriteLine(tree.ToString());

            var clone = tree.Clone();
            clone.Add(100);
            Console.WriteLine(tree);
            Console.WriteLine(clone);

        }
    }
}
