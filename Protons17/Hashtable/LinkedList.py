"""
This is the same linked list implementation, but the
    node has a (key, value) pair now.
"""


class Node:
    def __init__(self, key, value, next):
        self.key = key
        self.value = value
        self.next = next


class LinkedList:
    def __init__(self):
        self.head = None

    def insert(self, key, value):
        temp_node = self.head
        new_node = Node(key, value, None)

        if temp_node is None:
            self.head = new_node
        else:
            while temp_node.next is not None:
                temp_node = temp_node.next

            temp_node.next = new_node

    def search(self, key):
        temp_node = self.head

        while temp_node is not None:
            if temp_node.key == key:
                return temp_node.value

            temp_node = temp_node.next

        return None

    def delete(self, key):
        current, previous = self.head, None
        while current:
            if current.key == key:
                break
            else:
                previous = current
                current = current.next

        if current is None:
            print('Error, data not present in list.')
        if previous is None:
            self.head = current.next
        else:
            previous.next = current.next
