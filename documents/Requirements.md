# Requirements Document

### Table of Contents

1. [Introduction](#1)<br>
	1.1. [Purpose](#1.1) <br>
	1.2. [Business requirements](#1.2) <br>
		1.2.1. [Initial data](#1.2.1) <br>
		1.2.2. [Business opportunities](#1.2.2) <br>
	1.3. [Analogues](#1.3) <br>
2. [User Requirements](#2) <br>
	2.1. [Software Interfaces](#2.1) <br>
  	2.2. [User Interfaces](#2.2) <br>
  	2.3. [User Characteristics](#2.3) <br>
  	2.4. [Assumptions and Dependencies](#2.4) <br>
3. [System Requirements](#3.) <br>
  	3.1. [Functional Requirements](#3.1) <br>
  		3.1.1. [Basic functionality](#3.1.1) <br>
  			3.1.1.1. [Processing project progress](#3.1.1.1)<br>
  			3.1.1.2. [Done daily tasks](#3.1.1.2)<br>
  			3.1.1.3. [Adding project](#3.1.1.3)<br>
  			3.1.1.4. [Deleting project](#3.1.1.4)<br>
  			3.1.1.5. [Editing project information](#3.1.1.5)<br>
  			3.1.1.6  [Adding project tasks](#3.1.1.6)<br>
  			3.1.1.7  [Editing project tasks](#3.1.1.7)<br>
  			3.1.1.8  [Deleting project tasks](#3.1.1.8)<br>
  			3.1.1.9  [Сustomize notifications](#3.1.1.9)<br>
  		3.1.2. [Limitations and Exceptions](#3.1.2)<br>
  	3.2. [Non-Functional Requierements](#3.2) <br>
   		3.2.1. [Software Quality Attributes](#3.2.1) <br>
    		3.2.1.1. [Usability](#3.2.1.1)<br>
    	3.2.2. [External Interfaces](#3.2.2)<br>

## 1\. Introduction <a name = "1"></a>

### 1.1\. Purpose <a name = "1.1"></a>
This document contains functional and non-functional requirements for the cross-platform application "Have a plan!" for Android 8.0 and higher and UWP (target platform - Windows 10, version 1803) . This document is intended for a team that will implement and verify the correctness of the application.

### 1.2\. Business requirements<a name = "1.2"></a>

#### 1.2.1\. Initial data <a name = "1.2.1"></a> 
Specialists in various fields of activity and students create various projects, work on which takes a large amount of time. For productive work on such projects it is necessary to draw up and adhere to a work plan. And often, when there are a lot of projects, people are distracted by less important tasks and misplaced their time.

#### 1.2.2\. Business opportunities <a name = "1.2.2"></a>
Many people, who are planning to work on a certain project, want an application that will have the capacity to plan the execution of project tasks and notify the user of the need for work. Such software products allow you to free up more time for direct work on tasks, as well as encourage the user to perform them. The designed user interface should allow the application to be used by people with minimal technical knowledge.

### 1.3\. Analogues<a name = "1.3"></a>
Main differences from analogues – a small set of functions, displaying the duration of the project in the calendar of the application, the ability to notify the user<br>

- <b> GanttMan by [Martin Douděra] https://play.google.com/store/apps/details?id=com.doudera.ganttman </b><br>  

	GanttMan is a tool for planning and managing projects on your mobile device. Only daily planning is supported to ensure compatibility with the GanttProject application.
	- Not user friendly timeline view
	- Don't have notification feature

- <b> Wrike by [Wrike inc.] https://play.google.com/store/apps/details?id=com.wrike</b><br> 

	Wrike is a cloud-based project management, planning and team work tool. The application is used by small and medium-sized businesses and corporations that are on the Fortune 500 list. For the third consecutive year, Wrike has been included in the Deloitte list of the fastest growing US companies in Technology Fast 500 ™.
	- Professional instrument for bussiness;
	- Works with internet access  

- <b>Progress of project by [chomoranma] https://play.google.com/store/apps/details?id=jp.moo.myworks.progressofproject</b><br> 

	Simple project's progress management apps. The achievement rate of project is calculated automatically.  
	- Don't have notification feature

## 2\. User Requirements <a name = "2"></a>

### 2.1\. Software Interfaces <a name="2.1"></a>
The Xamarin framework and packages of plugins and libraries provided by NuGet will be used.

### 2.2\. User Interfaces <a name="2.2"></a>
Graphical user interface is represented by mockup images.

<p align = "center">
<img width = "450" height = "580" src = "https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Icon.png?raw=true">
</p>

<p align = "center">
Figure 1. Icon of the application<br>
</p>

<p align = "center">
<img width = "450" height = "580" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Adding%20a%20project_Android.png?raw=true">
</p>

<p align = "center">
Figure 2. Project adding screen on Android<br>
</p>


<p align = "center">
<img width = "496" height = "463" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Adding_a_project_screen_UWP.png?raw=true">
</p>

<p align = "center">
Figure 3. Project adding screen on Windows<br>
</p>

<p align = "center">
<img width = "450" height = "580" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Adding_a_task_Android.png?raw=true">
</p>

<p align = "center">
Figure 4. Task adding screen on Android<br>
</p>

<p align = "center">
<img width = "496" height = "376" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Adding_a_task_screen_UWP.png?raw=true">
</p>

<p align = "center">
Figure 5. Task adding screen on Windows<br>
</p>

<p align = "center">
<img width = "496" height = "336" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Calendar_UWP.png?raw=true">
</p>

<p align = "center">
Figure 6.   Display of the calendar on the screen<br>
</p>

<p align = "center">
<img width = "450" height = "580" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Main_screen_Android.png?raw=true">
</p>

<p align = "center">
Figure 7. Main screen on Android<br>
</p>

<p align = "center">
<img width = "450" height = "580" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Main_screen_tasks_Android.png?raw=true">
</p>

<p align = "center">
Figure 8. Today tasks on Android<br>
</p>
<p align = "center">
<img width = "496" height = "336" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Main_screen_UWP.png?raw=true">
</p>

<p align = "center">
Figure 9. Main screen and today tasks on Windows<br>
</p>

<p align = "center">
<img width = "450" height = "580" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Options_Android.png?raw=true">
</p>

<p align = "center">
Figure 10. Options screen on Android<br>
</p>
<p align = "center">
<img width = "496" height = "336" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Options_UWP.png?raw=true">
</p>

<p align = "center">
Figure 11. Options screen on Windows<br>
<p align = "center">
<img width = "450" height = "580" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Project_info_Android.png?raw=true">
</p>

<p align = "center">
Figure 12. Project information on Android<br>
</p>
<p align = "center">
<img width = "496" height = "336" src="https://github.com/StuckInTheCode/I_have_a_plan/blob/master/documents/mockups/I_have_a_plan!_Project_info_UWP.png?raw=true">
</p>

<p align = "center">
Figure 13. Project information on Windows<br>
</p>

### 2.3\. User Characteristics <a name="2.3"></a>
| User group | Description 
|:---|:---|
| IT specialists | A group of users that have a university degree,project planning experience and high technical literacy. Not the main audience of the application due to its basic functionality.|
| Professionals familiar with the principles of project management | A group of users that have higher education, experience in project planning and different technical literacy. People of this group with low experience or low technical literacy may be interested in using the application. |
| Students | The main audience of the project, interested in the experience in developing projects, have a different technical literacy|
| Other users | A group of users, on average, with secondary education, lack of experience in working on projects and low to medium technical literacy. They may be interested in using the application due to its simplicity of functions.|

### 2.4\. Assumptions and Dependencies <a name="2.4"></a>
1. Application works without network connection;
2. The application works with the local device data storage.

## 3\. System Requirements <a name="3"></a>
### 3.1\. Functional Requirements <a name="3.1"></a>

#### 3.1.1\. Basic functionality <a name="3.1.1"></a>

##### 3.1.1.1\. Processing  project progress <a name="3.1.1.1"></a>
<b>Description: </b> The user data on the execution of project tasks is automatically processed by the application.

Function | Requirements
| :--- | :--- 
|Counting the number of days until work ends | The application should display the number of days remaining to complete the project.|
|Accounting for the number of days of work on each task|The application should display the percentage of the number of days with the completed task.|

##### 3.1.1.2\. Done daily tasks <a name="3.1.1.2"></a>
<b>Description: </b> The user has the ability to mark the tasks as completed in application.

Function | Requirements
| :--- | :---
Done daily task |The application must keep a daily record of the tasks marked by the user as completed.

##### 3.1.1.3\. Adding project <a name="3.1.1.3"></a>
<b>Description: </b> The user has the ability to add project with additional information in the application.

Function | Requirements
| :--- | :---
Adding the project| The application should allow the user to add new projects.

##### 3.1.1.4\. Deleting project <a name="3.1.1.4"></a>
<b>Description: </b> The user has the ability to delete selected project in the application.

Function | Requirements
| :--- | :---
Deleting the project |The application should allow the user to delete selected project.

##### 3.1.1.5\. Editing project information <a name="3.1.1.5"></a>
<b>Description: </b> The user has the ability to edit the information of the selected project.

Function | Requirements
| :--- | :---
Editing project information | The application should allow the user to edit the information of the selected project.
 
##### 3.1.1.6\. Adding project tasks <a name="3.1.1.6"></a>
<b>Description: </b> The user has the ability to add tasks to the selected project.

Function | Requirements
| :--- | :---
Adding the task of the project  |  The application should allow the user to add tasks to the selected projects

##### 3.1.1.7\. Editing project tasks <a name="3.1.1.7"></a>
<b>Description: </b> The user has the ability to edit tasks of the selected project.

Function | Requirements
| :--- | :---
Editing the task of the project| The application should allow the user to change the task information of the selected project.

##### 3.1.1.8\. Deleting project tasks <a name="3.1.1.8"></a>
<b>Description: </b> The user has the ability to delete tasks of the selected project.

Function | Requirements
| :--- | :---
Deleting the task of the project | The application should allow the user to delete the task of the selected project.

##### 3.1.1.9\.   Сustomize notifications<a name="3.1.1.9"></a>
<b>Description: </b> The user has the ability to customize the format and the time of the notifications.
Function | Requirements
| :--- | :---
|Change notification format| The application should allow the user to edit format of the notification (notification with sound, with vibration, with sound and vibration,with no sound)|
|Change the working time| The application should allow the user to set the time when notifications start and when they finish|
|Change the period of notification|The application should allow the user to configure the period of notification|

#### 3.1.2\. Limitations and Exceptions <a name="3.1.2"></a>
 The application is implemented on the .NET Standard 2.0 platform.

### 3.2\. Non-Functional Requierements <a name = "3.2"></a>
#### 3.2.1\. Software Quality Attributes <a name = "3.2.1"></a>
##### 3.2.1.1 Usability <a name = "3.2.1.1"></a>
1. The contrast between the colors of the font, functional elements and background should ensure a comfortable user experience with the application;
2. All functional elements of the user interface have icons that describe the action that the element does.

#### 3.2.2\. External Interfaces <a name = "3.2.2"></a>
Application screens should be convenient for use by users with poor eyesight:

- font size not less than 13 pt;
- functional elements must be equal in size or larger than the main text on the screen

> Written with [StackEdit](https://stackedit.io/).
