using System;
using System.Collections.Generic;

namespace L6Trees
{

    /*
     * Tasks:
     * 1) Complete the implementation of the Node methods
     * 2) Print out the tree using the different tree traversal metods
     * 3) Test findNote() and deleteNode()
     *
     *
     */
    class Node
    {
        // Attributes
        private Node left { get; set; }
        private Node right { get; set; }
        private string item;

        //Methods
        public Node(string newitem)
        {
            item = newitem;
            right = null;
            left = null;
        }
        public void addNode(string newitem)
        {
            if (newitem.CompareTo(item) < 0)
            {
                if (left == null)
                {
                    left = new Node(newitem);
                    return;
                }
                else { left.addNode(newitem); }

            }
            else if (newitem.CompareTo(item) >= 0)
            {
                if (right == null)
                {
                    right = new Node(newitem);
                    return;
                }
                else { right.addNode(newitem); }
            }
        }
        public Boolean findNode(string newitem)
        {
            if (newitem.CompareTo(item) == 0) { Console.Write("found {0}", item); return true; }
            else if (newitem.CompareTo(item) < 0)
            {
                if (left == null) { Console.Write("null not found"); return true; }
                else
                {
                    Console.Write("L ");
                    left.findNode(newitem);
                }
            }
            else if (newitem.CompareTo(item) > 0)
            {
                if (right == null) { Console.Write("null not found"); return true; }
                else
                {
                    Console.Write("R ");
                    right.findNode(newitem);
                }
            }
            return true;
        }

        public Boolean deleteNote(string newitem, Node prev = null, bool LR = true, List<Node> traversed = null, int count = -1)
        {
            if (traversed == null) { traversed = new List<Node> { }; }
            if (newitem.CompareTo(item) == 0)
            {
                Console.WriteLine("found {0}", item);
                if (prev == null) { Console.WriteLine("Cannot delete root node"); }
                else
                {
                    if (LR == true) { traversed[count - 1].right = null; }
                    else if (LR == false) { traversed[count - 1].left = null; }
                    Console.WriteLine("Node deleted");
                }
                return true;
            }
            else if (newitem.CompareTo(item) < 0)
            {
                LR = false;
                prev = left;
                count++;
                traversed.Add(left);
                prev.deleteNote(newitem, prev, LR, traversed, count);
            }
            else if (newitem.CompareTo(item) > 0)
            {
                LR = true;
                prev = right;
                traversed.Add(right);
                count++;
                prev.deleteNote(newitem, prev, LR, traversed, count);
            }
            return true;
        }
        public void printTree(int method)
        {
            switch (method)
            {
                case (1):
                    prefix(this);
                    break;
                case (2):
                    infix(this);
                    break;
                case (3):
                    postfix(this);
                    break;
            }
        }
        private void prefix(Node current)
        {
            if (current != null)
            {
                Console.Write(current.item);
                prefix(current.left);
                prefix(current.right);
            }
        }
        private void infix(Node current)
        {
            if (current != null)
            {
                Console.Write(current.item);
                infix(current.left);
                infix(current.right);
            }
        }
        private void postfix(Node current)
        {
            if (current != null)
            {
                Console.Write(current.item);
                postfix(current.left);
                postfix(current.right);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            // process all the nodes on the array
            //
            foreach (var mon in months)
            {
                if (root == null)
                    root = new Node(mon);
                else
                    root.addNode(mon);
            }

            // print out the tree using different traversal methods
            //
            Console.WriteLine("Prefix");
            root.printTree(1);
            Console.WriteLine("");
            Console.WriteLine("Infix");
            root.printTree(2);
            Console.WriteLine("");
            Console.WriteLine("Postfix");
            root.printTree(3);
            Console.WriteLine("");
            // Test the findNote() and deleteNode()
            foreach (var mon in months)
            {
                root.findNode(mon);
                Console.WriteLine("");
            }
            root.deleteNote("May");
            //All nodes after May are also deleted
            foreach (var mon in months)
            {
                root.findNode(mon);
                Console.WriteLine("");
            }
        }
    }
}
