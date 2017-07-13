class Stack:
    """
    Remember how the stack works, we can only add or
        remove an item (object) from the top of the stack.

    Stack is called a LIFO data structure.
        (Last in First out)

    Which means when getting an item from the stack, you get
        the last inserted item.
    """

    def __init__(self):
        """
        Initialize data list to be empty.
        """
        self.__data = []

    def push(self, item):
        """
        Push item to the top of the stack.

        This works by adding an item to the end of
            the data list.

        :param item: item to be pushed
        """
        self.__data.append(item)

    def pop(self):
        """
        Pop item from the top of the stack.

        -- Remember pop() removes the item AND returns it.

        -- We need to check if the stack is empty first.

        This works by using the built in function pop()
            on the data list.

        :return: Item removed from the top of the stack
        """
        if not self.empty():
            return self.__data.pop()

        return None

    def peek(self):
        """
        Returns item from the top of the stack, WITHOUT removing it.

        -- peek() works like pop(), it returns the top of the stack.
            The difference is pop() deletes the item from the stack while peek() doesn't.

        -- We need to check if the stack is empty first.

        :return: Item at the top of the stack
        """
        if not self.empty():
            last_item_index = len(self.__data) - 1
            return self.__data[last_item_index]

        return None

    def empty(self):
        """
        Checks if the stack is empty or not.

        :return: `True` is the stack is empty, `False` otherwise.
        """
        return self.size() == 0

    def size(self):
        """
        Gets the length of the data list which represents the
            number of items in the stack.

        :return: number of items in the stack.
        """
        return len(self.__data)

    def clear(self):
        """
        Clears the data list which makes the stack empty.
        """
        self.__data = []


s = Stack()

print(s.empty())  # True
s.push(4)  # push 4
s.push('dog')  # push 'dog'
print(s.peek())  # 'dog'
s.push(True)  # push True
print(s.size())  # 3
print(s.empty())  # False
s.push(8.4)  # push 8.4
print(s.pop())  # 8.4
print(s.pop())  # True
print(s.size())  # 2
