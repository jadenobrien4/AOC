namespace DaySeven
{
 class Node
    {
        string directory;
        private Node? Parent;
        private int value;
        private List<Node> children;

        //Constructors
        public Node(int val = 0, string dir = "")
        {
            Parent = null;
            children = new List<Node>();
            value = val;
            directory = dir;
        }

        public Node(Node p, int val = 0, string dir = "")
        {
            Parent = p;
            children = new List<Node>();
            value = val;
            directory = dir;
        }


        //Getters/Setters
        public Node GetParent()
        {
            return Parent;
        }
        public Node GetChild(string key)
        {
            foreach(Node child in children)
            {
                if(child.GetDir() == key)
                    return child;
            }
            throw new ArgumentException("Could not find child with key {0}", key);
        }
        public List<Node> GetChildList()
        {
            return children;
        }

        public string GetDir()
        {
            return directory;
        }
        public bool HasParent()
        {
            if(Parent == null)
                return false;
            else
                return true;
        }
        public void AddValue(int val)
        {
            value += val;
        }
        public void AddChild(Node child)
        {
            children.Add(child);
            child.SetParent(this);
        }
        public void SetParent(Node p)
        {
            Parent = p;
        }

        public int CalculateNodeValue()
        {
            int total = value;

            if(this.GetChildList().Count == 0)
            {
                return value;
            }
            else
            {
                foreach(Node child in children)
                {
                    total += child.CalculateNodeValue();
                }
            }
            return total;
        }
    }
}