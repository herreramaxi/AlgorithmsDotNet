namespace _5TreesAndGraphs
{
    public class NodeAVL
    {
        public NodeAVL Left { get; set; }
        public NodeAVL Right { get; set; }
        public int Value { get; set; }
        public int Height { get; set; }
        public NodeAVL(int value)
        {
            this.Value = value;
        }
    }
}
