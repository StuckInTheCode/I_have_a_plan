# UML Diagrams

#### [Glossary](glossary.md)

1. [Activity Diagram](#1)<br>
2. [Use Case Diagram](#2)<br>
2.1. [Actors](#1.1)<br>
2.2. [Use Cases](#1.2)<br>
4. [Sequence Diagram](#3)<br>
5. [State Machine Diagram](#4)<br>
6. [Class Diagram](#5)<br>
7. [Component Diagram](#6)<br>
8. [Deployment Diagram](#7)<br>

# 1\. Activity Diagram <a name = "1"></a>

# 2\. Use Case Diagram  <a name = "2"></a>

## 2.1\. Actors  <a name = "1.1"></a><br>
Actor | Description
| :-- | :--
User | A human that use the application

## 2.2\. Use Cases  <a name = "1.2"></a><br>
<a name="sign_in_to_the_app"/>

## 2.2.1 Add the project <a name = "2.2.1"></a>

**Description.** Add the project to the list of users projects.  
**Precondition.** User pressed on the add button on the main page of the application.  
**Main thread.**
1. If count of the project is equal to maximum count, then alternate thread A1 starts executing;
2. Application show the "Adding project" window.
3. User input data to the inpute fields;
4. If not all fields filled, then alternate thread A2 starts executing;
5. If user pressed on the cancel button, then go to the step 9 of the main thread;
6. User pressed on the save button;
7. New project saved to the project list ;
8. "Adding project" window close;
9.  Use case ends.

**Alternate thread A1**
1. Show message about reaching the maximum count of the projects;
2. Use case ends.

**Alternate thread A2**
1. Show message about not filled fields;
2. When message is disappeared, then return to the 3 step of the main thread;
<a/> 
## 2.2.2 Edit the project information <a name = "2.2.2"></a>

**Description.** Edit the information of the current project.
**Precondition.** User pressed on the edit button on the project page of the application.  
**Main thread.**
1. Application show the "Editing project" window.
2. User input data to the inpute fields;
3. If not all fields filled, then alternate thread A1 starts executing;
4. If user pressed on the cancel button, then go to the step 9 of the main thread;
5. User pressed on the save button;
6. New project saved to the project list ;
7. "Editing project" window close;
8.  Use case ends.

**Alternate thread A1**
1. Show message about not filled fields;
2. When message is disappeared, then return to the 2 step of the main thread;
<a name="log_in_to_your_account"/>

## 2.2.3 Delete the project <a name = "2.2.3"></a>

**Description.** Delete the project from the users project list.  
**Precondition.** User pressed on the delete button on the project page of the application.  
**Main thread.**
1. Application show the dialog window;
2. If user pressed on the cancel button, then go to the step 5 of the main thread;
3. User pressed on the ok button;
4. Project deleted from the project list;
5.  Use case ends.
<a name="rendering_diagram"/>

## 2.2.4 Add project tasks <a name = "2.2.4"></a>
**Description.** Add the task to the task list of the current project.  
**Precondition.** User pressed on the add button on the project page of the application.  
**Main thread.**
1. If count of the task is equal to maximum count, then alternate thread A1 starts executing;
2. Application show the "Adding task" window.
3. User input data to the inpute fields;
4. If not all fields filled, then alternate thread A2 starts executing;
5. If user pressed on the cancel button, then go to the step 9 of the main thread;
6. User pressed on the save button;
7. New task saved to the task list ;
8. "Adding task" window close;
9.  Use case ends.

**Alternate thread A1**
1. Show message about reaching the maximum count of the project tasks;
2. Use case ends.

**Alternate thread A2**
1. Show message about not filled fields;
2. When message is disappeared, then return to the 3 step of the main thread;
<a name="users_config"/>

## 2.2.5 Edit project tasks <a name = "2.2.5"></a>

**Description.** Edit the information of the project task.
**Precondition.** User pressed on the edit button on the task widget on the project page of the application.  
**Main thread.**
1. Application show the "Editing task" window.
2. User input data to the inpute fields;
3. If not all fields filled, then alternate thread A1 starts executing;
4. If user pressed on the cancel button, then go to the step 9 of the main thread;
5. User pressed on the save button;
6. New project saved to the project list ;
7. "Editing task" window close;
8.  Use case ends.

**Alternate thread A1**
1. Show message about not filled fields;
2. When message is disappeared, then return to the 2 step of the main thread;
<a name="log_in_to_your_account"/>

## 2.2.6 Delete project tasks <a name = "2.2.6"></a>

**Description.** Delete the task from the project task list.  
**Precondition.** User pressed on the delete button on the task widget on the project page of the application.  
**Main thread.**
1. Application show the dialog window;
2. If user pressed on the cancel button, then go to the step 5 of the main thread;
3. User pressed on the ok button;
4. Task deleted from the task list;
5.  Use case ends.
<a name="rendering_diagram"/>

## 2.2.7 Change the notification format <a name = "2.2.7"></a>

**Description.** Change the format of the notification.  
**Precondition.** Options window is open.   
**Main thread.**
1. User change the state of the notification format ComboBox;
2. Set the new notification format;
3. Use case ends.

<a name="sign_out_of_your_account"/>

## 2.2.8 Change the notification period <a name = "2.2.8"></a>

**Description.** Change the period of the notification.  
**Precondition.** Options window is open.   
**Main thread.**
1. User change the state of the notification period ComboBox;
2. Set the new notification period;
3. Use case ends.


<a name="sign_out_of_your_account"/>

## 2.2.9 Change the end of the working time <a name = "2.2.9"></a>


**Description.** Change the end of the working time.  
**Precondition.** Options window is open.   
**Main thread.**
1. User change the state of end of the working time ComboBox;
2. Set the new notification end time;
3. Use case ends.

<a name="sign_out_of_your_account"/>

## 2.2.10 Change the start of the working time <a name = "2.2.10"></a>

**Description.** Change the start of the working time.  
**Precondition.** Options window is open.   
**Main thread.**
1. User change the state of start of the working time ComboBox;
2. Set the new notification start time;
3. Use case ends.

<a name="sign_out_of_your_account"/>

## 2.2.11 Done daily task <a name = "2.2.11"></a>


**Description.** Checked the performence of the daily task.  
**Precondition.** Count of the daily task is greater then zero.   
**Main thread.**
1. User change the state of the task CheckBox;
2. If checkBox change state from "Checked" to "Unchecked", then alternate thread A1 starts executing;
3. Increase percentage of days with this task finished;
4. Use case ends.

**Alternate thread A1**
5. Decrease percentage of days with this task finished;
6. Use case ends.

<a name="sign_out_of_your_account"/>


# 3\. Sequence Diagram <a name = "3"></a>

# 4\. State Machine Diagram<a name = "4"></a>

# 5\. Class Diagram <a name = "5"></a>

# 6\. Component Diagram <a name = "6"></a>

# 7\. Deployment Diagram <a name = "7"></a>


> Written with [StackEdit](https://stackedit.io/).
