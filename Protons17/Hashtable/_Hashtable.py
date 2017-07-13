from Hashtable.LinkedList import LinkedList


class Hashtable:
    """
    A hashtable is simply a table or a dictionary that
        stores (maps) key, values pairs.

    This implementation avoids collisions using the chaining technique.
    """

    def __init__(self):
        """
        Initialize capacity and data list.
        """
        self.capacity = 10
        self.__data = [None] * self.capacity

    def hash(self, key):
        prehash = 0
        for c in key:
            prehash += ord(c)
        return prehash % self.capacity

    def insert(self, key, value):
        """
        Inserts a (key, value )pair to the hashtable.

        Algorithm:
            1) Get the index using the hash value of the key
            2) Look at data[index]. If empty initialize a new linked list.
            3) Insert the (key, value) pair into the linked list.

        -- Note that the new node is created inside the linked list class.
        """
        index = self.hash(key)

        if self.__data[index] is None:
            self.__data[index] = LinkedList()

        ll = self.__data[index]
        ll.insert(key, value)

    def get(self, key):
        """
        Searches for a value in the hashtable using the key.

        Algorithm:
            1) Get the index using the hash value of the key
            2) Look at data[index]. If empty, then return `None`.
                Else search for the key in the linked list.

        :return: Returns value associated with the key if found, else `None`.
        """
        index = self.hash(key)
        ll = self.__data[index]

        if ll is not None:
            return ll.search(key)

        return None

    def delete(self, key):
        """
        Delete a value from the hashtable using the key.

        Algorithm:
            1) Get the index using the hash value of the key
            2) Look at data[index]. If not empty, look for the key in the linked list.
                If found delete the node, else print error message.
        """
        index = self.hash(key)
        ll = self.__data[index]

        if ll is not None:
            ll.delete(key)


h = Hashtable()
# 'stop' and 'post' have the same hash according to
#     our choice of the hash function
h.insert('stop', 1)
h.insert('post', 2)
h.insert('moon', 3)

print(h.get('post'))
print(h.get('stop'))
print(h.get('moon'))

h.delete('moon')

print(h.get('moon'))
