﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private ListNode listNode;
        private ListNode head;
        private ListNode tail;

        public List<ListNode> ListNodes { get; set; }
        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.tail = this.head = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            Count++;
        }

        public int RemoveFirst(int element)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            int count = 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                array[count] = currentNode.Value;
                currentNode = currentNode.NextNode;
                count++;
            }

            return array;
        }
    }
}
