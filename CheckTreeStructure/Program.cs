using System;
using System.Collections.Generic;

namespace CheckTreeStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var mainTree = GenerateData();

            Console.WriteLine("Recusrion");
            Recusrion(mainTree);

            Console.WriteLine("WithoutRecursion");
            WithoutRecursion(mainTree);
        }

        public static void Recusrion(Tree item)
        {
            foreach (var child in item.Children)
            {
                Console.WriteLine(" " + child.Name + " ");

                if (child.HasChildren)
                    Recusrion(child);
            }
        }

        public static void WithoutRecursion(Tree item)
        {
            var current = item;

            var list = new List<Tree>(); 

            while (current != null)
            {
                Console.WriteLine(" " + current.Name + " ");

                if (current.HasChildren)
                {
                    list.AddRange(current.Children);
                }

                if (list.Count > 0)
                {
                    int lastIndex = list.Count - 1;

                    current = list[lastIndex];
                    list.RemoveAt(lastIndex);
                }
                else
                {
                    current = null;
                }
            }
        }


        public static Tree GenerateData()
        {
            return new Tree()
            {
                Name = "Main0",
                Children = new List<Tree>()
                {
                    new Tree()
                    {
                        Name = "1",
                        Children = new List<Tree>()
                        {
                            new Tree()
                            {
                                Name = "11",
                                Children = new List<Tree>()
                                {
                                    new Tree()
                                    {
                                        Name = "111",
                                    },
                                    new Tree()
                                    {
                                        Name = "112",
                                    }
                                }
                            },

                            new Tree ()
                            {
                                Name = "12",
                                Children = new List<Tree>()
                                {
                                    new Tree()
                                    {
                                        Name = "121",
                                    },
                                    new Tree()
                                    {
                                        Name = "122",
                                        Children = new List<Tree>()
                                        {
                                            new Tree()
                                            {
                                                Name = "1221",
                                            },
                                        }
                                    },
                                    new Tree()
                                    {
                                        Name = "123",
                                    },
                                }
                            },

                            new Tree ()
                            {
                                Name = "13",
                            }
                        }
                    },

                    new Tree()
                    {
                        Name = "2",
                        Children = new List<Tree>()
                        {
                            new Tree()
                            {
                                Name = "21",
                            },
                            new Tree()
                            {
                                Name = "22",
                            },
                        }
                    },

                    new Tree()
                    {
                        Name = "3",
                    }
                }
            };
        }
    }
}

class Tree
{
    public List<Tree> Children  { get; set; }
    public string Name { get; set; }

    public bool HasChildren {
        get {
            if (Children == null)
                return false;

            return Children.Count > 0;
        }  
    }
}

