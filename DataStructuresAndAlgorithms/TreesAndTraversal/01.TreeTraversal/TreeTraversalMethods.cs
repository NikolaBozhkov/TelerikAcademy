namespace TreeTraversal
{
    using System;
    using System.Collections.Generic;

    public static class TreeTraversalMethods
    {
        public static Node<T> FindRoot<T>(Node<T>[] nodes)
        {
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("The tree has no root.");
        }

        public static HashSet<T> FindLeafsValues<T>(Node<T>[] nodes)
        {
            var leafs = new HashSet<T>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node.Value);
                }
            }

            return leafs;
        }

        public static HashSet<T> FindMiddleNodesValues<T>(Node<T>[] nodes)
        {
            var middleNodes = new HashSet<T>();

            foreach (var node in nodes)
            {
                if (node.Children.Count > 0 && node.HasParent)
                {
                    middleNodes.Add(node.Value);
                }
            }

            return middleNodes;
        }

        public static List<Node<T>> FindLongestPath<T>(Node<T>[] nodes)
        {
            var root = FindRoot(nodes);
            var paths = new List<List<Node<T>>>();
            FIndAllPaths(root, new HashSet<Node<T>>(), paths, new List<Node<T>>());

            var longestPath = new List<Node<T>>();

            foreach (var path in paths)
            {
                if (path.Count >= longestPath.Count)
                {
                    longestPath = path;
                }
            }

            return longestPath;
        }

        public static void FIndAllPaths<T>(Node<T> node, HashSet<Node<T>> visited, List<List<Node<T>>> paths, List<Node<T>> path)
        {
            visited.Add(node);
            path.Add(node);

            if (node.Children.Count == 0)
            {
                paths.Add(new List<Node<T>>(path));
                return;
            }

            foreach (var child in node.Children)
            {
                if (!visited.Contains(child))
                {
                    FIndAllPaths(child, visited, paths, path);
                }

                path.Remove(child);
            }
        }

        // Here I copy code, but the other way is with Func as parameter and other methods, to make this one reuseable
        public static void FIndAllPathsWithGivenSum(Node<int> node, HashSet<Node<int>> visited, List<List<Node<int>>> paths, List<Node<int>> path, int sum)
        {
            visited.Add(node);
            path.Add(node);

            if (node.Children.Count == 0)
            {
                var sumFromPath = 0;
                foreach (var nodeInFoundPath in path)
                {
                    sumFromPath += nodeInFoundPath.Value;
                }

                if (sumFromPath == sum)
                {
                    paths.Add(new List<Node<int>>(path));
                }

                return;
            }

            foreach (var child in node.Children)
            {
                if (!visited.Contains(child))
                {
                    FIndAllPathsWithGivenSum(child, visited, paths, path, sum);
                }

                path.Remove(child);
            }
        }

        public static List<Node<int>> FindAllSubtreesSum(Node<int>[] nodes, int sum)
        {
            var resultNodes = new List<Node<int>>();
            var subtreesSums = new Dictionary<Node<int>, int>();

            foreach (var node in nodes)
            {
                var sumFromNode = FindSubtreeSum(node, subtreesSums);
                if (sumFromNode == sum)
                {
                    resultNodes.Add(node);
                }
            }

            return resultNodes;
        }

        public static int FindSubtreeSum(Node<int> node, Dictionary<Node<int>, int> subtreesSums)
        {
            if (subtreesSums.ContainsKey(node))
            {
                return subtreesSums[node];
            }

            int sum = 0;
            foreach (var child in node.Children)
            {
                sum += FindSubtreeSum(child, subtreesSums);
            }

            sum += node.Value;
            subtreesSums[node] = sum;
            return sum;
        }
    }
}
