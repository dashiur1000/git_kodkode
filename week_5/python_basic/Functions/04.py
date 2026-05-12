def is_palindrome(s):
    a = True
    for i in range(len(s)):
        if s[i] != s[-(i+1)]:
            a = False
    return a



print(is_palindrome("duud"))