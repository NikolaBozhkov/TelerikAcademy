namespace TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TreeTraversal
    {
        public static void Main()
        {
            var nodesNumber = 7;
            var input = new int[,]
            {
                { 2, 4 },
                { 3, 2 },
                { 5, 0 },
                { 3, 5 },
                { 5, 6 },
                { 5, 1 }
            };

            var nodes = new Node<int>[nodesNumber];
            for (int i = 0; i < nodesNumber; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int pair = 0; pair < input.GetLength(0); pair++)
            {
                var parentId = input[pair, 0];
                var childId = input[pair, 1];

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            // a)
            var root = TreeTraversalMethods.FindRoot(nodes);
            Console.WriteLine("The root is: {0}]\n", root.Value);

            // b)
            var leafsValues = TreeTraversalMethods.FindLeafsValues(nodes);
            Console.WriteLine("The leafs are: {0}\n", string.Join(", ", leafsValues));

            // c)
            var middleNodesValues = TreeTraversalMethods.FindMiddleNodesValues(nodes);
            Console.WriteLine("The middle nodes are: {0}\n", string.Join(", ", middleNodesValues));

            // d)
            var longestPath = TreeTraversalMethods.FindLongestPath(nodes);
            Console.Write("Longest path: ");
            foreach (var node in longestPath)
            {
                Console.Write("{0} ", node.Value);
            }

            Console.WriteLine("\n");

            // e)
            var sum = 14;
            var pathsWithSum = new List<List<Node<int>>>();
            TreeTraversalMethods.FIndAllPathsWithGivenSum(root, new HashSet<Node<int>>(), pathsWithSum, new List<Node<int>>(), sum);
            Console.WriteLine("Paths with given sum {0} are: ", sum);

            foreach (var path in pathsWithSum)
            {
                foreach (var node in path)
                {
                    Console.Write("{0} ", node.Value);
                }

                Console.WriteLine("\n");
            }

            // f)
            var sumToFind = 6;
            var subtreesWithSums = TreeTraversalMethods.FindAllSubtreesSum(nodes, sumToFind);
            Console.WriteLine("Nodes with sum of thier subtree equal to {0} ", sumToFind);
            foreach (var node in subtreesWithSums)
            {
                Console.WriteLine("{0}", node.Value);
            }
        }
    }
}