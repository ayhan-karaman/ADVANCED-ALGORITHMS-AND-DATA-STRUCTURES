using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedLists
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        private bool isHeadNull => Head == null;
        private bool isTailNull => Tail == null;
        public DoublyLinkedList()
        {
            
        }
        public DoublyLinkedList(IEnumerable<T> collection)
        {
              foreach (var item in collection)
                AddLast(item);
        }

        public void AddFirst(T value)
        {
             var newNode = new DoublyLinkedListNode<T>(value);
             if(Head != null)
             {
                Head.Prev = newNode;
             }
             newNode.Next = Head;
             newNode.Prev = null;
             Head = newNode; 
             if(isTailNull)
             {
                 Tail = Head;
             }  
        }

        public void AddLast(T value)
        {
            if(Tail is null)
            {
                 AddFirst(value);
                 return;
            }
            var newNode =new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;
            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;
            return;
        }
  
        public void AddAfter(DoublyLinkedListNode<T> refNode, T value) 
        => AddAfter(refNode, new DoublyLinkedListNode<T>(value));

        public void AddBefore(DoublyLinkedListNode<T> refNode, T value) 
        => AddBefore(refNode, new DoublyLinkedListNode<T>(value));

        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if(refNode == null)
                throw new ArgumentNullException();
            if(refNode == Tail && refNode == Head)
            {
                   refNode.Next = newNode;
                   refNode.Prev = null;

                   newNode.Next = null;
                   newNode.Prev = Head;

                   Head = refNode;
                   Tail = newNode;
                   return;
            }
            if(refNode != Tail)
            {
                 newNode.Next = refNode.Next;
                 newNode.Prev = refNode;
                 
                 refNode.Next.Prev = newNode;
                 refNode.Next = newNode;

            }
            else
            {
                  newNode.Prev = refNode;
                  newNode.Next = null;

                  refNode.Next = newNode;
                  Tail = newNode;
                  return;
            }
             
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
             if(refNode == null)
                throw new ArgumentNullException();
            if(refNode == Tail && refNode == Head)
            {
                  newNode.Next = refNode;
                  newNode.Prev = null;

                  Head.Prev = newNode;
                  Head = newNode;
                  return;
            }
            if(refNode != Head)
            {
                 newNode.Next = refNode;
                 newNode.Prev = refNode.Prev;

                 refNode.Prev.Next = newNode;
                 refNode.Prev = newNode;
                return;
            }
            else
            {
                  newNode.Next = refNode;
                  newNode.Prev = null;

                  refNode.Prev = newNode;
                  Head = newNode;
                  return;
            }
        }
        
        public T RemoveFirst()
        {
             if(isHeadNull)
                throw new Exception();
            var temp = Head.Value;
            if(Head == Tail)
            {
                 Head = null;
                 Tail = null;
                 
            }
            else
            {
                   Head = Head.Next;
                   Head.Prev = null;

            }
            return temp;
        }
       
        public T RemoveLast()
       {
            if(isTailNull)
                throw new Exception();
            var temp = Tail.Value;
            if(Tail == Head)
            {
                Tail = null;
                Head = null;
            }
            else
            {
                  Tail.Prev.Next = null;
                  Tail = Tail.Prev;
            }
            return temp;
       }

        public void Remove(T value)
        {
            if(isHeadNull)
                throw new Exception("Empty list.");
            
            // Tek eleman
            if(Head == Tail)
            {
                 if(Head.Value.Equals(value))
                    RemoveFirst();
                return;
            }

            // en az iki eleman
            var current = Head;
            while (current != null)
            {
                if(current.Value.Equals(value))
                {
                    // current -> ilk eleman
                    if(current.Prev == null)
                    {
                         current.Next.Prev = null;
                         Head = current.Next;
                    }
                    // current -> son eleman
                    else if(current.Next == null)
                    {
                         current.Prev.Next = null;
                         Tail = current.Prev;
                    }
                    else
                    {
                         current.Prev.Next = current.Next;
                         current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        
        }
        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}