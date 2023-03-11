# ProjGlidepath
This is the project for technical test of Glidepath.

# requirements for the project

1.  Ask the user to enter a number.
2.  Read the previous number that was written to disk by the program the previous time it ran.
3.  Add the entered number to the previous number. This will give you a total number. 
4.  If the total number is greater than 152 then subtract 152 from the total number.
5.  Display the total number to the user.
6.  Save the total number to disk.
7.  Exit.
Here are some example inputs and outputs
 '''
| Previous value in file | User input value | Calculations | New value in file |
|------------------------|------------------|--------------|-------------------|
|                        | 5                | +5           | 5                 |
|5                       | 9                | +9           | 14                |
|14                      | 130              | +130         | 144               |
|144                     | 20               | +20, -152    | 12                |
|12                      | 1                | +1           | 13                |
'''

## related libraries or tools version

1. Visual Studio : 2022
2. .Net 6.0

## description of sub-projects

1. CalcLib: main source code.
2. UnitTest: unit tests for the project CalcLib.
3. ProjGlidepath: Console application.

## Getting Started

To get started with this project, you will need to have Visual Studio installed on your machine.

1. Clone this repository to your local machine.
2. Open the project solution file in Visual Studio.
3. Build and run the project.

