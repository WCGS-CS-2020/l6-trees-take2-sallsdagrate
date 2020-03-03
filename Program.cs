using System;

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
        private  Node left;
        private  Node right;
        private string item;

        //Methods
        public Node(string item) { }
        public void addNode(string item) {}
        public Boolean findNode(string item) { return true; }
        public Boolean deleteNote(string item) { return true; }
        void printTree() { }
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

            // Test the findNote() and deleteNode()
        }
    }
}
