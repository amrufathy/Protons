class Queue:
    """
    Remember how the queue works, we can only add or
        remove an item (object) from the front of the queue.

    Queue is called a FIFO data structure.
        (First in First out)

    Which means when getting an item from the queue, you get
        the first inserted item.
    """

    def __init__(self):
        """
            Initialize data list to be empty.
        """
        self.__data = []

    def enqueue(self, item):
        """
        Enqueue (Insert) item to front of the queue.

        :param item: Item to be added.
        """
        self.__data.append(item)

    def dequeue(self):
        """
        Dequeque (Remove and return) item from the front of the queue.

        -- Remember dequeue() removes the item AND returns it.

        -- We need to check if the queue is empty first.

        This works by using the built in function pop(0)
            on the data list, which pops the first item.

        :return: Item removed from the front of the queue
        """
        if not self.empty():
            return self.__data.pop(0)

        return None

    def peek(self):
        """
        Returns item from the front of the queue, WITHOUT removing it.

        -- peek() works like pop(), it returns the front of the queue.
            The difference is pop() deletes the item from the queue while peek() doesn't.

        -- We need to check if the queue is empty first.

        :return: Item at the front of the queue
        """
        if not self.empty():
            return self.__data[0]

        return None

    def empty(self):
        """
        Checks if the queue is empty or not.

        :return: `True` is the queue is empty, `False` otherwise.
        """
        return self.size() == 0

    def size(self):
        """
        Gets the length of the data list which represents the
            number of items in the queue.

        :return: number of items in the queue.
        """
        return len(self.__data)

    def clear(self):
        """
        Clears the data list which makes the queue empty.
        """
        self.__data = []


q = Queue()

print(q.empty())  # True
q.enqueue(4)  # enqueue 4
q.enqueue('dog')  # enqueue 'dog'
print(q.peek())  # 4
q.enqueue(True)  # enqueue True
print(q.size())  # 3
print(q.empty())  # False
q.enqueue(8.4)  # enqueue 8.4
print(q.dequeue())  # 4
print(q.dequeue())  # 'dog'
print(q.size())  # 2
