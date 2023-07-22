def partition(arr, low, high):
     # Choosing the rightmost element as the pivot
    # "pivot" refers to a chosen element from the array around which the elements are partitioned
    # The partitioning process rearranges the elements in such a way that all elements smaller
    # than the pivot are on its left side, and all elements greater than the pivot are on its right side
    
    # Choose the rightmost element as the pivot
    pivot = arr[high]
    i = low - 1

    # Loop through the array to rearrange elements around the pivot
    for j in range(low, high):
        if arr[j] <= pivot:
            i += 1
            # Swap elements to move smaller elements to the left of the pivot
            arr[i], arr[j] = arr[j], arr[i]

    # Place the pivot element in its correct position
    arr[i + 1], arr[high] = arr[high], arr[i + 1]
    # Return the index of the pivot element
    return i + 1

def quickselect(arr, low, high, k):
    if low <= high:
        # Partition the array and get the pivot index
        pivot_idx = partition(arr, low, high)

        # If the pivot is the kth element, return it
        if pivot_idx == k - 1:
            return arr[pivot_idx]

        # If the kth element is on the left of the pivot
        elif pivot_idx > k - 1:
            # Continue the search on the left subarray
            return quickselect(arr, low, pivot_idx - 1, k)

        # If the kth element is on the right of the pivot
        else:
            # Continue the search on the right subarray
            return quickselect(arr, pivot_idx + 1, high, k)

    # Return None if k is out of range or the array is empty
    return None

def find_kth_smallest(arr, k):
    if k > 0 and k <= len(arr):
        # Call the quickselect function to find the kth smallest element
        return quickselect(arr, 0, len(arr) - 1, k)
    else:
        # Return None if k is out of range or the array is empty
        return None

# Example usage:
arr = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5]
k = 4
result = find_kth_smallest(arr, k)
print(f"The {k}th smallest element is: {result}")
