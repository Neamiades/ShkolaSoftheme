namespace ConsoleLinkedListApp
{
    class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Prev;

        public Node() { }

        public Node(T data) => Data = data;
    }
}
