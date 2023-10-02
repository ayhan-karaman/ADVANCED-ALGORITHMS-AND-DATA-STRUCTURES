using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedLists
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null;

        public SinglyLinkedList()
        {}
        public SinglyLinkedList(IEnumerable<T> collection)
        {
             AddLastRange(collection);
        }
        public void AddFirstRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
              AddFirst(item);
        }
       
        public void AddFirst(T value)
        {
             var newNode = new SinglyLinkedListNode<T>(value);
             newNode.Next = Head;
             Head = newNode;
        }

        public void AddLast(T value)
        {
              var newNode = new SinglyLinkedListNode<T>(value);
              if(Head == null)
               {
                   Head = newNode;
                   return;
               }
              var prev = Head;
              while (prev.Next != null)
              {
                    prev = prev.Next;
              }
              prev.Next = newNode;
        }
    
        public void AddLastRange(IEnumerable<T> collection)
        {
                foreach (var item in collection)
                    AddLast(item);
        }
        
        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            //   if(node == null)
            //      throw new ArgumentNullException();
            //   if(isHeadNull)
            //   {
            //       AddFirst(value);
            //       return;
            //   }

             var newNode = new SinglyLinkedListNode<T>(value);
             AddAfter(node, newNode);
            //  var current = Head;
            //  while (current.Next != null)
            //  {
            //     if(current.Equals(node))
            //     {
            //           newNode.Next = current.Next;
            //           current.Next = newNode;
            //           return;
            //     }
            //     current = current.Next;
            //  }
            // throw new ArgumentException("The reference node is not in this list.");
        }
        
        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if(refNode == null)
                 throw new ArgumentNullException();
            if(isHeadNull)
              {
                  Head = newNode;
                  return;
              }

             var current = Head;
             while (current != null)
             {
                if(current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
             }
            throw new ArgumentException("The reference node is not in this list.");
        }
        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
                
            //     if(node == null)
            //      throw new ArgumentNullException();
            //   if(isHeadNull)
            //   {
            //       AddFirst(value);
            //       return;
            //   }

            var newNode = new SinglyLinkedListNode<T>(value);
            AddBefore(node, newNode);
            //      var current = Head;
            //      while (current.Next != null)
            //      {
            //           if(current.Next.Equals(node))
            //           {
            //              newNode.Next = current.Next;
            //              current.Next = newNode;
            //              return;
            //           }
            //           current = current.Next;
            //      }
            //     throw new ArgumentException("The reference node is not in this list.");

        }
        
        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
              if(refNode == null)
                 throw new ArgumentNullException();
              if(isHeadNull)
              {
                  Head = newNode;
                  return;
              }
             var current = Head;
             SinglyLinkedListNode<T> prev = null;
             while (current != null)
             {
                if(current.Equals(refNode))
                {
                    if(current.Equals(Head))
                    {
                        newNode.Next = current;
                        Head  = newNode;
                        return;
                    }
                    newNode.Next = current;
                    prev.Next = newNode;
                    return;
                }
                prev = current;
                current = current.Next;
             }
              throw new ArgumentException("The reference node is not in this list.");
        }

        public T RemoveFirst()
        {
            if(isHeadNull)
                throw new Exception("Underflow! Nothing to remove");
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }
        public T RemoveLast()
        {
             if(isHeadNull)
                throw new Exception("Underflow! Nothing to remove");
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next;
            prev.Next = null;
            return lastValue.Value;
        }
        
        public void Remove(T value)
        {
            if(isHeadNull)
                throw new Exception("Underflow! Nothing to remove");
            if(value == null) 
                throw new ArgumentNullException();

            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            do
            {
                if(current.Value.Equals(value))
                {
                        // Son eleman mı?
                        if(current.Next == null)
                        {
                            // Head silinmek isteniyordur.
                            if(prev == null)
                            {
                                  Head = null;
                                  return;
                            }
                            else
                            {
                                prev.Next = null;
                                return;
                            }
                        }
                        else
                        {
                             // Head
                            if(prev == null)
                            {
                                Head = Head.Next;
                                return;
                            }
                            // ara düğüm
                            else
                            {
                                prev.Next = current.Next;
                                //current = null;
                                return;
                            }
                        }
                }
                else
                {
                    prev  = current;
                    current = current.Next;
                }
            } while (current != null);
            throw new ArgumentException("The value could not be found in the list!");
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}