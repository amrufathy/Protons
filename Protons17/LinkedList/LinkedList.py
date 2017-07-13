class Node:
    """
    A node is a user defined class which carries the data
        and a reference to the next node.
    """

    def __init__(self, data, next):
        self.data = data
        self.next = next


class LinkedList:
    """
    A linked list is a data structure which contains a list of
        nodes that are linked together through references.
    """

    def __init__(self):
        """
        Initialize the first node in the list
            to `None`.
        """
        self.head = None

    def insert(self, item):
        """
        Insert a node at the end of the list.

        We loop through the nodes until we find the last one
            (ie. the node that its next is `None`).

        Once we find the last node, we set its next to be
            the new node.

        :param item: data to be inserted.
        """
        temp_node = self.head
        new_node = Node(item, None)

        if temp_node is None:
            self.head = new_node
        else:
            while temp_node.next is not None:
                temp_node = temp_node.next

            temp_node.next = new_node

    def search(self, item):
        """
        Searches through the nodes for the item. If the last node is
            reached, then the item isn't in the list.

        :param item: Item we search for.
        :return: Return the data if found, `None` otherwise.
        """
        temp_node = self.head

        while temp_node is not None:
            if temp_node.data == item:
                return temp_node.data

            temp_node = temp_node.next

        return None

    def delete(self, item):
        """
        Deletes a node with item from the list.

        In this function, we need to keep a reference for the
            previous node and the current node.

        We loop through the nodes searching for the required it.
        If found, we set previous.next to current.next.

        -- Note that previous.next is equivalent to current, but we use
            previous.next since we have to set the `next` variable.

        :param item: Item to be deleted.
        """
        current, previous = self.head, None
        while current:
            if current.data == item:
                break
            else:
                previous = current
                current = current.next

        if current is None:  # not found
            print('Error, data not present in list.')
        if previous is None:  # removing the head
            self.head = current.next
        else:
            previous.next = current.next

    def print(self):
        temp_node = self.head

        while temp_node is not None:
            print(temp_node.data)
            temp_node = temp_node.next


ll = LinkedList()
ll.insert(5)  # insert 5
ll.insert(7)  # insert 7
ll.insert(8)  # insert 8

print('>' * 10)
ll.print()  # print list
print('<' * 10)

print(ll.search(6))  # `None`
print(ll.search(5))  # 5
ll.delete(5)  # delete 5

print('>' * 10)
ll.print()  # print list
print('<' * 10)
