
# Test plan

## Content
1 [Introduction](#1)</br>
2 [Test Items](#2)</br>
3 [Risk Issues](#3)</br>
4 [Features to be tested](#4)</br>
5 [Test Approach](#5)</br>
6 [Results](#6)</br>
7 [Conclusion](#7)</br>

 
# 1 <a name = "1"> Introduction </a>
This document represent the Test Plan developed for the mobile version of the cross-platform application "I have a plan!"</br>
The main purpose of testing – verification of the functionality and suitability of the application.

# 2 <a name = "2"> Test Items </a></br>
"I have a plan!" is created for planning project development and notifying the user about current tasks

#### Quality attributes (ISO 25010):</br>
<br>1. Functional Suitability</br>

- Functional completeness;
- Functional correctness;
- Functional appropriateness.

<br>2. Usability </br>

- Operability. 
- User error protection. 
- User interface aesthetics.
- Accessibility.</br>

# 3 <a name = "3"> Risk Issues </a></br>
- Storage of phone is almost full (not enough space to store application data);
- Unsupported version of Android.

# 4 <a name = "4"> Features to be tested </a>

Test plan include check correctness of implementation followed main functionality:

- <b>Adding project </b></br>
This use case should be tested on:
	1. Project count is less than 50 and project name is not empty
	2. Project count is less than 50 and project name is empty
	3. Project count is equal to 50
- <b>Editing project information</b></br>
This use case should be tested on:
	1. Project name is not empty
	2. Project name is empty
- <b>Delete project</b></br>
 - <b>Set the project deadline date at adding project page</b></br>
This use case should be tested on:
	1. Deadline date is later than begininng date and current date
	2. Deadline date is earlier than begininng date and current date
- <b>Set the project begininng date at adding project page</b></br>
This use case should be tested on:
	1. Begininng date is earlier than deadline date and current date
	2. Begininng date is later than deadline date and current date
- <b>Set the project deadline date at editing project page</b></br>
This use case should be tested on:
	1. Deadline date is later than begininng date and current date
	2. Deadline date is earlier than begininng date and current date
- <b>Set the project begininng date at editing project page</b></br>
This use case should be tested on:
	1. Begininng date is earlier than deadline date and current date
	2. Begininng date is later than deadline date and current date
- <b>Adding task </b></br>
This use case should be tested on:
	1. Tasks count is less than 50 and project name is not empty
	2. Tasks count is less than 50 and project name is empty
	3. Tasks count is equal to 50
- <b>Editing task information</b></br>
This use case should be tested on:
	1. Project name is not empty
	2. Project name is empty
- <b>Delete task </b></br>
- <b>Change notification format </b></br>
- <b>Change the period of notification</b></br>
- <b>Change the start time to another value </b></br>
This use case should be tested on:
	1. Earlier than end time
	2. Later than end time
- <b>Change the end time to another value</b></br>
This use case should be tested on:
	1. Later than start time
	2. Earlier than start time
- <b>Change state of the task</b></br>
This use case should be tested on:
	1. Task change state from not done to done
	2. Task change state from done to not done

It is also important to check correctness of non- functional requirements:

- Usability:
	All functional elements of the user interface have names describing the action that the element does and the contrast between the colors of the font, functional elements and background should ensure a comfortable user experience with the application.
- External interfaces:
  Font size not less than 13 pt,  functional elements must be equal in size or larger than the main text on the screen</br>

# 5 <a name = "5"> Test Approach </a>
The application will be tested manually.

# 6 <a name = "6"> Pass / Fail Criteria </a>
Results of testing are represented in [this document](TestResults.md)

# 7 <a name = "7"> Conclusion </a>
This test plan allows to test the main functionality of the application. Successful completion of the test plan does not guarantee full operability, allows to believe that the app works correctly.</br>

> Written with [StackEdit](https://stackedit.io/).
