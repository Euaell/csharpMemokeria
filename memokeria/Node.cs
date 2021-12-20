namespace memokeria
{
    class Node{
        public Node Left,Right;
        public int Data;
        public Node(int data){
            this.Data=data;
            Left=Right=null;
        }
    }
}