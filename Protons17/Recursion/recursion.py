"""
Factorial

Both iterative and recursive versions are O(n)
"""


# iterative
def factorial_iter(n):
    prod = 1
    for i in range(1, n + 1):
        prod *= i
    return prod


# recursive
def factorial_rec(n):
    if n == 1:
        return 1
    return n * factorial_rec(n - 1)


def test_factorial(n):
    print('Iterative: ', factorial_iter(n))
    print('Recursive: ', factorial_rec(n))


"""
Fibonacci

Iterative version is O(n), but recursive version is O(2^n)
"""


# iterative
def fibonacci_iter(n):
    a, b = 0, 1
    for i in range(0, n):
        a, b = b, a + b
    return a


# recursive
def fibonacci_rec(n):
    if n == 0 or n == 1:
        return n
    return fibonacci_rec(n - 1) + fibonacci_rec(n - 2)


# recursive with dynamic programming (save previous results)
fib = [0, 1]
def fibonacci_dp(n):
    if n >= len(fib):
        fib.append(fibonacci_dp(n - 1) + fibonacci_dp(n - 2))

    return fib[n]


def test_fibonacci(n):
    print('Iterative: ', fibonacci_iter(n))
    print('Recursive: ', fibonacci_rec(n))
    print('Dynamic programming: ', fibonacci_dp(n))


"""
Binary search

Both iterative and recursive versions are O(log2(n))
"""


def binary_search_iter(array, target):
    low, high = 0, len(array)
    while low < high:
        mid = low + (high - low) // 2
        if target == array[mid]:
            return mid
        elif target > array[mid]:
            low = mid + 1
        elif target < array[mid]:
            high = mid


def binary_search_rec(array, target, low, high):
    mid = low + (high - low) // 2

    if low >= high:
        return None
    elif array[mid] == target:
        return mid
    elif array[mid] < target:
        return binary_search_rec(array, target, mid + 1, high)
    elif array[mid] > target:
        return binary_search_rec(array, target, low, mid)


def test_binary_search():
    array = list(range(0, 10))
    target = 15
    print('Iterative: ', binary_search_iter(array, target))
    print('Recursive: ', binary_search_rec(array, target, 0, len(array)))


"""
How many ways to go from a corner to
    the opposite one in a grid

Backtracking problem, it is O(2^n)
"""


def backtrack(m, n):
    if m == 1 or n == 1:
        return 1
    return backtrack(m - 1, n) + backtrack(m, n - 1)
