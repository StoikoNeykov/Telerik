namespace C2Exam
{
    // 80/100 

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class PenguinAirlines
    {
        static void Main()
        {
            short Islands = short.Parse(Console.ReadLine());
            var output = new StringBuilder();

            // graph holder 
            var map = new List<short>[Islands];

            // posible routes
            var line = string.Empty;          
            for (int i = 0; i < Islands; i++)
            {
                line = Console.ReadLine();

                if (line == "None")
                {
                    continue;
                }

                map[i] = line
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(short.Parse)
                    .ToList();
            }

            // looking for posible route 
            line = Console.ReadLine();
            while (line != "Have a break")
            {
                var curentRoute = line
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(short.Parse)
                    .ToArray();

                if (map[curentRoute[0]] == null || map[curentRoute[1]] == null)
                {
                    output.AppendLine("No flights available.");
                }
                else if (map[curentRoute[0]].Contains(curentRoute[1]))
                {
                    output.AppendLine("There is a direct flight.");
                }
                else
                {
                    var que = new Queue<short>();
                    var isChecked = new bool[Islands];
                    que.Enqueue(curentRoute[0]);
                    isChecked[curentRoute[0]] = true;
                    bool isFound = false;
                    while (que.Count > 0)
                    {
                        var curentNode = que.Dequeue();
                        foreach (var node in map[curentNode])
                        {
                            if (node == curentRoute[1])
                            {
                                output.AppendLine("There are flights, unfortunately they are not direct, grandma :(");
                                isFound = true;
                                break;
                            }

                            if (!isChecked[node])
                            {
                                que.Enqueue(node);
                                isChecked[node] = true;
                            }

                        }

                        if (isFound)
                        {
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        output.AppendLine("No flights available.");
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(output.ToString());
        }
    }
}
