# Player can choose the input file. The input string should look like "test1.txt".

# After choose the input file, please press the enter key.

# The info that display in the console include word grid, mode and the search results. One console display example is showed below:

							Please enter file name:

											 There are four files that can be choosed:
															 test1.txt
															 test2.txt
															 test3.txt
															 test4.txt
							test1.txt


							PUZZLE

							A B C

							D E F

							G H I

							Mode -- NO_WRAP


							Words need to search:
							FED
							CAB
							GAD
							BID
							HIGH


							Here is the search result:

							(1,2)(1,0)
							NOT FOUND
							NOT FOUND
							NOT FOUND
							NOT FOUND



# The content of the four files are:

test1.txt

3 3
ABC
DEF
GHI
NO_WRAP
5
FED
CAB
GAD
BID
HIGH

test2.txt

4 3
ABC
DEF
GHI
JKL
WRAP
5
FED
CAB
AEIJBFG
LGEC
HIGH

test3.txt

3 3
ABC
DEF
GHI
WRAP
9
FED
CAB
GAD
BID
HFA
HFD
HIGH
HIGHI
HIGHIG

test4.txt

3 4
ABCJ
DEFK
GHIL
NO_WRAP
10
FE
AB
IL
CBA
CAB
GAD
BID
FED
BIK
HIGH