# Knight's Tour

A **knight's tour** is a sequence of moves of a knight on a chessboard such that the knight visits every square only once.

While a decent math problem and often an interview question, it can be solved via brute force, heuristics and even neural networks. But, we're not here to focus on that - were here to focus on the cryptological benefits of using a **knight's tour** to create ciphertext... and to reveal plaintext.

### Approaches

This project will build possible tours on a chessboard of specified dimensions using different approaches. We plan to implement the following selectable approaches:

- Brute Force

    This is by far the easiest method of finding a tour; at least, the easiest to code =P. For a standard-sized chessboard (8x8), this approach is unrealistic in terms of time.

- Backtracking

    Using a backtrack approach, where we incrementally recurse through stages to find viable vectors, we can build lists of possible tours. The problem we'll face with backtracking is we may always generate the _same_ tour given a set size of the board.

- Heuristics (Warnsdorff's Algorithm)

    This approach will use basic graph theory and heuristics to tour the board via the route with the minimum jump accessibility in each move. This approach should provide a linear-time solution to finding tours.

